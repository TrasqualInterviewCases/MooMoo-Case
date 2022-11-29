using Main.GamePlay.HealthSystem;
using Main.GamePlay.InputSystem;
using Main.GamePlay.ItemSystem;
using System.Collections;
using UnityEngine;

namespace Main.GamePlay.AttackSystem
{
    public class PlayerAttackHandler : AttackHandlerBase
    {
        [SerializeField] LayerMask damageMask;

        private WeaponHandler weaponHandler;
        private PlayerInputBase playerInput;
        private AnimationEventListener animEventListener;

        private IEnumerator attackCDCo;
        private bool isOnCD;

        protected override void Awake()
        {
            base.Awake();
            weaponHandler = GetComponent<WeaponHandler>();
            playerInput = GetComponent<PlayerInputBase>();
            animEventListener = GetComponentInChildren<AnimationEventListener>();
        }

        protected override void PerformAttack()
        {
            if (isOnCD || weaponHandler.CurrentWeapon == null) return;
            stateMachine.ChangeState(stateMachine.AttackState);
            attackCDCo = AttackCD();
            StartCoroutine(attackCDCo);
        }

        private void DealDamage()
        {
            var currentWeaponData = weaponHandler.CurrentWeapon.Data;
            var cols = Physics.SphereCastAll(transform.position + Vector3.up, currentWeaponData.AttackRadius, transform.forward, currentWeaponData.AttackRange, damageMask);
            foreach (var col in cols)
            {
                if (col.transform.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(currentWeaponData.AttackDamage);
                }
            }
        }

        private IEnumerator AttackCD()
        {
            isOnCD = true;

            yield return new WaitForSeconds(weaponHandler.CurrentWeapon.GetAttackAnimationLength());
            stateMachine.ChangeState(stateMachine.MovementState);

            yield return new WaitForSeconds(weaponHandler.CurrentWeapon.Data.AttackCD);
            isOnCD = false;
        }

        private void CancelAttack()
        {
            if (attackCDCo != null)
                StopCoroutine(attackCDCo);
            stateMachine.ChangeState(stateMachine.MovementState);
            isOnCD = false;
        }

        private void OnEnable()
        {
            playerInput.OnAttackPressed += PerformAttack;
            animEventListener.OnDamageEvent += DealDamage;
            weaponHandler.OnWeaponDropped += CancelAttack;
        }

        private void OnDisable()
        {
            playerInput.OnAttackPressed -= PerformAttack;
            animEventListener.OnDamageEvent -= DealDamage;
            weaponHandler.OnWeaponDropped -= CancelAttack;
        }
    }
}