using UnityEngine;

namespace Code.World
{
    public class WorldService : IWorldService
    {
        public World World { get; }

        public WorldService()
        {
            World = new World();
        }

        public void Clear()
        {
           Object.Destroy(World.Ship.UI.gameObject); 
            World.Ship = null;
            foreach (var it in World.Enemies)
                Object.Destroy(it.UI.gameObject); 
            foreach (var it in World.Bullets)
                Object.Destroy(it.UI.gameObject); 
            World.Bullets.Clear();
            World.Enemies.Clear();
        }
    }
}