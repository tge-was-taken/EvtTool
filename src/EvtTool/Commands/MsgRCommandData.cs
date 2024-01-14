using EvtTool.IO;
using static EvtTool.MsgCommandData;

namespace EvtTool
{
    public sealed class MsgRCommandData : CommandData
    {
        public MessageModeBitfield MessageMode { get; set; }
        public int MessageIndex { get; set; }
        public int SelIndex { get; set; }
        public int LocalDataIdSelStorage { get; set; }
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            MessageMode = new MessageModeBitfield();
            {
                MessageMode.data = reader.ReadInt32();
            };
            MessageIndex = reader.ReadInt32();
            SelIndex = reader.ReadInt32();
            LocalDataIdSelStorage = reader.ReadInt32();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(MessageMode.data);
            writer.Write( MessageIndex );
            writer.Write( SelIndex );
            writer.Write( LocalDataIdSelStorage );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }
    }
}
