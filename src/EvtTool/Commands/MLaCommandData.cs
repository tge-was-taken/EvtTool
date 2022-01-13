using System.Numerics;
using EvtTool.IO;

namespace EvtTool
{
    /// <summary>
    /// Model Look At. Makes a model object look at a target.
    /// </summary>
    public class MLaCommandData : CommandData
    {
        public int Field00 { get; set; }
        public int Field04 { get; set; }
        public int Field08 { get; set; }
        public Vector3 Target { get; set; }
        public int Field18 { get; set; }
        public int Field1C { get; set; }

        internal override void Read( Command command, EndianBinaryReader reader )
        {
            Field00 = reader.ReadInt32();
            Field04 = reader.ReadInt32();
            Field08 = reader.ReadInt32();
            Target = reader.ReadVector3();
            Field18 = reader.ReadInt32();
            Field1C = reader.ReadInt32();
        }


        internal override void Write( Command command, EndianBinaryWriter writer )
        {
            writer.Write( Field00 );
            writer.Write( Field04 );
            writer.Write( Field08 );
            writer.Write( Target );
            writer.Write( Field18 );
            writer.Write( Field1C );
        }
    }

    public enum LookAtInterpolationMode
    {
        None,
        Smooth1,
        Smooth2,
        Smooth3
    }
}