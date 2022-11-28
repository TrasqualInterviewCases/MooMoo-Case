
public class MovementState : StateBase
{
    private readonly MovementBase _movement;

    public MovementState(AnimationBase anim, InputBase input, MovementBase movement) : base(anim, input)
    {
        _movement = movement;
    }

    public override void EnterState()
    {
        _movement.StartMovement();
    }

    public override void UpdateState()
    {
        _movement.PerformMovement(_input.GetMovementInput(), _input.GetLookInput());
        _anim.PlayMovementAnim(_input.GetMovementInput());
    }

    public override void ExitState()
    {
        _movement.StopMovement();
    }
}
