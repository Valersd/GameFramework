using System;
using System.Linq;

namespace Game
{
    public class Painter : IPainter
    {
        protected readonly IGameContext _gameContext;
        protected int _firstInfoRow;
        public Painter(IGameContext gameContext)
        {
            _gameContext = gameContext;
            _firstInfoRow = GetFirstInfoRow();
        }

        public virtual void Draw()
        {
            foreach (var cell in _gameContext.RecycleBin)
            {
                Console.SetCursorPosition(cell.Left, cell.Top);
                Console.Write(' ');
            }
            _gameContext.RecycleBin.Clear();
            foreach (var item in _gameContext.GameObjects)
            {
                if (item.BePainted)
                {
                    foreach (var cell in item.Body)
                    {
                        Console.ForegroundColor = cell.Color;
                        Console.SetCursorPosition(cell.Left, cell.Top);
                        Console.Write(cell.Symbol);
                    }
                }
            }
            int row = _firstInfoRow;
            foreach (var info in _gameContext.InfoObjects)
            {
                Console.SetCursorPosition(GetPosition(info), row);
                Console.ForegroundColor = info.Color;
                Console.WriteLine(info);
                row += 2;
            }
        }

        protected int GetFirstInfoRow()
        {
            int infosCount = _gameContext.InfoObjects.Count();
            int rowsNeededForInfos = infosCount * 2;
            return _gameContext.Height / 2 - rowsNeededForInfos / 2;
        }

        protected int GetPosition(IInfo info)
        {
            return _gameContext.PlayWidth + (_gameContext.InfoWidth / 2 - info.ToString().Length / 2);
        }
    }
}
