using EvtTool.IO;

namespace EvtTool
{
    public sealed class MaiCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public int Field0C { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public float Field18 { get; set; }
        public int Field1C { get; set; }
        public int Field20 { get; set; }
        public int Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public float Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Field3C { get; set; }
        public int Field40 { get; set; }
        public int Field44 { get; set; }
        public float Field48 { get; set; }
        public int Field4C { get; set; }
        public int Field50 { get; set; }
        public int Field54 { get; set; }
        public int Field58 { get; set; }
        public int Field5C { get; set; }
        public float Field60 { get; set; }
        public int Field64 { get; set; }
        public int Field68 { get; set; }
        public int Field6C { get; set; }
        public int Field70 { get; set; }
        public int Field74 { get; set; }
        public float Field78 { get; set; }
        public int Field7C { get; set; }
        public int Field80 { get; set; }
        public int Field84 { get; set; }
        public int Field88 { get; set; }
        public int Field8C { get; set; }
        public float Field90 { get; set; }
        public int Field94 { get; set; }
        public int Field98 { get; set; }
        public int Field9C { get; set; }
        public int FieldA0 { get; set; }
        public int FieldA4 { get; set; }
        public float FieldA8 { get; set; }
        public int FieldAC { get; set; }
        public int FieldB0 { get; set; }
        public int FieldB4 { get; set; }
        public int FieldB8 { get; set; }
        public int FieldBC { get; set; }
        public float FieldC0 { get; set; }
        public int FieldC4 { get; set; }
        public int FieldC8 { get; set; }
        public int FieldCC { get; set; }
        public int FieldD0 { get; set; }
        public int FieldD4 { get; set; }
        public float FieldD8 { get; set; }
        public int FieldDC { get; set; }
        public int FieldE0 { get; set; }
        public int FieldE4 { get; set; }
        public int FieldE8 { get; set; }
        public int FieldEC { get; set; }
        public float FieldF0 { get; set; }
        public int FieldF4 { get; set; }
        public int FieldF8 { get; set; }
        public int FieldFC { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadInt32();
            Field20 = reader.ReadInt32();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
            Field30 = reader.ReadSingle();
            Field34 = reader.ReadInt32();
            Field38 = reader.ReadInt32();
            Field3C = reader.ReadInt32();
            Field40 = reader.ReadInt32();
            Field44 = reader.ReadInt32();
            Field48 = reader.ReadSingle();
            Field4C = reader.ReadInt32();
            Field50 = reader.ReadInt32();
            Field54 = reader.ReadInt32();
            Field58 = reader.ReadInt32();
            Field5C = reader.ReadInt32();
            Field60 = reader.ReadSingle();
            Field64 = reader.ReadInt32();
            Field68 = reader.ReadInt32();
            Field6C = reader.ReadInt32();
            Field70 = reader.ReadInt32();
            Field74 = reader.ReadInt32();
            Field78 = reader.ReadSingle();
            Field7C = reader.ReadInt32();
            Field80 = reader.ReadInt32();
            Field84 = reader.ReadInt32();
            Field88 = reader.ReadInt32();
            Field8C = reader.ReadInt32();
            Field90 = reader.ReadSingle();
            Field94 = reader.ReadInt32();
            Field98 = reader.ReadInt32();
            Field9C = reader.ReadInt32();
            FieldA0 = reader.ReadInt32();
            FieldA4 = reader.ReadInt32();
            FieldA8 = reader.ReadSingle();
            FieldAC = reader.ReadInt32();
            FieldB0 = reader.ReadInt32();
            FieldB4 = reader.ReadInt32();
            FieldB8 = reader.ReadInt32();
            FieldBC = reader.ReadInt32();
            FieldC0 = reader.ReadSingle();
            FieldC4 = reader.ReadInt32();
            FieldC8 = reader.ReadInt32();
            FieldCC = reader.ReadInt32();
            FieldD0 = reader.ReadInt32();
            FieldD4 = reader.ReadInt32();
            FieldD8 = reader.ReadSingle();
            FieldDC = reader.ReadInt32();
            FieldE0 = reader.ReadInt32();
            FieldE4 = reader.ReadInt32();
            FieldE8 = reader.ReadInt32();
            FieldEC = reader.ReadInt32();
            FieldF0 = reader.ReadSingle();
            FieldF4 = reader.ReadInt32();
            FieldF8 = reader.ReadInt32();
            FieldFC = reader.ReadInt32();
        }

        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Field0C );
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
            writer.Write( Field60 );
            writer.Write( Field64 );
            writer.Write( Field68 );
            writer.Write( Field6C );
            writer.Write( Field70 );
            writer.Write( Field74 );
            writer.Write( Field78 );
            writer.Write( Field7C );
            writer.Write( Field80 );
            writer.Write( Field84 );
            writer.Write( Field88 );
            writer.Write( Field8C );
            writer.Write( Field90 );
            writer.Write( Field94 );
            writer.Write( Field98 );
            writer.Write( Field9C );
            writer.Write( FieldA0 );
            writer.Write( FieldA4 );
            writer.Write( FieldA8 );
            writer.Write( FieldAC );
            writer.Write( FieldB0 );
            writer.Write( FieldB4 );
            writer.Write( FieldB8 );
            writer.Write( FieldBC );
            writer.Write( FieldC0 );
            writer.Write( FieldC4 );
            writer.Write( FieldC8 );
            writer.Write( FieldCC );
            writer.Write( FieldD0 );
            writer.Write( FieldD4 );
            writer.Write( FieldD8 );
            writer.Write( FieldDC );
            writer.Write( FieldE0 );
            writer.Write( FieldE4 );
            writer.Write( FieldE8 );
            writer.Write( FieldEC );
            writer.Write( FieldF0 );
            writer.Write( FieldF4 );
            writer.Write( FieldF8 );
            writer.Write( FieldFC );
        }
    }
}
