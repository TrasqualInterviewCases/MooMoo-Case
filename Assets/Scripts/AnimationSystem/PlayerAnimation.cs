using UnityEngine;

public class PlayerAnimation : AnimationBase
{
    public override void PlayMovementAnim(Vector3 inputValue)
    {
        anim.SetFloat("move", inputValue.normalized.magnitude, 0.1f, Time.deltaTime);
    }

    public override void PlayAttackAnim()
    {
        anim.SetTrigger("attack");
    }
}
