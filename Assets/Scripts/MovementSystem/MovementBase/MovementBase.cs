using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    private bool canMove = true;

    public abstract void PerformMovement(Vector3 movementVector, Vector3 lookVector);
    public abstract void Move(Vector3 movementVector);
    public abstract void Rotate(Vector3 lookVector);
    public bool CanMove() => canMove;

    public void StartMovement()
    {
        canMove = true;
    }

    public void StopMovement()
    {
        canMove=false;
    }
}
