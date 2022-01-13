using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class LsdListEntry
    {
        internal const int SIZE = 8;

        [JsonConverter(typeof(ByteArrayJsonConverter))]
        public byte[] Field00 { get; set; } = new byte[4];

        public float Field04 { get; set; }

        internal void Read( EndianBinaryReader reader )
        {
            for ( int i = 0; i < Field00.Length; i++ )
                Field00[ i ] = reader.ReadByte();

            Field04 = reader.ReadSingle();
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
        }
    }
}