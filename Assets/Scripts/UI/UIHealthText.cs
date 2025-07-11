using Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Scripts.GamePlay.UI
{
    public class UIHealthText : MonoBehaviour
    {
        private TextMeshProUGUI healthText;

        private Health health;

        private void Start()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();

            health.CurrentHealthValueChanged += OnCurrentHealthValueChanged;

            healthText = GetComponent<TextMeshProUGUI>();
        }

        private void OnCurrentHealthValueChanged()
        {
            healthText.text = $"{(int)health.CurrentHealth}/{health.MaxHealth}";
        }
    }
}