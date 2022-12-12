using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Ship
{
    public class ShipMove : MonoBehaviour
    {
        public Vector3 TargetPosition;
        public float Speed = 2;
        public float RotationSpeed = 20;

        private void Awake()
        {
            CreateNewTarget();
        }

        private void LateUpdate()
        {
            MoveToTarget();
            RotateToTarget();
            if (RichTarget())
                CreateNewTarget();
        }

        private void CreateNewTarget()
        {
            TargetPosition = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 10));
        }

        private bool RichTarget() => Vector3.Distance(TargetPosition, transform.position) < 0.1f;

        private void MoveToTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
        }

        private void RotateToTarget()
        {
            Vector3 dir = TargetPosition - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }
}