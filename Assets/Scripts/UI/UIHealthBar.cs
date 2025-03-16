using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GamePlay.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;

        [SerializeField] private Health health;

        private void Start()
        {
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
                healthBar.fillAmount = (float)health.CurrentHealth / (float)health.MaxHealth;
            }
        }
    }
}