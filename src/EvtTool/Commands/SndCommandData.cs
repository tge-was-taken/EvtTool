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
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public int CueId { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            SoundType = (SndMan)reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            CueId = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( (int)SoundType);
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( CueId );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }

        public enum SndMan
        {
            Bgm = 1,
            System = 2,
            Event = 3,
        }
    }
}
