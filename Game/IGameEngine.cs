using System;

namespace Game
{
    public interface IGameEngine
    {
        int GameSpeed { get; }
        int SlowFactor { get; }
        IGameEvent CurrentEvent { get; }
        IPainter Painter { get; }
        void StartGame();
        void ProceedCommand(ConsoleKey input);
        void Run();
    }
}
