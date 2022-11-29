using UnityEngine;

namespace Main.GamePlay.HealthSystem
{
    public abstract class HealthManagerBase : MonoBehaviour, IDamageable
    {
        [SerializeField] protected float maxHealth = 5;
        protected float currentHealth;

        public bool IsDead { get; protected set; }

        protected virtual void Awake()
        {
            currentHealth = maxHealth;
        }

        public virtual void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        protected abstract void Die();
    }
}