using EvtTool.IO;

namespace EvtTool
{
    public sealed class FrJCommandData : CommandData
    {
        public int JumpToFrame { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            JumpToFrame = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( JumpToFrame );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
