using EvtTool.IO;

namespace EvtTool
{
    public sealed class EnHdCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public float Field10 { get; set; }
        public float BloomStrength { get; set; }
        public float Field18 { get; set; }
        public float BloomDampener { get; set; }
        public int Field20 { get; set; }
        public float GlareLength { get; set; }
        public float GlareStrength { get; set; }
        public float Field2C { get; set; }
        public float GlareDirection { get; set; }
        public float Field34 { get; set; }
        public float Field38 { get; set; }
        public float Field3C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            Field10 = reader.ReadSingle();
            BloomStrength = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            BloomDampener = reader.ReadSingle();
            Field20 = reader.ReadInt32();
            GlareLength = reader.ReadSingle();
            GlareStrength = reader.ReadSingle();
            Field2C = reader.ReadSingle();
            GlareDirection = reader.ReadSingle();
            Field34 = reader.ReadSingle();
            Field38 = reader.ReadSingle();
            Field3C = reader.ReadSingle();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Field10 );
            writer.Write( BloomStrength );
            writer.Write( Field18 );
            writer.Write(BloomDampener);
            writer.Write( Field20 );
            writer.Write(GlareLength);
            writer.Write( GlareStrength );
            writer.Write( Field2C );
            writer.Write(GlareDirection);
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Field3C );
        }
    }
}
