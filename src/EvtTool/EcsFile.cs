using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    [JsonObject( ItemRequired = Required.Always )]
    public sealed class EcsFile : ICommandList, ISaveable
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EvtTool.IO.Endianness Endianness { get; set; }

        public List<Command> Commands { get; }

        public EcsFile()
        {
            Commands = new List<Command>();
        }

        public EcsFile( string path ) : this()
        {
            using ( var stream = File.OpenRead( path ) )
                Read( new EndianBinaryReader( stream, Endianness.Big ) );
        }

        public void Save( string path )
        {
            using ( var stream = FileHelper.Create( path ) )
                Write( new EndianBinaryWriter( stream, Endianness.Big ) );
        }

        internal void Read( EndianBinaryReader reader )
        {
            Endianness = Endianness.Big;
            var commandCount = reader.ReadInt32();
            var commandOffset = reader.ReadInt32();
            var commandSize = reader.ReadInt32();

            if (commandSize != Command.SIZE)
            {
                // Try to read as P5R format

                reader.Position = 0;
                reader.Endianness = Endianness.Little;
                commandCount = reader.ReadInt32();
                commandOffset = reader.ReadInt32();
                commandSize = reader.ReadInt32();
                Endianness = Endianness.Little;
            }

            var padding = reader.ReadInt32();
            Trace.Assert( commandOffset == 0x10, "Command offset != 0x10" );
            Trace.Assert( commandSize == Command.SIZE, $"Command size != {Command.SIZE}" );
            Trace.Assert( padding == 0, "Padding != 0" );

            reader.SeekBegin( commandOffset );
            Commands.Capacity = commandCount;
            for ( int i = 0; i < commandCount; i++ )
            {
                var command = new Command();
                command.Read( reader );
                Commands.Add( command );
            }
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Endianness = Endianness;

            writer.Write( Commands.Count );
            writer.ScheduleOffsetWrite( () => Commands.ForEach( x => x.Write( writer ) ) );
            writer.Write( Command.SIZE );
            writer.Write( 0 ); // padding
            writer.PerformScheduledWrites();
        }
    }
}