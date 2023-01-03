using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class SndCommandData : CommandData
    {
        public int Field00 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SndMan SoundType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public SndAction Action { get; set; }
        public int Channel { get; set; }
        public int CueId { get; set; }
        public int Field14 { get; set; }
        public int FadeoutDuration { get; set; }
        public int Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            SoundType = (SndMan)reader.ReadInt32();
            Action = (SndAction)reader.ReadInt32();
            Channel = reader.ReadInt32();
            CueId = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            FadeoutDuration = reader.ReadInt32();
            Field1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( (int)SoundType);
            writer.Write( (int)Action );
            writer.Write( Channel );
            writer.Write( CueId );
            writer.Write( Field14 );
            writer.Write( FadeoutDuration );
            writer.Write( Field1C );
        }

        public enum SndMan
        {
            Bgm = 1,
            System = 2,
            Event = 3,
        }

        public enum SndAction
        {
            Play = 1,
            Stop = 2,
        }
    }
}
