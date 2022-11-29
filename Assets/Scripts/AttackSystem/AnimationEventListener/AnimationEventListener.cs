using System;
using UnityEngine;

public class AnimationEventListener : MonoBehaviour
{
    public event Action OnDamageEvent;

    public void OnDamage()
    {
        OnDamageEvent?.Invoke();
    }
}
