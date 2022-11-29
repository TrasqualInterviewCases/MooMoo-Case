using Main.GamePlay.AnimationSystem;
using Main.GamePlay.InputSystem;
using Main.GamePlay.MovementSystem;
using UnityEngine;

namespace Main.GamePlay.StateMachineSystem
{
    public class StateMachine : MonoBehaviour
    {
        private AnimationBase anim;
        private InputBase input;
        private MovementBase movement;

        //States
        public MovementState MovementState { get; private set; }
        public AttackState AttackState { get; private set; }

        private StateBase currentState;

        private void Awake()
        {
            anim = GetComponent<AnimationBase>();
            input = GetComponent<InputBase>();
            movement = GetComponent<MovementBase>();

            InitializeStates();
        }

        private void InitializeStates()
        {
            MovementState = new MovementState(anim, input, movement);
            AttackState = new AttackState(anim, input, movement);

            currentState = MovementState;
        }

        private void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }

        public void ChangeState(StateBase newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }

            currentState = newState;
            currentState.EnterState();
        }
    }
}