using EvtTool.IO;

namespace EvtTool
{
    public sealed class EnFdCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public int Field10 { get; set; }
        public float Lower_Bounds { get; set; }
        public float Upper_Bounds { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            Field10 = reader.ReadInt32();
            Lower_Bounds = reader.ReadSingle();
            Upper_Bounds = reader.ReadSingle();
            Red = reader.ReadByte();
            Green = reader.ReadByte();
            Blue = reader.ReadByte();
            Alpha = reader.ReadByte();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
            writer.Write( Field10 );
            writer.Write(Lower_Bounds);
            writer.Write(Upper_Bounds);
            writer.Write(Red);
            writer.Write(Green);
            writer.Write(Blue);
            writer.Write(Alpha);
        }
    }
}
