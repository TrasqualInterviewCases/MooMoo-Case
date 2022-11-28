using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerDoubleJoystickMovement : PlayerMovementBase
{
    public override void Move(Vector3 movementVector)
    {
        controller.Move(transform.TransformDirection(movementSpeed * Time.deltaTime * movementVector.normalized));
    }

    public override void Rotate(Vector3 lookVector)
    {
        if (lookVector != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector.normalized), rotationSpeed * Time.deltaTime);
    }
}
