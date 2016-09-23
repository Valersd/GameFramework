using System;

namespace Game
{
    public interface ICell
    {
        int Left { get; set; }
        int Top { get; set; }
        char Symbol { get; set; }
        ConsoleColor Color { get; set; }
    }
}
