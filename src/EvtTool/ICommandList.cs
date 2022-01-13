using System.Collections.Generic;

namespace EvtTool
{
    public interface ICommandList
    {
        List<Command> Commands { get; }
    }
}