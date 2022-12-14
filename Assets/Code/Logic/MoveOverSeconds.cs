using System.Collections;
using UnityEngine;

namespace Code.Logic
{
    public class MoveOverSeconds
    {
        public static IEnumerator Move(GameObject source, Vector3 end, float seconds)
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

        public static IEnumerator Move(GameObject source, GameObject target, float seconds)
        {
            float elapsedTime = 0;
            Vector3 startingPos = source.transform.position;
            while (elapsedTime < seconds)
            {
                source.transform.position = Vector3.Lerp(startingPos, target.transform.position, (elapsedTime / seconds*2));
                elapsedTime += Time.deltaTime;
                //Debug.Log($"{elapsedTime} {seconds}");
                yield return new WaitForEndOfFrame();
            }
            source.transform.position = target.transform.position;
        }
    }
}