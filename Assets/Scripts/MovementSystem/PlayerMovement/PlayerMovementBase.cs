using UnityEngine;

public class PlayerMovementBase : MovementBase
{
    [SerializeField] protected float movementSpeed = 5f;
    [SerializeField] protected float rotationSpeed = 5f;

    protected CharacterController controller;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public override void PerformMovement(Vector3 movementVector, Vector3 lookVector)
    {
        if (!CanMove()) return;
        Move(movementVector);
        Rotate(lookVector);
    }

    public override void Move(Vector3 movementVector) { }

    public override void Rotate(Vector3 lookVector) { }

    protected void ApplyGravity()
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
