using UnityEngine;
using UnityEngine.UI;

namespace Main.GamePlay.UISystem
{
    public class VisualizerBar : MonoBehaviour
    {
        [SerializeField] Image bar;

        IVisualizeable visualizeable;

        private void Awake()
        {
            visualizeable = GetComponentInParent<IVisualizeable>();
        }

        private void SetBar(float curHealth, float maxHealth)
        {
            bar.fillAmount = curHealth / maxHealth;
        }

        private void OnEnable()
        {
            visualizeable.OnValueChanged += SetBar;
        }

        private void OnDisable()
        {
            visualizeable.OnValueChanged -= SetBar;
        }
    }
}