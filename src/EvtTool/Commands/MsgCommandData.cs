using EvtTool.IO;

namespace EvtTool
{
    public class MsgCommandData : CommandData
    {
        public MessageBitfield MessageMode { get; set; }
        public short MessageMajorId { get; set; }
        public byte MessageMinorId { get; set; }
        public byte MessageSubId { get; set; }
        public short SelectMajorId { get; set; }
        public byte SelectMinorId { get; set; }
        public byte SelectSubId { get; set; }
        public int EvtLocalDataIdSelStorage  { get; set; }
        public int Field10 { get; set; }
        public float Field14 { get; set; }
        public float Field18 { get; set; }
        public float Field1C { get; set; }
        public short Field20 { get; set; }
        public short Field22 { get; set; }
        public int Field24 { get; set; }
        public float Field28 { get; set; }
        public int Field2C { get; set; }

        public struct Entry
        {
            public short Unknown1 { get; set; }
            public short Unknown2 { get; set; }
            public float Unknown3 { get; set; }

            public override string ToString()
            {
                return $"{Unknown1} {Unknown2} {Unknown3}";
            }
        }

        public int numOfEntries;
        public Entry[] Entries { get; set; } = new Entry[16];

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            MessageMode = new MessageBitfield();
            {
                MessageMode.data = reader.ReadInt32();
            };
            MessageMajorId = reader.ReadInt16();
            MessageMinorId = reader.ReadByte();
            MessageSubId = reader.ReadByte();
            SelectMajorId = reader.ReadInt16();
            SelectMinorId = reader.ReadByte();
            SelectSubId = reader.ReadByte();
            EvtLocalDataIdSelStorage  = reader.ReadInt32();
            Field10 = reader.ReadInt32();
            Field14 = reader.ReadSingle();
            Field18 = reader.ReadSingle();
            Field1C = reader.ReadSingle();
            Field20 = reader.ReadInt16();
            Field22 = reader.ReadInt16();
            Field24 = reader.ReadInt32();
            Field28 = reader.ReadSingle();
            Field2C = reader.ReadInt32();

            int numOfEntries = 14;
            if (command.DataSize == 0xB0)
            {
                numOfEntries = 16;
            }
            else numOfEntries = 14;

            for ( int i = 0; i < numOfEntries; i++ )
            {
                Entries[ i ].Unknown1 = reader.ReadInt16();
                Entries[i].Unknown2 = reader.ReadInt16();
                Entries[i].Unknown3 = reader.ReadSingle();
            }
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write(MessageMode.data);
            writer.Write( MessageMajorId );
            writer.Write( MessageMinorId );
            writer.Write( MessageSubId );
            writer.Write( SelectMajorId );
            writer.Write( SelectMinorId );
            writer.Write( SelectSubId );
            writer.Write( EvtLocalDataIdSelStorage  );
            writer.Write( Field10 );
            writer.Write( Field14 );
            writer.Write( Field18 );
            writer.Write( Field1C );
            writer.Write( Field20 );
            writer.Write( Field22 );
            writer.Write( Field24 );
            writer.Write( Field28 );
            writer.Write( Field2C );

            int numOfEntries = 14;
            if (command.DataSize == 0xB0)
            {
                numOfEntries = 16;
            }
            else numOfEntries = 14;

            for ( int i = 0; i < numOfEntries; i++ )
            {
                writer.Write( Entries[ i ].Unknown1 );
                writer.Write( Entries[i].Unknown2 );
                writer.Write( Entries[i].Unknown3 );
            }
        }

        public class MessageBitfield
        {
            internal int data { get; set; }

            public bool HasMessage
            {
                get { return (data & 1) == 1; }
                set { data += (value ? 1 : 0); }
            }

            public bool HasSelect
            {
                get { return (data & 2) == 2; }
                set { data += (value ? 1 : 0) << 1; }
            }

            public bool IsSubtitle
            {
                get { return (data & 4) == 4; }
                set { data += (value ? 1 : 0) << 2; }
            }
        }
    }
}