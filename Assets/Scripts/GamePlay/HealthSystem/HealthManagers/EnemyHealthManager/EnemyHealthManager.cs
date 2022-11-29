using Main.GamePlay.UISystem;
using Main.Managers;
using System;
using UnityEngine;

namespace Main.GamePlay.HealthSystem
{
    [RequireComponent(typeof(HealthRegenerator))]
    public class EnemyHealthManager : HealthManagerBase, IVisualizeable
    {
        public Action<float, float> OnValueChanged { get; set; }

        HealthRegenerator healthRegenerator;

        protected override void Awake()
        {
            base.Awake();
            healthRegenerator = GetComponent<HealthRegenerator>();
        }

        public override void TakeDamage(float damage)
        {
            if (IsDead) return;

            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }
            else
            {
                healthRegenerator.RegenerateHealth();
            }
            OnValueChanged?.Invoke(currentHealth, maxHealth);
        }

        public void GainHealth(float amount)
        {
            currentHealth += amount;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
                healthRegenerator.StopRegeneration();
            }
            OnValueChanged?.Invoke(currentHealth, maxHealth);
        }

        protected override void Die()
        {
            healthRegenerator.StopRegeneration();
            IsDead = true;
            GameManager.Instance.WinGame();
        }

        private void OnEnable()
        {
            healthRegenerator.OnRegenTick += GainHealth;
        }

        private void OnDisable()
        {
            healthRegenerator.OnRegenTick -= GainHealth;
        } 
    }
}
