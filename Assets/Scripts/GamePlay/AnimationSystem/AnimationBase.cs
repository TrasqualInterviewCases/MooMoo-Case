using UnityEngine;

namespace Main.GamePlay.AnimationSystem
{
    public abstract class AnimationBase : MonoBehaviour
    {
        [SerializeField] protected Animator anim;

        public abstract void PlayMovementAnim(Vector3 inputValue);
        public abstract void PlayAttackAnim();
    }
}