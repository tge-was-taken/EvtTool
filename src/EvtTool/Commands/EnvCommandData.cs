using EvtTool.IO;

namespace EvtTool
{
    public sealed class EnvCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int ENVObjectID { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            ENVObjectID = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write(ENVObjectID);
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
