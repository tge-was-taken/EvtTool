using System.Text;
using EvtTool.IO;
using EvtTool.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EvtTool
{
    [JsonConverter(typeof( CommandJsonConverter ) )]
    public sealed class Command
    {
        internal const int SIZE = 0x30;

        public string Type { get; set; }

        public int Field04 { get; set; }

        public int Field06 { get; set; }

        public int ObjectId { get; set; }

        public int Field0C { get; set; }

        public int Frame { get; set; }

        public int Duration { get; set; }

        public int DataSize { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public evtFlagType EvtFlagType { get; set; }

        public uint EvtFlagId { get; set; }

        public int EvtFlagValue { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public evtFlagConditionalType EvtFlagConditionalType { get; set; }

        [JsonConverter(typeof( DontDeserializeJsonConverter ) )]
        public CommandData Data { get; set; }

        internal void Read( EndianBinaryReader reader )
        {
            Type = Encoding.ASCII.GetString( reader.ReadBytes( 4 ) );
            Field04 = reader.ReadInt16();
            Field06 = reader.ReadInt16();
            ObjectId = reader.ReadInt32();
            Field0C = reader.ReadInt32();
            Frame = reader.ReadInt32();
            Duration = reader.ReadInt32();
            var dataOffset = reader.ReadInt32();
            DataSize = reader.ReadInt32();
            EvtFlagType = (evtFlagType)reader.ReadInt32();
            EvtFlagId = reader.ReadUInt32(); FlagConvert();
            EvtFlagValue = reader.ReadInt32();
            EvtFlagConditionalType = (evtFlagConditionalType)reader.ReadInt32();

            reader.ReadAtOffset( dataOffset, () =>
            {
                Data = CommandDataFactory.Create( Type );
                Data.Read( this, reader );
            });
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Write( Encoding.ASCII.GetBytes( Type ) );
            writer.Write( (short)Field04 );
            writer.Write( (short)Field06 );
            writer.Write( ObjectId );
            writer.Write( Field0C );
            writer.Write( Frame );
            writer.Write( Duration );
            writer.ScheduleOffsetWrite( () => Data.Write( this, writer ) );
            writer.Write( DataSize );
            writer.Write( (int)EvtFlagType );
            writer.Write(EvtFlagId);
            writer.Write(EvtFlagValue);
            writer.Write( (int)EvtFlagConditionalType );
        }

        public enum evtFlagType
        {
            None = 0,
            Adachi_False = 1,
            Evt_Local_Data = 2,
            Bitflag = 3,
            Count = 4
        }

        public enum evtFlagConditionalType
        { 
            FlagValue_Equals_FlagIdResult = 0,
            FlagValue_DoesNotEqual_FlagIdResult = 1,
            FlagValue_IsLessThan_FlagIdResult = 2,
            FlagValue_IsMoreThan_FlagIdResult = 3,
            FlagValue_IsLessThanEqualTo_FlagIdResult = 4,
            FlagValue_IsMoreThanEqualTo_FlagIdResult = 5,
        }

        public void FlagConvert()
        {
            if (EvtFlagType == evtFlagType.Bitflag)
            {
                if (EvtFlagId  >= 0x5000000)
                { EvtFlagId = (EvtFlagId - 0x5000000) + 12288; }

                else if (EvtFlagId >= 0x4000000)
                { EvtFlagId = (EvtFlagId - 0x4000000) + 11776; }

                else if (EvtFlagId >= 0x3000000)
                { EvtFlagId = (EvtFlagId - 0x3000000) + 11264; }

                else if (EvtFlagId >= 0x2000000)
                { EvtFlagId = (EvtFlagId - 0x2000000) + 6144; }

                else if (EvtFlagId >= 0x1000000)
                { EvtFlagId = (EvtFlagId - 0x1000000) + 3072; }
            }
        }
    }
}