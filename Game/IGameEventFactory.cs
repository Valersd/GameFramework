
namespace Game
{
    public interface IGameEventFactory
    {
        IGameEvent Create(string eventName, IGameContext gameContext);
    }
}
