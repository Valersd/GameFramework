using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Game
{
    public abstract class GameContext : IGameContext
    {
        protected List<IGameObject> _gameObjects;
        protected SortedSet<IInfo> _infoObjects;
        public GameContext(IConfigurationDataProvider dataProvider, params IGameObject[] gameObjects)
        {
            Width = int.Parse(dataProvider.Get("width"));
            Height = int.Parse(dataProvider.Get("height"));
            PlayWidth = int.Parse(dataProvider.Get("playWidth"));
            InfoWidth = Width - PlayWidth;
            Points = 0;
            InitializeGameField();
            _gameObjects = new List<IGameObject>(gameObjects);
            Used = new HashSet<ICell>();
            RecycleBin = new HashSet<ICell>();
            _infoObjects = new SortedSet<IInfo>();
            RegisterAllInfos(gameObjects);
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.Unicode; //Encoding.GetEncoding(1252);
        }
        public int Width { get; protected set; }

        public int Height { get; protected set; }

        public int PlayWidth { get; protected set; }

        public int InfoWidth { get; protected set; }

        public int Points { get; set; }

        public IEnumerable<IGameObject> GameObjects { get { return _gameObjects; } }
        public IEnumerable<IInfo> InfoObjects { get { return _infoObjects; } }
        public HashSet<ICell> Used { get; protected set; }
        public HashSet<ICell> RecycleBin { get; protected set; }

        public virtual void Add(IGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        public virtual void Remove(IGameObject gameObject)
        {
            Used.RemoveWhere(c => gameObject.Body.Contains(c));
            RecycleBin.UnionWith(gameObject.Body);
            _gameObjects.Remove(gameObject);
        }

        public virtual bool ValidatePosition(ICell cell)
        {
            return cell.Left >= 0 && cell.Left < PlayWidth
                && cell.Top >= 0 && cell.Top < Height;
        }

        public virtual void Clear()
        {
            Used.Clear();
        }

        protected void InitializeGameField()
        {
            Console.WindowHeight = Console.BufferHeight = Height;
            Console.WindowWidth = Console.BufferWidth = Width;
            Console.CursorVisible = false;
        }

        protected void RegisterInfo(IEnumerable<IInfo> info)
        {
            _infoObjects.UnionWith(info);
        }

        protected void RegisterAllInfos(IEnumerable<IGameObject> gameObjects)
        {
            foreach (var obj in gameObjects)
            {
                RegisterInfo(obj.Info);
            }
        }
    }
}
