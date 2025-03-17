using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GamePlay.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;

        [SerializeField] private Health health;

        private void Start()
        {
            healthBar.maxValue = health.MaxHealth;

            health.CurrentHealthValueChanged += OnCurrentHealthValueChanged;
        }

        private void OnDestroy()
        {
            health.CurrentHealthValueChanged -= OnCurrentHealthValueChanged;
        }

        private void OnCurrentHealthValueChanged()
        {
            if (healthBar != null)
            {
                healthBar.value = health.CurrentHealth;
            }
        }
    }
}