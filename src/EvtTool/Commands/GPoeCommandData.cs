using EvtTool.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    public sealed class GPoeCommandData : CommandData
    {
        public int Field00 { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public poemType PoemType { get; set; }
        public int PoemMajorId { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            PoemType = (poemType)reader.ReadInt32();
            PoemMajorId = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( (int)PoemType );
            writer.Write( PoemMajorId );
            writer.Write( Field0C );
        }

        public enum poemType : int
        {
            rankup,
            max,
            gameover
        }
    }
}
