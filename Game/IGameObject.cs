using System;
using System.Collections.Generic;

namespace Game
{
    public interface IGameObject
    {
        IGameEvent CurrentEvent { get; set; }
        IEnumerable<ICell> Body { get; }
        IEnumerable<IInfo> Info { get; }
        bool BePainted { get; set; }
        void Execute(IGameEvent gameEvent);
        void Add(ICell cell);
        void Remove(ICell cell);
    }
}
