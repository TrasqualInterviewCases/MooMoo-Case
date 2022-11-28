using System;
using UnityEngine;

public abstract class InputBase : MonoBehaviour
{
    public abstract Vector3 GetLookInput();
    public abstract Vector3 GetMovementInput();
}
