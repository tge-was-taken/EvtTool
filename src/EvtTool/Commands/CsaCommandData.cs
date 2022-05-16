using EvtTool.IO;

namespace EvtTool
{
    public sealed class CsaCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int CameraObjectID { get; set; }
        public int CameraAnimation { get; set; }
        public float CameraSpeed { get; set; }
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public float Field20 { get; set; }
        public float Field24 { get; set; }
        public float Field28 { get; set; }
        public int Field2C { get; set; }
        public float Field30 { get; set; }
        public float Field34 { get; set; }
        public float Field38 { get; set; }
        public float Field3C { get; set; }
        public int Field40 { get; set; }
        public int Field44 { get; set; }
        public float Field48 { get; set; }
        public float Field4C { get; set; }
        public int Field50 { get; set; }
        public int Field54 { get; set; }
        public int Field58 { get; set; }
        public int Field5C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            CameraObjectID = reader.ReadInt32();
            CameraAnimation = reader.ReadInt32();
            CameraSpeed = reader.ReadSingle();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadSingle();
            Field24 = reader.ReadSingle();
            Field28 = reader.ReadSingle();
            Field2C = reader.ReadInt32();
            Field30 = reader.ReadSingle();
            Field34 = reader.ReadSingle();
            Field38 = reader.ReadSingle();
            Field3C = reader.ReadSingle();
            Field40 = reader.ReadInt32();
            Field44 = reader.ReadInt32();
            Field48 = reader.ReadSingle();
            Field4C = reader.ReadSingle();
            Field50 = reader.ReadInt32();
            Field54 = reader.ReadInt32();
            Field58 = reader.ReadInt32();
            Field5C = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write(CameraObjectID);
            writer.Write(CameraAnimation);
            writer.Write(CameraSpeed);
            writer.Write( Field10 );
            writer.Write( Field14 );
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
            writer.Write( Field40 );
            writer.Write( Field44 );
            writer.Write( Field48 );
            writer.Write( Field4C );
            writer.Write( Field50 );
            writer.Write( Field54 );
            writer.Write( Field58 );
            writer.Write( Field5C );
        }
    }
}
