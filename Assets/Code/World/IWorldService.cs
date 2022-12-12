using Code.Infrastructure;

namespace Code.World
{
    public interface IWorldService : IService
    {
        World World { get; }
        void Clear();
    }
}