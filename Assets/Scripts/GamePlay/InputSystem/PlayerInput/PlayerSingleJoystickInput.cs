using UnityEngine;

namespace Main.GamePlay.InputSystem
{
    public class PlayerSingleJoystickInput : PlayerInputBase
    {
        [SerializeField] private Joystick movementJoystick;

        public override Vector3 GetLookInput() => new Vector3(movementJoystick.Direction.x, 0f, movementJoystick.Direction.y);

        public override Vector3 GetMovementInput() => new Vector3(movementJoystick.Direction.x, 0f, movementJoystick.Direction.y);
    }
}