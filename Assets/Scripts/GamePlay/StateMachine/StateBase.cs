using Main.GamePlay.AnimationSystem;
using Main.GamePlay.InputSystem;

namespace Main.GamePlay.StateMachineSystem
{
    public abstract class StateBase
    {
        protected AnimationBase _anim;
        protected InputBase _input;

        public StateBase(AnimationBase anim, InputBase input)
        {
            _anim = anim;
            _input = input;
        }

        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void ExitState();
    }
}