using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MmdCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public Vector3[] Positions { get; set; } = new Vector3[24];
        public int Field128 { get; set; }
        public float Field12C { get; set; }
        public int Field130 { get; set; }
        public int Field134 { get; set; }
        public int Field138 { get; set; }
        public int Field13C { get; set; }
        public int Field140 { get; set; }
        public float Field144 { get; set; }
        public int Field148 { get; set; }
        public int Field14C { get; set; }
        public int Field150 { get; set; }
        public int Field154 { get; set; }
        public int Field158 { get; set; }
        public int Field15C { get; set; }
        public int Field160 { get; set; }
        public float Field164 { get; set; }
        public int Field168 { get; set; }
        public int Field16C { get; set; }
        public int Field170 { get; set; }
        public int Field174 { get; set; }
        public int Field178 { get; set; }
        public int Field17C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            for ( int i = 0; i < Positions.Length; i++ )
                Positions[ i ] = reader.ReadVector3();
            Field128 = reader.ReadInt32();
            Field12C = reader.ReadSingle();
            Field130 = reader.ReadInt32();
            Field134 = reader.ReadInt32();
            Field138 = reader.ReadInt32();
            Field13C = reader.ReadInt32();
            Field140 = reader.ReadInt32();
            Field144 = reader.ReadSingle();
            Field148 = reader.ReadInt32();
            Field14C = reader.ReadInt32();
            Field150 = reader.ReadInt32();
            Field154 = reader.ReadInt32();
            Field158 = reader.ReadInt32();
            Field15C = reader.ReadInt32();
            Field160 = reader.ReadInt32();
            Field164 = reader.ReadSingle();
            Field168 = reader.ReadInt32();
            Field16C = reader.ReadInt32();
            Field170 = reader.ReadInt32();
            Field174 = reader.ReadInt32();
            Field178 = reader.ReadInt32();
            Field17C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Positions );
            writer.Write( Field128 );
            writer.Write( Field12C );
            writer.Write( Field130 );
            writer.Write( Field134 );
            writer.Write( Field138 );
            writer.Write( Field13C );
            writer.Write( Field140 );
            writer.Write( Field144 );
            writer.Write( Field148 );
            writer.Write( Field14C );
            writer.Write( Field150 );
            writer.Write( Field154 );
            writer.Write( Field158 );
            writer.Write( Field15C );
            writer.Write( Field160 );
            writer.Write( Field164 );
            writer.Write( Field168 );
            writer.Write( Field16C );
            writer.Write( Field170 );
            writer.Write( Field174 );
            writer.Write( Field178 );
            writer.Write( Field17C );
        }
}
}