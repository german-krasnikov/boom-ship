﻿using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider _assetProvider;

    public GameFactory(IAssetProvider assetProvider)
    {
      _assetProvider = assetProvider;
    }

    public GameObject CreateBullet(GameObject at) => 
      _assetProvider.Instantiate(AssetPath.BulletPath, at: at.transform.position);

    public void CreateHud() =>
      _assetProvider.Instantiate(AssetPath.HudPath);
  }
}