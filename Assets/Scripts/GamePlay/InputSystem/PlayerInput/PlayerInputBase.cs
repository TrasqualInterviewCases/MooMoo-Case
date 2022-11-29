using System;
using UnityEngine;

namespace Main.GamePlay.InputSystem
{
    public abstract class PlayerInputBase : InputBase
    {
        public event Action OnAttackPressed;
        public event Action OnDropPressed;

        public override Vector3 GetLookInput() => Vector3.zero;

        public override Vector3 GetMovementInput() => Vector3.zero;

        public virtual void RegisterAttackButtonPress()
        {
            OnAttackPressed?.Invoke();
        }

        public virtual void RegisterDropButtonPress()
        {
            OnDropPressed?.Invoke();
        }
    }
}