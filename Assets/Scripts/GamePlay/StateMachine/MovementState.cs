using Main.GamePlay.AnimationSystem;
using Main.GamePlay.InputSystem;
using Main.GamePlay.MovementSystem;
using UnityEngine;

namespace Main.GamePlay.StateMachineSystem
{
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
            _anim.PlayMovementAnim(Vector3.zero);
        }
    }
}