using System.Collections.Generic;
using Code.Infrastructure;

namespace Code.Ship
{
    public interface IShipService : IService
    {
        void Tick(float tick, Ship ship, List<Ship> enemies);
    }
}