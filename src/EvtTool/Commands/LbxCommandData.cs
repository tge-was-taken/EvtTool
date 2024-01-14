using EvtTool.IO;

namespace EvtTool
{
    public sealed class LbxCommandData : CommandData
    {
        public int Field00 { get; set; }
        public byte Field04 { get; set; }
        public byte Field05 { get; set; }
        public short Field06 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadByte();
            Field05 = reader.ReadByte();
            Field06 = reader.ReadInt16();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field05 );
            writer.Write( Field06 );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
