using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    [JsonObject( ItemRequired = Required.Always )]
    public sealed class LsdList : IList<LsdListEntry>
    {
        private const int FIELD0C_VALUE = -1;
        private const int FIELD10_VALUE = 0;
        private const int FIELD14_VALUE = 0;
        private const int HEADER_SIZE = 0x18;

        public int Field04 { get; set; }

        public List<LsdListEntry> Entries { get; set; }

        public LsdList()
        {
            Entries = new List<LsdListEntry>();
        }

        internal void Read( EndianBinaryReader reader )
        {
            var entryCount = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            var size = reader.ReadInt32();
            var field0C = reader.ReadInt32();
            var field10 = reader.ReadInt32();
            var field14 = reader.ReadInt32();

            Trace.Assert( field0C == FIELD0C_VALUE, $"field0C != {FIELD0C_VALUE}" );
            Trace.Assert( field10 == FIELD10_VALUE, $"field10 != {FIELD10_VALUE}" );
            Trace.Assert( field14 == FIELD14_VALUE, $"field14 != {FIELD14_VALUE}" );

            Entries.Capacity = entryCount;
            for ( int i = 0; i < entryCount; i++ )
            {
                var entry = new LsdListEntry();
                entry.Read( reader );
                Entries.Add( entry );
            }
        }

        internal void Write( EndianBinaryWriter writer )
        {
            int size = HEADER_SIZE + ( Entries.Count * LsdListEntry.SIZE );
            writer.Write( Entries.Count );
            writer.Write( Field04 );
            writer.Write( size );
            writer.Write( FIELD0C_VALUE );
            writer.Write( FIELD10_VALUE );
            writer.Write( FIELD14_VALUE );
            Entries.ForEach( x => x.Write( writer ) );
        }

        #region IList implementation

        [JsonIgnore]
        public int Count => ( ( IList<LsdListEntry> )Entries ).Count;

        [JsonIgnore]
        public bool IsReadOnly => ( ( IList<LsdListEntry> )Entries ).IsReadOnly;

        public LsdListEntry this[int index] { get => ( ( IList<LsdListEntry> )Entries )[index]; set => ( ( IList<LsdListEntry> )Entries )[index] = value; }

        public int IndexOf( LsdListEntry item )
        {
            return ( ( IList<LsdListEntry> )Entries ).IndexOf( item );
        }

        public void Insert( int index, LsdListEntry item )
        {
            ( ( IList<LsdListEntry> )Entries ).Insert( index, item );
        }

        public void RemoveAt( int index )
        {
            ( ( IList<LsdListEntry> )Entries ).RemoveAt( index );
        }

        public void Add( LsdListEntry item )
        {
            ( ( IList<LsdListEntry> )Entries ).Add( item );
        }

        public void Clear()
        {
            ( ( IList<LsdListEntry> )Entries ).Clear();
        }

        public bool Contains( LsdListEntry item )
        {
            return ( ( IList<LsdListEntry> )Entries ).Contains( item );
        }

        public void CopyTo( LsdListEntry[] array, int arrayIndex )
        {
            ( ( IList<LsdListEntry> )Entries ).CopyTo( array, arrayIndex );
        }

        public bool Remove( LsdListEntry item )
        {
            return ( ( IList<LsdListEntry> )Entries ).Remove( item );
        }

        public IEnumerator<LsdListEntry> GetEnumerator()
        {
            return ( ( IList<LsdListEntry> )Entries ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ( ( IList<LsdListEntry> )Entries ).GetEnumerator();
        }

        #endregion
    }
}