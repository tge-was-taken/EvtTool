using EvtTool.IO;

namespace EvtTool
{
    public class ChapCommandData : CommandData
    {
        public int Unused00 { get; set; }

        public int Unused04 { get; set; }

        public int Unused08 { get; set; }

        public int Unused0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            Unused04 = reader.ReadInt32();
            Unused08 = reader.ReadInt32();
            Unused0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( Unused04 );
            writer.Write( Unused08 );
            writer.Write( Unused0C );
        }
    }
}