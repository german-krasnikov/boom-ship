using UnityEngine;

namespace Code.Logic
{
    public static class GameObjectHelper
    {
        public static T As<T>(this GameObject gameObject) => gameObject.GetComponent<T>();
    }
}