using UnityEngine;

public class PlayerDoubleJoystickInput : PlayerInputBase
{
    [SerializeField] private Joystick movementJoystick;
    [SerializeField] private Joystick lookJoystick;

    public override Vector3 GetLookInput() => new Vector3(lookJoystick.Direction.x, 0f, lookJoystick.Direction.y);

    public override Vector3 GetMovementInput() => new Vector3(movementJoystick.Direction.x, 0f, movementJoystick.Direction.y);
}
