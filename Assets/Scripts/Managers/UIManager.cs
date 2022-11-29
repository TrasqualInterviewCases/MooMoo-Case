using Main.Utilities;
using UnityEngine;

namespace Main.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] GameObject inputCanvas;
        [SerializeField] GameObject weaponCanvas;
        [SerializeField] GameObject winCanvas;
        [SerializeField] GameObject loseCanvas;

        public void DisplayWinUI()
        {
            inputCanvas.SetActive(false);
            weaponCanvas.SetActive(false);
            winCanvas.SetActive(true);
        }

        public void DisplayLoseUI()
        {
            inputCanvas.SetActive(false);
            weaponCanvas.SetActive(false);
            loseCanvas.SetActive(true);
        }

        private void OnEnable()
        {
            GameManager.OnGameWin += DisplayWinUI;
            GameManager.OnGameLost += DisplayLoseUI;
        }

        private void OnDisable()
        {
            GameManager.OnGameWin -= DisplayWinUI;
            GameManager.OnGameLost -= DisplayLoseUI;
        }
    }
}