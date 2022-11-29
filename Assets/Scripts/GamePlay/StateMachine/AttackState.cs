using Main.GamePlay.AnimationSystem;
using Main.GamePlay.InputSystem;
using Main.GamePlay.MovementSystem;
using UnityEngine;

namespace Main.GamePlay.StateMachineSystem
{
    public class AttackState : StateBase
    {
        private readonly MovementBase _movement;

        public AttackState(AnimationBase anim, InputBase input, MovementBase movement) : base(anim, input)
        {
            _movement = movement;
        }

        public override void EnterState()
        {
            _movement.StopMovement();
            _anim.PlayAttackAnim();
        }

        public override void UpdateState()
        {

        }

        public override void ExitState()
        {
            _anim.PlayMovementAnim(Vector3.zero);
        }
    }
}