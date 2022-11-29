using UnityEngine;

namespace Main.GamePlay.MovementSystem
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerDoubleJoystickMovement : PlayerMovementBase
    {
        [SerializeField] Transform cameraTarget;
        [SerializeField] float lookSensitivity = 5f;
        float xRot;
        float yRot;

        public override void PerformMovement(Vector3 movementVector, Vector3 lookVector)
        {
            Move(movementVector);
            Rotate(lookVector);
        }

        public override void Move(Vector3 movementVector)
        {
            controller.Move(movementSpeed * movementVector.normalized.magnitude * Time.deltaTime * transform.forward);
            if (movementVector != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementVector), Time.deltaTime * rotationSpeed);
        }

        public override void Rotate(Vector3 lookVector)
        {
            xRot += lookVector.x * Time.deltaTime * lookSensitivity;
            yRot += lookVector.z * Time.deltaTime * lookSensitivity;

            yRot = ClampAngle(yRot, -30, 70);

            cameraTarget.rotation = Quaternion.Euler(yRot, xRot, 0f);
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360f) angle += 360f;
            if (angle > 360f) angle -= 360f;
            return Mathf.Clamp(angle, min, max);
        } 
    }
}
