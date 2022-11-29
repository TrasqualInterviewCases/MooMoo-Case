using Main.GamePlay.UISystem;
using Main.Utilities;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Managers
{
    public class GameManager : Singleton<GameManager>, IVisualizeable
    {
        public Action<float, float> OnValueChanged { get; set; }

        public static event Action OnGameWin;
        public static event Action OnGameLost;

        [SerializeField] private float gameDuration = 60f;

        IEnumerator gameTimerCo;

        protected override void Awake()
        {
            base.Awake();
            gameTimerCo = GameTimerCo();
            StartCoroutine(gameTimerCo);
        }

        private IEnumerator GameTimerCo()
        {
            var t = 0f;
            while (t < gameDuration)
            {
                t += Time.deltaTime;
                OnValueChanged?.Invoke(t, gameDuration);
                yield return null;
            }
            LoseGame();
        }

        private void StopGameTimer()
        {
            if (gameTimerCo != null)
            {
                StopCoroutine(gameTimerCo);
            }
        }

        public void WinGame()
        {
            OnGameWin?.Invoke();
            StopGameTimer();
        }

        public void LoseGame()
        {
            OnGameLost?.Invoke();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}