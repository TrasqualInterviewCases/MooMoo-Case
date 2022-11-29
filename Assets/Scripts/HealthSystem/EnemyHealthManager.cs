using UnityEngine;

[RequireComponent(typeof(HealthRegenerator))]
public class EnemyHealthManager : HealthManagerBase
{
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
            Die();
            return;
        }
        healthRegenerator.RegenerateHealth();
    }

    public void GainHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
            healthRegenerator.StopRegeneration();
        }
    }

    protected override void Die()
    {
        healthRegenerator.StopRegeneration();
        IsDead = true;
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
