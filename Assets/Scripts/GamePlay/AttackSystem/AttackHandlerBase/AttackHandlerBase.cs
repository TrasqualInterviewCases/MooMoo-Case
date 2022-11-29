using Main.GamePlay.StateMachineSystem;
using UnityEngine;

namespace Main.GamePlay.AttackSystem
{
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
}
