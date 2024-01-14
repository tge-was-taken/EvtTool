using EvtTool.IO;

namespace EvtTool
{
    public sealed class CClpCommandData : CommandData
    {
        public int Unused00 { get; set; }
        public int Unused04 { get; set; }
        public float NearClip { get; set; }
        public float FarClip { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Unused00 = reader.ReadInt32();
            Unused04 = reader.ReadInt32();
            NearClip = reader.ReadSingle();
            FarClip = reader.ReadSingle();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Unused00 );
            writer.Write( Unused04 );
            writer.Write( NearClip );
            writer.Write( FarClip );
        }
    }
}
