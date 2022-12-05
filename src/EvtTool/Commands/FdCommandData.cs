using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public class FdCommandData : CommandData
    {
        public int Field00 { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public fadeMode FadeMode { get; set; }
        public byte FadeType { get; set; }
        public short Field06 { get; set; }

        public int Field08 { get; set; }

        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            FadeMode = (fadeMode)reader.ReadByte();
            FadeType = reader.ReadByte();
            Field06 = reader.ReadInt16();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( (byte)FadeMode );
            writer.Write( FadeType );
            writer.Write( Field06 );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }

        public enum fadeMode
        {
            FadeIn = 2,
            FadeOut = 1,
        }
    }
}