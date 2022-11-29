using UnityEngine;

namespace Main.GamePlay.MovementSystem
{
    public class PlayerSingleJoystickMovement : PlayerMovementBase
    {
        public override void Move(Vector3 movementVector)
        {
            controller.Move(movementSpeed * movementVector.magnitude * Time.deltaTime * transform.forward);
            ApplyGravity();
        }

        public override void Rotate(Vector3 lookVector)
        {
            if (lookVector != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector.normalized), rotationSpeed * Time.deltaTime);
        }
    }
}