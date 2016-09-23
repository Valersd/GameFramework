using System;

namespace Game
{
    public interface IInfo : IComparable
    {
        string Message { get; }
        double Parameter { get; set; }
        int Priority { get; }
        ConsoleColor Color { get; set; }
        bool RoundToInteger { get; }
    }
}
