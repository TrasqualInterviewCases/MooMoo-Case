using System;
using System.Collections;
using UnityEngine;

namespace Main.GamePlay.HealthSystem
{
    public class HealthRegenerator : MonoBehaviour
    {
        public event Action<float> OnRegenTick;

        [SerializeField] private float regenerationDelay = 2f;
        [SerializeField] private float tickTimer = 0.5f;
        [SerializeField] private float healthAmount = 1f;

        private WaitForSeconds regenDelayWait;
        private WaitForSeconds regenTickWait;

        private IEnumerator regenCo;

        private void Awake()
        {
            regenDelayWait = new WaitForSeconds(regenerationDelay);
            regenTickWait = new WaitForSeconds(tickTimer);
        }

        public void RegenerateHealth()
        {
            StopRegeneration();
            regenCo = RegenCo();
            StartCoroutine(regenCo);
        }

        public void StopRegeneration()
        {
            if (regenCo != null)
                StopCoroutine(regenCo);
        }

        private IEnumerator RegenCo()
        {
            yield return regenDelayWait;

            while (true)
            {
                OnRegenTick?.Invoke(healthAmount);
                yield return regenTickWait;
            }
        }
    }
}