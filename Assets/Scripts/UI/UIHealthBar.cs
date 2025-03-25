using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.GamePlay.UI
{
    public class UIHealthBar : MonoBehaviour
    {
        private Slider healthBar;

        private Health health;

        private void Start()
        {
            health = transform.root.GetComponent<Health>();

            health.CurrentHealthValueChanged += OnCurrentHealthValueChanged;

            healthBar = GetComponentInChildren<Slider>();
        }

        private void OnDestroy()
        {
            health.CurrentHealthValueChanged -= OnCurrentHealthValueChanged;
        }

        private void OnCurrentHealthValueChanged()
        {
            healthBar.value = (float) health.CurrentHealth / health.MaxHealth;
        }
    }
}