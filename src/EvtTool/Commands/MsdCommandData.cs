using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    internal class MsdCommandData : CommandData
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public int Field18 { get; set; }
        public float Field1C { get; set; }
        public int Field20 { get; set; }
        public float Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Field3C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Position = reader.ReadVector3();
            Rotation = reader.ReadVector3();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadSingle();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
            Field30 = reader.ReadInt32();
            Field34 = reader.ReadInt32();
            Field38 = reader.ReadInt32();
            Field3C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Position );
            writer.Write( Rotation );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );
            writer.Write( Field30 );
            writer.Write( Field34 );
            writer.Write( Field38 );
            writer.Write( Field3C );
        }
    }
}