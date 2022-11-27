using UnityEngine;

public abstract class MovementBase : MonoBehaviour
{
    private bool canMove = true;

    public abstract void Move();
    public abstract void Rotate();
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
