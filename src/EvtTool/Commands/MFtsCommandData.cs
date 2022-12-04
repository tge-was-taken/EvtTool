using EvtTool.IO;

namespace EvtTool
{
    public sealed class MFtsCommandData : CommandData
    {
        public bool FootstepAreaDistortion { get; set; }
        public bool FootstepPuddleEffect { get; set; }
        public float FootstepDistortionStrength { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            int FootstepDistortionBitfield = reader.ReadInt32();
            FootstepAreaDistortion = (FootstepDistortionBitfield & 2) == 2;
            FootstepPuddleEffect = (FootstepDistortionBitfield & 4) == 4;
            FootstepDistortionStrength = reader.ReadSingle();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            int FootstepDistortionBitfield = 0;

            if (FootstepAreaDistortion)
                FootstepDistortionBitfield += 2;

            if (FootstepPuddleEffect)
                FootstepDistortionBitfield += 4;

            writer.Write(FootstepDistortionBitfield);
            writer.Write( FootstepDistortionStrength );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
