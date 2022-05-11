using EvtTool.IO;

namespace EvtTool
{
    public sealed class MaaCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int BlendAnimationID { get; set; }
        public int Field08 { get; set; }
        public float AnimationSpeed { get; set; }
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            BlendAnimationID = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            AnimationSpeed = reader.ReadSingle();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write(BlendAnimationID);
            writer.Write( Field08 );
            writer.Write(AnimationSpeed);
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }
    }
}
