using System.Collections;
using UnityEngine;

namespace Code.Module.Weapon
{
    public class BulletUI : MonoBehaviour
    {
        public Bullet Bullet;

        public void Initialize(Bullet bullet)
        {
            Bullet = bullet;
        }

        public void Tick(float tick)
        {
            if (Bullet == null)
                return;
        }

        public IEnumerator MoveOverSeconds(GameObject source, Vector3 end, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingPos = source.transform.position;
            while (elapsedTime < seconds)
            {
                source.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            source.transform.position = end;
        }

        public IEnumerator MoveOverSeconds(GameObject source, GameObject target, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingPos = source.transform.position;
            while (elapsedTime < seconds)
            {
                source.transform.position = Vector3.Lerp(startingPos, target.transform.position, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            source.transform.position = target.transform.position;
        }
    }
}