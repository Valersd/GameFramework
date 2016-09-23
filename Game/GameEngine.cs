using System;

namespace Game
{
    public abstract class GameEngine : IGameEngine
    {
        protected readonly IGameContext _gameContext;
        protected readonly IGameEventFactory _eventFactory;
        public GameEngine(IGameContext gameContext, IPainter painter, IGameEventFactory eventFactory)
        {
            _gameContext = gameContext;
            Painter = painter;
            _eventFactory = eventFactory;
            CurrentEvent = _eventFactory.Create("Start", _gameContext);
        }
        public abstract int GameSpeed { get; protected set; }
        public abstract int SlowFactor { get; protected set; }
        public virtual IGameEvent CurrentEvent { get; set; }
        public IPainter Painter { get; protected set; }

        public abstract void StartGame();

        public abstract void ProceedCommand(ConsoleKey input);

        public abstract void Run();
    }
}
