using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject CreateBullet(GameObject at);
        void CreateHud();
    }
}