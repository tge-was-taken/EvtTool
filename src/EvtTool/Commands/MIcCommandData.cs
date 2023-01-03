using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class MIcCommandData : CommandData
    {
        public int Field00 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public IconEnum Icon { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Icon = (IconEnum)reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( (int)Icon );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }

        public enum IconEnum
        {
            Single_Exclamation = 1,
            Double_Exclamation = 2,
            Question_Mark = 3,
            Exclamation_and_Question_Mark = 4,
            Anger = 9,
            Anger2 = 10,
            Talking = 11,
            Talking_x2 = 12,
            Sleeping = 14,
            Phone_Ringing = 15,
            Sweat = 16,
            Panic = 17,
        }
    }
}
