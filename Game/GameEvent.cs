
using System;

namespace Game
{
    public abstract class GameEvent : IGameEvent
    {
        public GameEvent(IGameContext gameContext)
        {
            GameContext = gameContext;
            Name = GetType().Name;
        }

        public abstract int Priority { get; }

        public virtual string Name { get; protected set; }

        public virtual IGameContext GameContext { get; protected set; }

        public virtual ConsoleKey UserInput { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            var other = obj as IGameEvent;
            if (other != null)
            {
                return this.Priority.CompareTo(other.Priority);
            }
            else throw new ArgumentException("Object is not a GameEvent");
        }
    }
}
