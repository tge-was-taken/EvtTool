using EvtTool.IO;

namespace EvtTool
{
    internal class MabCommandData : CommandData
    {
        public int Animation_ID { get; set; }
        public int Field04 { get; set; }
        public int Loop_Bool { get; set; }
        public float Animation_Speed { get; set; }
        public int Field10 { get; set; }
        public int Field14 { get; set; }
        public int Field18 { get; set; }
        public float Field1C { get; set; }
        public byte Field20 { get; set; }
        public byte Field21 { get; set; }
        public short Field22 { get; set; }
        public int Field24 { get; set; }
        public int Field28 { get; set; }
        public int Field2C { get; set; }
        public int Field30 { get; set; }
        public int Field34 { get; set; }
        public int Field38 { get; set; }
        public int Field3C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Animation_ID = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Loop_Bool = reader.ReadInt32();
            Animation_Speed = reader.ReadSingle();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadInt32();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadByte();
            Field21 = reader.ReadByte();
            Field22 = reader.ReadInt16();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadInt32();
            Field2C = reader.ReadInt32();
            Field30 = reader.ReadInt32();
            Field34 = reader.ReadInt32();
            Field38 = reader.ReadInt32();
            Field3C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(Animation_ID);
            writer.Write( Field04 );
            writer.Write( Loop_Bool );
            writer.Write(Animation_Speed);
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field21 );
            writer.Write( Field22 );
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