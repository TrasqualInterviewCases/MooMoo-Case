using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MovementBase
{
    [SerializeField] private InputBase input;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!CanMove()) return;
        Move();
        Rotate();
    }

    public override void Move()
    {
        controller.Move(transform.TransformDirection(movementSpeed * Time.deltaTime * input.GetMovementInput().normalized));
    }

    public override void Rotate()
    {
        if (input.GetLookInput() != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input.GetLookInput().normalized), rotationSpeed * Time.deltaTime);
    }
}
