

namespace Game
{
    public interface ICellFactory
    {
        ICell Create(string name, int left, int top);
    }
}
