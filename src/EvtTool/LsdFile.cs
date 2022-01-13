using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using EvtTool.IO;
using Newtonsoft.Json;

namespace EvtTool
{
    [JsonObject( ItemRequired = Required.Always )]
    public sealed class LsdFile : ISaveable, IList<LsdList>
    {
        private const int FIELD00_VALUE = 0;
        private const int MAGIC = 0x4C534400;

        public List<LsdList> Lists { get; set; }

        public LsdFile()
        {
            Lists = new List<LsdList>();
        }

        public LsdFile( string path ) : this()
        {
            using ( var stream = File.OpenRead( path ) )
                Read( new EndianBinaryReader( stream, Endianness.Big ) );
        }

        public LsdFile( List<LsdList> lists )
        {
            Lists = lists;
        }

        public void Save( string path )
        {
            using ( var stream = FileHelper.Create( path ) )
                Write( new EndianBinaryWriter( stream, Endianness.Big) );
        }

        internal void Read( EndianBinaryReader reader )
        {
            var field00 = reader.ReadInt32();
            var magic = reader.ReadInt32();
            var listCount = reader.ReadInt32();

            Trace.Assert( field00 == FIELD00_VALUE, $"field00 != {FIELD00_VALUE}" );

            if ( magic != MAGIC )
                throw new InvalidDataException( "Magic value does not match" );

            var listOffsets = reader.ReadInt32s( listCount );
            for ( int i = 0; i < listOffsets.Length; i++ )
            {
                reader.SeekBegin( listOffsets[i] );
                var list = new LsdList();
                list.Read( reader );
                Lists.Add( list );
            }
        }

        internal void Write( EndianBinaryWriter writer )
        {
            writer.Write( FIELD00_VALUE );
            writer.Write( MAGIC );
            writer.Write( Lists.Count );
            Lists.ForEach( x => writer.ScheduleOffsetWrite( () => x.Write( writer ) ) );
            writer.PerformScheduledWrites();
        }

        #region IList implementation

        [JsonIgnore]
        public int Count => ( ( IList<LsdList> )Lists ).Count;

        [JsonIgnore]
        public bool IsReadOnly => ( ( IList<LsdList> )Lists ).IsReadOnly;

        public LsdList this[int index] { get => ( ( IList<LsdList> )Lists )[index]; set => ( ( IList<LsdList> )Lists )[index] = value; }

        public int IndexOf( LsdList item )
        {
            return ( ( IList<LsdList> )Lists ).IndexOf( item );
        }

        public void Insert( int index, LsdList item )
        {
            ( ( IList<LsdList> )Lists ).Insert( index, item );
        }

        public void RemoveAt( int index )
        {
            ( ( IList<LsdList> )Lists ).RemoveAt( index );
        }

        public void Add( LsdList item )
        {
            ( ( IList<LsdList> )Lists ).Add( item );
        }

        public void Clear()
        {
            ( ( IList<LsdList> )Lists ).Clear();
        }

        public bool Contains( LsdList item )
        {
            return ( ( IList<LsdList> )Lists ).Contains( item );
        }

        public void CopyTo( LsdList[] array, int arrayIndex )
        {
            ( ( IList<LsdList> )Lists ).CopyTo( array, arrayIndex );
        }

        public bool Remove( LsdList item )
        {
            return ( ( IList<LsdList> )Lists ).Remove( item );
        }

        public IEnumerator<LsdList> GetEnumerator()
        {
            return ( ( IList<LsdList> )Lists ).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ( ( IList<LsdList> )Lists ).GetEnumerator();
        }

        #endregion
    }
}