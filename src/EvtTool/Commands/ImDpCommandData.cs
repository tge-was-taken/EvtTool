using EvtTool.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EvtTool
{
    public sealed class ImDpCommandData : CommandData
    {
        public int Field00 { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public imageShowMode ImageShowMode { get; set; }
        public bool PlayAnim { get; set; }
        public short PictId { get; set; }
        public short FrameId { get; set; }
        public short Field0A { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            ImageShowMode = (imageShowMode)reader.ReadByte();
            PlayAnim = reader.ReadBoolean();
            PictId = reader.ReadInt16();
            FrameId = reader.ReadInt16();
            Field0A = reader.ReadInt16();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write((byte)ImageShowMode);
            writer.Write(PlayAnim);
            writer.Write(PictId);
            writer.Write(FrameId);
            writer.Write(Field0A);
            writer.Write( Field0C );
        }

        public enum imageShowMode
        {
            Show = 1,
            Hide = 2
        }
    }
}
