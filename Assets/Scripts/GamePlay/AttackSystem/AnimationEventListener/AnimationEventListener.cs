using System;
using UnityEngine;

namespace Main.GamePlay.AttackSystem
{
    public class AnimationEventListener : MonoBehaviour
    {
        public event Action OnDamageEvent;

        public void OnDamage()
        {
            OnDamageEvent?.Invoke();
        }
    }
}