using System;
using UnityEngine;

public class PlayerInput : InputBase
{
    public event Action OnAttackPressed;
    public event Action OnDropPressed;

    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick lookJoystick;

    public override Vector3 GetLookInput() => new Vector3(lookJoystick.Direction.x, 0f, lookJoystick.Direction.y);

    public override Vector3 GetMovementInput() => new Vector3(movementJoystick.Direction.x, 0f, movementJoystick.Direction.y);

    public void RegisterAttackButtonPress()
    {
        OnAttackPressed?.Invoke();
    }

    public void RegisterDropButtonPress()
    {
        OnDropPressed?.Invoke();
    }
}
