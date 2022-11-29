using Main.GamePlay.ItemSystem;
using UnityEngine;

namespace Main.GamePlay.AnimationSystem
{
    public class PlayerAnimation : AnimationBase
    {
        RuntimeAnimatorController originalController;
        WeaponHandler weaponHandler;

        private void Awake()
        {
            originalController = anim.runtimeAnimatorController;
            weaponHandler = GetComponent<WeaponHandler>();
        }

        public override void PlayMovementAnim(Vector3 inputValue)
        {
            anim.SetFloat("move", transform.TransformDirection(inputValue).magnitude, 0.1f, Time.deltaTime);
        }

        public override void PlayAttackAnim()
        {
            anim.SetTrigger("attack");
        }

        private void SetupAnimController(WeaponBase weapon)
        {
            anim.runtimeAnimatorController = weapon.Data.overrideController;
        }

        private void ResetAnimController()
        {
            anim.runtimeAnimatorController = originalController;
        }

        private void OnEnable()
        {
            weaponHandler.OnWeaponEquipped += SetupAnimController;
            weaponHandler.OnWeaponDropped += ResetAnimController;
        }

        private void OnDisable()
        {
            weaponHandler.OnWeaponEquipped -= SetupAnimController;
            weaponHandler.OnWeaponDropped -= ResetAnimController;
        }
    }
}