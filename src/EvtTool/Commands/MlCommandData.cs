using EvtTool.IO;

namespace EvtTool
{
    public sealed class MlCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public byte DiffuseRed { get; set; }
        public byte DiffuseGreen { get; set; }
        public byte DiffuseBlue { get; set; }
        public byte DiffuseAlpha { get; set; }
        public byte AmbientRed { get; set; }
        public byte AmbientGreen { get; set; }
        public byte AmbientBlue { get; set; }
        public byte AmbientAlpha { get; set; }
        public byte SpecularRed { get; set; }
        public byte SpecularGreen { get; set; }
        public byte SpecularBlue { get; set; }
        public byte SpecularAlpha { get; set; }
        public byte EmissiveRed { get; set; }
        public byte EmissiveGreen { get; set; }
        public byte EmissiveBlue { get; set; }
        public byte EmissiveAlpha { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            DiffuseRed = reader.ReadByte();
            DiffuseGreen = reader.ReadByte();
            DiffuseBlue = reader.ReadByte();
            DiffuseAlpha = reader.ReadByte();
            AmbientRed = reader.ReadByte();
            AmbientGreen = reader.ReadByte();
            AmbientBlue = reader.ReadByte();
            AmbientAlpha = reader.ReadByte();
            SpecularRed = reader.ReadByte();
            SpecularGreen = reader.ReadByte();
            SpecularBlue = reader.ReadByte();
            SpecularAlpha = reader.ReadByte();
            EmissiveRed = reader.ReadByte();
            EmissiveGreen = reader.ReadByte();
            EmissiveBlue = reader.ReadByte();
            EmissiveAlpha = reader.ReadByte();
            Field20 = reader.ReadSingle();
            Field24 = reader.ReadSingle();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write(DiffuseRed);
            writer.Write(DiffuseGreen);
            writer.Write(DiffuseBlue);
            writer.Write(DiffuseAlpha);
            writer.Write(AmbientRed);
            writer.Write(AmbientGreen);
            writer.Write(AmbientBlue);
            writer.Write(AmbientAlpha);
            writer.Write(SpecularRed);
            writer.Write(SpecularGreen);
            writer.Write(SpecularBlue);
            writer.Write(SpecularAlpha);
            writer.Write(EmissiveRed);
            writer.Write(EmissiveGreen);
            writer.Write(EmissiveBlue);
            writer.Write(EmissiveAlpha);
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
        }
    }
}
