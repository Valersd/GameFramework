
using System;

namespace Game
{
    public interface IGameEvent : IComparable
    {
        string Name { get; }
        int Priority { get; }
        IGameContext GameContext { get; }
        ConsoleKey UserInput { get; set; }
    }
}
