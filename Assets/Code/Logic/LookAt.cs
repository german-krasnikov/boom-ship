using UnityEngine;

namespace Code.Logic
{
    public class LookAt : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;
        [SerializeField]
        private Vector3 _offSet;

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Euler(_offSet) * Quaternion.LookRotation(_target.transform.position - transform.position);
        }
    }
}