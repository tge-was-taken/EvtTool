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
        public float Bloom_Strength { get; set; }
        public float Field18 { get; set; }
        public float Bloom_Dampener { get; set; }
        public int Field20 { get; set; }
        public float Glare_Length { get; set; }
        public float Glare_Strength { get; set; }
        public float Field2C { get; set; }
        public float Glare_Direction { get; set; }
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
            Bloom_Strength = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Bloom_Dampener = reader.ReadSingle();
            Field20 = reader.ReadInt32();
            Glare_Length = reader.ReadSingle();
            Glare_Strength = reader.ReadSingle();
            Field2C = reader.ReadSingle();
            Glare_Direction = reader.ReadSingle();
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
            writer.Write( Bloom_Strength );
            writer.Write( Field18 );
            writer.Write(Bloom_Dampener);
            writer.Write( Field20 );
            writer.Write(Glare_Length);
            writer.Write( Glare_Strength );
            writer.Write( Field2C );
            writer.Write(Glare_Direction);
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Field3C );
        }
    }
}
