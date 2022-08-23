using System.Text;
using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    [JsonConverter(typeof( CommandJsonConverter ) )]
    public sealed class Command
    {
        internal const int SIZE = 0x30;

        public string Type { get; set; }

        public int Field04 { get; set; }

        public int Field06 { get; set; }

        public int ObjectId { get; set; }

        public int Field0C { get; set; }

        public int Time { get; set; }

        public int Duration { get; set; }

        public int DataSize { get; set; }

        public int Field20 { get; set; }

        public int LocalDataID { get; set; }

        public int LocalDataValue { get; set; }

        public int Field2C { get; set; }

        [JsonConverter(typeof( DontDeserializeJsonConverter ) )]
        public CommandData Data { get; set; }

        internal void Read( EndianBinaryReader reader )
        {
            Type = Encoding.ASCII.GetString( reader.ReadBytes( 4 ) );
            Field04 = reader.ReadInt16();
            Field06 = reader.ReadInt16();
            ObjectId = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            Time = reader.ReadInt32();
            Duration = reader.ReadInt32();
            var dataOffset = reader.ReadInt32();
            DataSize = reader.ReadInt32();
            Field20 = reader.ReadInt32();
            LocalDataID = reader.ReadInt32();
            LocalDataValue = reader.ReadInt32();
            Field2C = reader.ReadInt32();

            reader.ReadAtOffset( dataOffset, () =>
            {
                Data = CommandDataFactory.Create( Type );
                Data.Read( this, reader );
            });
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Write( Encoding.ASCII.GetBytes( Type ) );
            writer.Write( (short)Field04 );
            writer.Write( (short)Field06 );
            writer.Write( ObjectId );
            writer.Write( Field0C );
            writer.Write( Time );
            writer.Write( Duration );
            writer.ScheduleOffsetWrite( () => Data.Write( this, writer ) );
            writer.Write( DataSize );
            writer.Write( Field20 );
            writer.Write(LocalDataID);
            writer.Write(LocalDataValue);
            writer.Write( Field2C );
        }

    }
}