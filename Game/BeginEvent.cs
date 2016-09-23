
using System;

namespace Game
{
    public class BeginEvent : GameEvent, IGameEvent, IComparable
    {
        public BeginEvent(IGameContext gameContext)
            :base(gameContext)
        {
            GameContext = gameContext;
        }

        public override int Priority { get { return 100; } }

        //public override IGameEvent ExecuteCurrentEvent(IGameObject gameObject)
        //{
        //    return gameObject.BeginEventHandle(this);
        //}

    }
}
