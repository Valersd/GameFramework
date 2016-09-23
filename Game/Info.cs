using System;

namespace Game
{
    public class Info : IInfo, IComparable
    {
        protected string _message;
        protected int _priority;
        protected double _parameter;
        protected ConsoleColor _color;

        public Info(string message, int priority, ConsoleColor color)
        {
            _message = message;
            _priority = priority;
            _color = color;
        }

        public Info(string message, int priority, ConsoleColor color, double parameter, bool roundToInteger)
            : this(message, priority, color)
        {
            _parameter = parameter;
            RoundToInteger = roundToInteger;
        }

        public string Message { get { return _message; } }

        public int Priority { get { return _priority; } }

        public ConsoleColor Color { get { return _color; } set { _color = value; } }

        public bool RoundToInteger { get; set; }

        public double Parameter
        {
            get { return _parameter; }
            set { _parameter = value; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            var other = obj as IInfo;
            if (other != null)
            {
                return this.Priority.CompareTo(other.Priority);
            }
            else throw new ArgumentException("Object is not an Info");
        }

        public override string ToString()
        {
            if (RoundToInteger)
            {
                return String.Format("   {0}: {1:00}   ", Message, Parameter);
            }
            else
            {
                return String.Format("   {0}: {1:00.00}   ", Message, Parameter);
            }
        }
    }
}
