using System;

namespace Game
{
    public abstract class Cell : ICell
    {
        public Cell()
        {
            Symbol = '#';
            Color = ConsoleColor.Gray;
        }

        public Cell(int left, int top)
            : this()
        {
            Left = left;
            Top = top;
        }

        public int Left { get; set; }
        public int Top { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            var cast = obj as Cell;
            if (cast == null)
            {
                return false;
            }
            return this.Left == cast.Left && this.Top == cast.Top;
        }

        public bool Equals(Cell other)
        {
            if (other == null)
            {
                return false;
            }
            return this.Left == other.Left && this.Top == other.Top;
            
        }

        public override int GetHashCode()
        {
            return new { Left, Top }.GetHashCode();
        }
    }
}
