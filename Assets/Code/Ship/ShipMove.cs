using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Code.Ship
{
    public class ShipMove : MonoBehaviour
    {
        //public CharacterController CharacterController;
        public float MovementSpeed;
        //private IInputService _inputService;
        private Camera _camera;

        private void Awake()
        {
            //_inputService = AllServices.Container.Single<IInputService>();
            _camera = Camera.main;
        }

        private void LateUpdate()
        {
            Vector3 movementVector = Vector3.zero;
            transform.Rotate(0, 10 * Time.deltaTime, 0);
            //if (_inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                //movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector = transform.TransformDirection(new Vector3(0.1f, 0, 0.1f));
                movementVector.y = 0;
                movementVector.Normalize();

                //transform.forward = movementVector;
            }

            transform.Translate(transform.forward * (MovementSpeed * Time.deltaTime));
            //movementVector += Physics.gravity;
            //CharacterController.Move(MovementSpeed * movementVector * Time.deltaTime);
        }
    }
}