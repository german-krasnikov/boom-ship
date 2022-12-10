using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateBullet(GameObject at);
        void CreateHud();
    }
}