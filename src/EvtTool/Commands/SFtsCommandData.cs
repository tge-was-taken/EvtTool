using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class SFtsCommandData : CommandData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Boolean EnableFootsteps { get; set; }
        public int EvtObjectId { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            EnableFootsteps = (Boolean)reader.ReadInt32();
            EvtObjectId = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( (int)EnableFootsteps );
            writer.Write( EvtObjectId );
            writer.Write( Field08 );
            writer.Write( Field0C );
        }

        public enum Boolean
        {
            False = 0,
            True = 1,
        }
    }
}
