using EvtTool.IO;

namespace EvtTool
{
    public abstract class CommandData
    {
        internal abstract void Read( Command command, EndianBinaryReader reader );

        internal abstract void Write( Command command, EndianBinaryWriter writer );
    }
}