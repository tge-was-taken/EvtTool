using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public class FdSCommandData : CommandData
    {
        public int Field00 { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FadeType FadeType { get; set; }

        public int Field08 { get; set; }

        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            FadeType = ( FadeType ) reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( (int)FadeType );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }

    public enum FadeType
    {
        None,
        BlackIn,
        BlackOut,
        WhiteIn,
        WhiteOut
    }
}