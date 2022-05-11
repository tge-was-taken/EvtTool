using EvtTool.IO;

namespace EvtTool
{
    public sealed class MlCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public byte Diffuse_Red { get; set; }
        public byte Diffuse_Green { get; set; }
        public byte Diffuse_Blue { get; set; }
        public byte Diffuse_Alpha { get; set; }
        public byte Ambient_Red { get; set; }
        public byte Ambient_Green { get; set; }
        public byte Ambient_Blue { get; set; }
        public byte Ambient_Alpha { get; set; }
        public byte Specular_Red { get; set; }
        public byte Specular_Green { get; set; }
        public byte Specular_Blue { get; set; }
        public byte Specular_Alpha { get; set; }
        public byte Emissive_Red { get; set; }
        public byte Emissive_Green { get; set; }
        public byte Emissive_Blue { get; set; }
        public byte Emissive_Alpha { get; set; }
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
            Diffuse_Red = reader.ReadByte();
            Diffuse_Green = reader.ReadByte();
            Diffuse_Blue = reader.ReadByte();
            Diffuse_Alpha = reader.ReadByte();
            Ambient_Red = reader.ReadByte();
            Ambient_Green = reader.ReadByte();
            Ambient_Blue = reader.ReadByte();
            Ambient_Alpha = reader.ReadByte();
            Specular_Red = reader.ReadByte();
            Specular_Green = reader.ReadByte();
            Specular_Blue = reader.ReadByte();
            Specular_Alpha = reader.ReadByte();
            Emissive_Red = reader.ReadByte();
            Emissive_Green = reader.ReadByte();
            Emissive_Blue = reader.ReadByte();
            Emissive_Alpha = reader.ReadByte();
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
            writer.Write(Diffuse_Red);
            writer.Write(Diffuse_Green);
            writer.Write(Diffuse_Blue);
            writer.Write(Diffuse_Alpha);
            writer.Write(Ambient_Red);
            writer.Write(Ambient_Green);
            writer.Write(Ambient_Blue);
            writer.Write(Ambient_Alpha);
            writer.Write(Specular_Red);
            writer.Write(Specular_Green);
            writer.Write(Specular_Blue);
            writer.Write(Specular_Alpha);
            writer.Write(Emissive_Red);
            writer.Write(Emissive_Green);
            writer.Write(Emissive_Blue);
            writer.Write(Emissive_Alpha);
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
        }
    }
}
