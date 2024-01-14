using EvtTool.IO;

namespace EvtTool
{
    public sealed class CarCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Unused04 { get; set; }
        public int Unused08 { get; set; }
        public int Unused0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Unused04 = reader.ReadInt32();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Unused04 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}
