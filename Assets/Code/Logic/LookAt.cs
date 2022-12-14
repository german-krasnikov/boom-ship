using UnityEngine;

namespace Code.Logic
{
    public class LookAt : MonoBehaviour
    {
        [HideInInspector]
        public Transform Target;
        [SerializeField]
        private Vector3 _offSet;

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Euler(_offSet) * Quaternion.LookRotation(Target.transform.position - transform.position);
        }
    }
}