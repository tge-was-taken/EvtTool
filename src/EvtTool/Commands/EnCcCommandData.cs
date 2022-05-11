using EvtTool.IO;

namespace EvtTool
{
    public sealed class EnCcCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public float Cyan { get; set; }
        public float Magenta { get; set; }
        public float Yellow { get; set; }
        public float Dodge { get; set; }
        public float Burn { get; set; }
        public int Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            Cyan = reader.ReadSingle();
            Magenta = reader.ReadSingle();
            Yellow = reader.ReadSingle();
            Dodge = reader.ReadSingle();
            Burn = reader.ReadSingle();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write(Cyan);
            writer.Write(Magenta);
            writer.Write(Yellow);
            writer.Write(Dodge);
            writer.Write(Burn);
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
        }
    }
}
