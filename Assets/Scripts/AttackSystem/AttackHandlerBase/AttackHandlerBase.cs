using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public abstract class AttackHandlerBase : MonoBehaviour
{
    protected StateMachine stateMachine;

    protected virtual void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
    }

    protected abstract void PerformAttack();
}
