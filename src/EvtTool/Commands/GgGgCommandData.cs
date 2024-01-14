using EvtTool.IO;

namespace EvtTool
{
    public class GgGgCommandData : CommandData
    {
        public int UnusedField00 { get; set; }

        public int Field04 { get; set; }

        public short Field08 { get; set; }
        public short Field0A { get; set; }

        public int UnusedField0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            UnusedField00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt16();
            Field0A = reader.ReadInt16();
            UnusedField0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( UnusedField00 );
            writer.Write( Field04 );
            writer.Write( Field0A );
            writer.Write( UnusedField0C );
        }
    }
}