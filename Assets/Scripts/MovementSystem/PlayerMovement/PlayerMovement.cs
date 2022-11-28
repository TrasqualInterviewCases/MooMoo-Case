using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MovementBase
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public override void PerformMovement(Vector3 movementVector, Vector3 lookVector)
    {
        if (!CanMove()) return;
        Move(movementVector);
        Rotate(lookVector);
    }

    public override void Move(Vector3 movementVector)
    {
        controller.Move(transform.TransformDirection(movementSpeed * Time.deltaTime * movementVector.normalized));
        ApplyGravity();
    }

    public override void Rotate(Vector3 lookVector)
    {
        if (lookVector != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookVector.normalized), rotationSpeed * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (controller.isGrounded)
        {
            controller.Move(new Vector3(0f, -0.5f, 0f));
        }
        else
        {
            controller.Move(new Vector3(0f, -10f, 0f));
        }
    }
}
