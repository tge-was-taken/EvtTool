using EvtTool.IO;

namespace EvtTool
{
    public sealed class DateCommandData : CommandData
    {
        public int Field00 { get; set; }
        public byte Field04 { get; set; }
        public byte Field05 { get; set; }
        public short Unused06 { get; set; }
        public int Unused08 { get; set; }
        public int Unused0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadByte();
            Field05 = reader.ReadByte();
            Unused06 = reader.ReadInt16();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field05 );
            writer.Write( Unused06 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
