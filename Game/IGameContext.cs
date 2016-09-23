using System;
using System.Collections.Generic;

namespace Game
{
    public interface IGameContext
    {
        int Width { get; }
        int Height { get; }
        int PlayWidth { get; }
        int InfoWidth { get; }
        int Points { get; set; }

        IEnumerable<IGameObject> GameObjects { get; }
        IEnumerable<IInfo> InfoObjects { get; }
        HashSet<ICell> Used { get; }
        HashSet<ICell> RecycleBin { get; }

        void Add(IGameObject gameObject);
        void Remove(IGameObject gameObject);
        bool ValidatePosition(ICell cell);
        void Clear();
    }
}
