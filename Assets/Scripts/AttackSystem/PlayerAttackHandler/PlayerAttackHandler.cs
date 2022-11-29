using System.Collections;
using UnityEngine;

public class PlayerAttackHandler : AttackHandlerBase
{
    [SerializeField] LayerMask damageMask;

    private WeaponHandler weaponHandler;
    private PlayerInputBase playerInput;
    private AnimationEventListener animEventListener;

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
        StartCoroutine(AttackCD());
    }

    private void DealDamage()
    {
        Debug.Log("dealthDamage");
        var currentWeaponData = weaponHandler.CurrentWeapon.Data;
        var cols = Physics.SphereCastAll(transform.position + Vector3.up, currentWeaponData.AttackRadius, transform.forward, currentWeaponData.AttackRange, damageMask);
        Debug.Log(cols.Length);
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

    private void OnEnable()
    {
        playerInput.OnAttackPressed += PerformAttack;
        animEventListener.OnDamageEvent += DealDamage;
    }

    private void OnDisable()
    {
        playerInput.OnAttackPressed -= PerformAttack;
        animEventListener.OnDamageEvent -= DealDamage;
    }
}
