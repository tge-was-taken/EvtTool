using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class EvtObject
    {
        internal const int SIZE = 0x30;

        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EvtObjectType Type { get; set; }

        public int Field08 { get; set; }

        public int DuplicateObjectIndex { get; set; }

        public int ResourceMajorId { get; set; }

        public short ResourceSubId { get; set; }

        public short ResourceMinorId { get; set; }

        [JsonConverter(typeof(HexStringJsonConverter))]
        public uint Field1C { get; set; }

        public int AnimationMajorId { get; set; }

        public int AnimationMinorId { get; set; }

        public int AnimationSubId { get; set; }

        public int Field28 { get; set; }

        public int Field2C { get; set; }

        public EvtObject()
        {
            Field08 = 1;
            AnimationMajorId = -1;
            AnimationMinorId = -1;
            AnimationSubId = -1;
        }

        internal void Read( EndianBinaryReader reader )
        {
            Id = reader.ReadInt32();
            Type = ( EvtObjectType ) reader.ReadInt32();
            Field08 = reader.ReadInt32();
            DuplicateObjectIndex = reader.ReadInt32();
            ResourceMajorId = reader.ReadInt32();
            ResourceSubId = reader.ReadInt16();
            ResourceMinorId = reader.ReadInt16();
            Field1C = reader.ReadUInt32();
            AnimationMajorId = reader.ReadInt32();
            AnimationMinorId = reader.ReadInt32();
            AnimationSubId = reader.ReadInt32();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Write( Id );
            writer.Write( ( int ) Type );
            writer.Write( Field08 );
            writer.Write( DuplicateObjectIndex );
            writer.Write( ResourceMajorId );
            writer.Write( ResourceSubId );
            writer.Write( ResourceMinorId );
            writer.Write( Field1C );
            writer.Write( AnimationMajorId );
            writer.Write( AnimationMinorId );
            writer.Write( AnimationSubId );
            writer.Write( Field28 );
            writer.Write( Field2C );
        }
    }
}