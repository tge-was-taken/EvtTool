using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public class UnknownCommandData : CommandData
    {
        [JsonConverter(typeof( IntHexDumpJsonConverter ) )]
        public byte[] Bytes { get; set; }

        public UnknownCommandData()
        {
        }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Bytes = reader.ReadBytes( command.DataSize );
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Bytes );
        }
    }
}