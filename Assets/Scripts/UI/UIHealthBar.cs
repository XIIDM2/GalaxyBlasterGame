using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GamePlay.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        [SerializeField] private TextMeshProUGUI healthText;

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
            healthBar.value = health.CurrentHealth;

            healthText.text = $"{health.CurrentHealth}/{health.MaxHealth}";
        }
    }
}