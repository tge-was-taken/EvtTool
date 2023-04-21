using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    [JsonObject( ItemRequired = Required.Always )]
    public sealed class EvtFile : ICommandList, ISaveable
    {
        private const int MAGIC = 0x45565401;
        private const int MAGIC_P5R = 0x45565400;

        private const int FIELD14_VALUE = 0x90;
        private const int FIELD14_VALUE_P5R = 0x130;

        public const int CURRENT_VERSION = 0x0002722E;

        [JsonConverter(typeof(StringEnumConverter))]
        public EvtTool.IO.Endianness Endianness { get; set; }

        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint Version { get; set; }

        public short MajorId { get; set; }

        public short MinorId { get; set; }

        public byte Field0C { get; set; }

        public byte Field0D { get; set; }

        public short Field0E { get; set; }

        public int Field14 { get; set; }

        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint Field18 { get; set; }

        public int Duration { get; set; }

        public byte Field20 { get; set; }

        public byte Field21 { get; set; }

        public short Field22 { get; set; }

        public int Field24 { get; set; }

        public int Field28 { get; set; }

        public int Field2C { get; set; }

        public int Field3C { get; set; }

        public int Field4C { get; set; }

        public string EventBmdPath { get; set; }

        public int EventBmdPathLength { get; set; }

        public int Field58 { get; set; }

        public int Field5C { get; set; }

        public string EventBfPath { get; set; }

        public int EventBfPathLength { get; set; }

        public int Field68 { get; set; }

        public int Field6C { get; set; }

        public int Field70 { get; set; }

        public int Field74 { get; set; }

        public int Field78 { get; set; }

        public int Field7C { get; set; }

        public int Field80 { get; set; }

        public int Field84 { get; set; }

        public int Field88 { get; set; }

        public int Field8C { get; set; }
        public int Field90 { get; set; }

        public int Field94 { get; set; }

        public int Field98 { get; set; }

        public int Field9C { get; set; }

        public int FieldA0 { get; set; }

        public int FieldA4 { get; set; }

        public int FieldA8 { get; set; }

        public int FieldAC { get; set; }

        public int FieldB0 { get; set; }

        public int FieldB4 { get; set; }

        public int FieldB8 { get; set; }

        public int FieldBC { get; set; }

        public int FieldC0 { get; set; }

        public int FieldC4 { get; set; }

        public int FieldC8 { get; set; }

        public int FieldCC { get; set; }

        public int FieldD0 { get; set; }

        public int FieldD4 { get; set; }

        public int FieldD8 { get; set; }

        public int FieldDC { get; set; }

        public int FieldE0 { get; set; }

        public int FieldE4 { get; set; }

        public int FieldE8 { get; set; }

        public int FieldEC { get; set; }

        public int FieldF0 { get; set; }

        public int FieldF4 { get; set; }

        public int FieldF8 { get; set; }

        public int FieldFC { get; set; }

        public int Field100 { get; set; }

        public int Field104 { get; set; }

        public int Field108 { get; set; }

        public int Field10C { get; set; }

        public int Field110 { get; set; }

        public int Field114 { get; set; }

        public int Field118 { get; set; }

        public int Field11C { get; set; }

        public int Field120 { get; set; }

        public int Field124 { get; set; }

        public int Field128 { get; set; }

        public int Field12C { get; set; }


        public List<EvtObject> Objects { get; }

        public List<Command> Commands { get; }

        public EvtFile()
        {
            Version = CURRENT_VERSION;
            Field20 = 30;
            Field28 = 1;

            Objects = new List<EvtObject>();
            Commands = new List<Command>();
        }

        public EvtFile( string path ) : this()
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

            var magic = reader.ReadInt32();
            if ( magic != MAGIC )
            {
                if (magic != MAGIC_P5R)
                {
                    throw new InvalidDataException("Magic value does not match");
                }

                // Switch to little endian for new P5R files

                reader.Endianness = Endianness.Little;
                Endianness = Endianness.Little;
            }

            Version = reader.ReadUInt32();
            MajorId = reader.ReadInt16();
            MinorId = reader.ReadInt16();
            Field0C = reader.ReadByte();
            Field0D = reader.ReadByte();
            Field0E = reader.ReadInt16();
            var fileSize = reader.ReadInt32();
            Field14 = reader.ReadInt32();

            /*if (p5rFormat)
            {
                Trace.Assert(Field14 == FIELD14_VALUE_P5R, $"Field14 != {FIELD14_VALUE_P5R}");
            }
            else
            {
                Trace.Assert(Field14 == FIELD14_VALUE, $"Field14 != {FIELD14_VALUE}");
            }*/ //not needed, P5R EVTs can be 0x90 just like P5 too while being LE

            Field18 = reader.ReadUInt32();
            Duration = reader.ReadInt32();
            Field20 = reader.ReadByte();
            Field21 = reader.ReadByte();
            Field22 = reader.ReadInt16();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
            var objectCount = reader.ReadInt32();
            var objectOffset = reader.ReadInt32();
            var objectSize = reader.ReadInt32();
            Trace.Assert( objectSize == EvtObject.SIZE, $"Object size != {EvtObject.SIZE}" );
            Field3C = reader.ReadInt32();
            var commandCount = reader.ReadInt32();
            var commandOffset = reader.ReadInt32();
            var commandSize = reader.ReadInt32();
            Trace.Assert( commandSize == Command.SIZE, $"Command size != {Command.SIZE}" );
            Field4C = reader.ReadInt32();
            var PointerToEventBmdPath = reader.ReadInt32();
            EventBmdPathLength = reader.ReadInt32();
            Field58 = reader.ReadInt32();
            Field5C = reader.ReadInt32();
            var PointerToEventBfPath = reader.ReadInt32();
            EventBfPathLength = reader.ReadInt32();
            Field68 = reader.ReadInt32();
            Field6C = reader.ReadInt32();
            Field70 = reader.ReadInt32();
            Field74 = reader.ReadInt32();
            Field78 = reader.ReadInt32();
            Field7C = reader.ReadInt32();
            Field80 = reader.ReadInt32();
            Field84 = reader.ReadInt32();
            Field88 = reader.ReadInt32();
            Field8C = reader.ReadInt32();
            if ( Field14 > 0x90 )
            {
                Field90 = reader.ReadInt32();
                Field94 = reader.ReadInt32();
                Field98 = reader.ReadInt32();
                Field9C = reader.ReadInt32();
                FieldA0 = reader.ReadInt32();
                FieldA4 = reader.ReadInt32();
                FieldA8 = reader.ReadInt32();
                FieldAC = reader.ReadInt32();
                FieldB0 = reader.ReadInt32();
                FieldB4 = reader.ReadInt32();
                FieldB8 = reader.ReadInt32();
                FieldBC = reader.ReadInt32();
                FieldC0 = reader.ReadInt32();
                FieldC4 = reader.ReadInt32();
                FieldC8 = reader.ReadInt32();
                FieldCC = reader.ReadInt32();
                FieldD0 = reader.ReadInt32();
                FieldD4 = reader.ReadInt32();
                FieldD8 = reader.ReadInt32();
                FieldDC = reader.ReadInt32();
                FieldE0 = reader.ReadInt32();
                FieldE4 = reader.ReadInt32();
                FieldE8 = reader.ReadInt32();
                FieldEC = reader.ReadInt32();
                FieldF0 = reader.ReadInt32();
                FieldF4 = reader.ReadInt32();
                FieldF8 = reader.ReadInt32();
                FieldFC = reader.ReadInt32();
                Field100 = reader.ReadInt32();
                Field104 = reader.ReadInt32();
                Field108 = reader.ReadInt32();
                Field10C = reader.ReadInt32();
                Field110 = reader.ReadInt32();
                Field114 = reader.ReadInt32();
                Field118 = reader.ReadInt32();
                Field11C = reader.ReadInt32();
                Field120 = reader.ReadInt32();
                Field124 = reader.ReadInt32();
                Field128 = reader.ReadInt32();
                Field12C = reader.ReadInt32();
            }

            EventBmdPath = GetEvtString(reader, PointerToEventBmdPath);

            EventBfPath = GetEvtString(reader, PointerToEventBfPath);

            reader.SeekBegin( objectOffset );
            Objects.Capacity = objectCount;
            for ( int i = 0; i < objectCount; i++ )
            {
                var obj = new EvtObject();
                obj.Read( reader );
                Objects.Add( obj );
            }

            reader.SeekBegin( commandOffset );
            Commands.Capacity = commandCount;
            for ( int i = 0; i < commandCount; i++ )
            {
                var command = new Command();
                command.Read( reader );
                Commands.Add( command );
            }
        }
        
        internal string GetEvtString(EndianBinaryReader reader, int pointerToString)
        {
            if (pointerToString > 0)
            {
                reader.Seek(pointerToString, SeekOrigin.Begin);
                return reader.ReadString(StringBinaryFormat.NullTerminated);
            }
            else return "Null";
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Endianness = Endianness;
            
            if ( Endianness == Endianness.Big )
            {
                writer.Write(0x45565401);
            }
            else writer.Write( 0x00545645 );

            writer.Write( Version );
            writer.Write( MajorId );
            writer.Write( MinorId );
            writer.Write( Field0C );
            writer.Write( Field0D );
            writer.Write( Field0E );
            writer.ScheduleFileSizeWrite();
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Duration );
            writer.Write( Field20 );
            writer.Write( Field21 );
            writer.Write( Field22 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Objects.Count );
            writer.ScheduleOffsetWrite( () => Objects.ForEach( o => o.Write( writer ) ) );
            writer.Write( EvtObject.SIZE );
            writer.Write( Field3C );
            writer.Write( Commands.Count );
            writer.ScheduleOffsetWrite( () => Commands.ForEach( c => c.Write( writer ) ) );
            writer.Write( Command.SIZE );
            writer.Write( Field4C );
            writer.Write( (int) 0 ); // dummy bmd pointer, field50
            //writer.Write( EventBmdPath );
            writer.Write( EventBmdPathLength );
            writer.Write( Field58 );
            writer.Write( Field5C );
            writer.Write((int)0); // dummy bf pointer, field60
            //writer.Write( EventBfPath );
            writer.Write( EventBfPathLength );
            writer.Write( Field68 );
            writer.Write( Field6C );
            writer.Write( Field70 );
            writer.Write( Field74 );
            writer.Write( Field78 );
            writer.Write( Field7C );
            writer.Write( Field80 );
            writer.Write( Field84 );
            writer.Write( Field88 );
            writer.Write( Field8C );
            if ( Field14 > 0x90 )
            {
                writer.Write(Field90);
                writer.Write(Field94);
                writer.Write(Field98);
                writer.Write(Field9C);
                writer.Write(FieldA0);
                writer.Write(FieldA4);
                writer.Write(FieldA8);
                writer.Write(FieldAC);
                writer.Write(FieldB0);
                writer.Write(FieldB4);
                writer.Write(FieldB8);
                writer.Write(FieldBC);
                writer.Write(FieldC0);
                writer.Write(FieldC4);
                writer.Write(FieldC8);
                writer.Write(FieldCC);
                writer.Write(FieldD0);
                writer.Write(FieldD4);
                writer.Write(FieldD8);
                writer.Write(FieldDC);
                writer.Write(FieldE0);
                writer.Write(FieldE4);
                writer.Write(FieldE8);
                writer.Write(FieldEC);
                writer.Write(FieldF0);
                writer.Write(FieldF4);
                writer.Write(FieldF8);
                writer.Write(FieldFC);
                writer.Write(Field100);
                writer.Write(Field104);
                writer.Write(Field108);
                writer.Write(Field10C);
                writer.Write(Field110);
                writer.Write(Field114);
                writer.Write(Field118);
                writer.Write(Field11C);
                writer.Write(Field120);
                writer.Write(Field124);
                writer.Write(Field128);
                writer.Write(Field12C);
            }

            writer.PerformScheduledWrites();

            WriteEvtString(writer, EventBmdPath, 0x50);

            WriteEvtString(writer, EventBfPath, 0x60);
        }

        void WriteEvtString(EndianBinaryWriter writer, string filePath, int pointerToString)
        {
            if (filePath != "Null")
            {
                // original EVT files have bmd string at the end, this makes no difference but i want them to be as 1:1 as possible :raidoufrost:
                writer.SeekBegin(writer.Length);
                int currentPos = (int)writer.Position;

                var padding = 0x10 - (filePath.Length % 0x10);

                writer.Write(filePath, StringBinaryFormat.FixedLength, filePath.Length + padding);

                // write string offset
                writer.SeekBegin(pointerToString);
                writer.Write(currentPos);
                writer.Write(filePath.Length + padding);

                // fix filesize
                writer.SeekBegin(0x10);
                writer.Write((int)writer.Length);
            }
        }
    }
}