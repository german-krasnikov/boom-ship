using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssets _assets;

    public GameFactory(IAssets assets)
    {
      _assets = assets;
    }

    public GameObject CreateBullet(GameObject at) => 
      _assets.Instantiate(AssetPath.BulletPath, at: at.transform.position);

    public void CreateHud() =>
      _assets.Instantiate(AssetPath.HudPath);
  }
}