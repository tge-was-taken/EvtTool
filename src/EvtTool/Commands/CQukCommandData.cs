using EvtTool.IO;

namespace EvtTool
{
    public sealed class CQukCommandData : CommandData
    {
        public int Field00 { get; set; }
        public float QuakeIntensity { get; set; }
        public float QuakeAngle { get; set; }
        public int EaseDuration { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            QuakeIntensity = reader.ReadSingle();
            QuakeAngle = reader.ReadSingle();
            EaseDuration = reader.ReadInt32();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( QuakeIntensity );
            writer.Write( QuakeAngle );
            writer.Write( EaseDuration );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }
    }
}
