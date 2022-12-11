using Code.Infrastructure;

namespace Code.World
{
    public class WorldService : IWorldService
    {
        public World World { get; }

        public WorldService()
        {
            World = new World();
        }
    }
}