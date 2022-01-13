using System;
using Newtonsoft.Json;

namespace EvtTool.Json.Converters
{
    public sealed class HexStringJsonConverter : JsonConverter<uint>
    {
        public override void WriteJson( JsonWriter writer, uint value, JsonSerializer serializer )
        {
            writer.WriteValue( $"0x{value:x}" );
        }

        public override uint ReadJson( JsonReader reader, Type objectType, uint existingValue, bool hasExistingValue, JsonSerializer serializer )
        {
            var str = reader.Value.ToString();
            if ( str == null || !str.StartsWith( "0x" ) )
                throw new JsonSerializationException();
            return uint.Parse( str.Substring( 2 ), System.Globalization.NumberStyles.HexNumber );
        }
    }
}