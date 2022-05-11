using EvtTool.IO;

namespace EvtTool
{
    public sealed class EnvCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int ENV_ObjectID { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            ENV_ObjectID = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write(ENV_ObjectID);
            writer.Write( Field08 );
            writer.Write( Field0C );
        }
    }
}
