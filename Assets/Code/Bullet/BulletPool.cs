using Code.Infrastructure.AssetManagement;
using Code.Logic;
using UnityEngine;

namespace Code.Bullet
{
    public class BulletPool : PoolHelper<BulletUI>
    {
        private IAssetProvider _assetProvider;

        public BulletPool(IAssetProvider assetProvider) : base(30, true)
        {
            _assetProvider = assetProvider;
        }

        public override void OnDestroyPoolObject(BulletUI it)
        {
            _assetProvider.Destroy(it.gameObject);
        }

        public override void OnReturnedToPool(BulletUI it)
        {
            it.gameObject.SetActive(false);
        }

        public override void OnTakeFromPool(BulletUI it)
        {
            it.gameObject.SetActive(true);
        }

        public override BulletUI CreatePooledItem()
        {
            return _assetProvider.Instantiate(AssetPath.BulletPath).GetComponent<BulletUI>();
        }

        public BulletUI Get(Vector3 position)
        {
            var result = Pool.Get();
            result.transform.position = position;
            return result;
        }
    }
}