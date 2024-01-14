using EvtTool.IO;

namespace EvtTool
{
    public sealed class CaaCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public float Field0C { get; set; }
        public int Unused10 { get; set; }
        public int Unused14 { get; set; }
        public int Unused18 { get; set; }
        public int Unused1C { get; set; }
        public int Unused20 { get; set; }
        public int Unused24 { get; set; }
        public int Unused28 { get; set; }
        public int Unused2C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadSingle();
            Unused10 = reader.ReadInt32();
            Unused14 = reader.ReadInt32();
            Unused18 = reader.ReadInt32();
            Unused1C = reader.ReadInt32();
            Unused20 = reader.ReadInt32();
            Unused24 = reader.ReadInt32();
            Unused28 = reader.ReadInt32();
            Unused2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Unused10 );
            writer.Write( Unused14 );
            writer.Write( Unused18 );
            writer.Write( Unused1C );
            writer.Write( Unused20 );
            writer.Write( Unused24 );
            writer.Write( Unused28 );
            writer.Write( Unused2C );
        }
    }
}
