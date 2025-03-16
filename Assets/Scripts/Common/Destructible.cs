using UnityEngine;
using UnityEngine.Events;

namespace Scripts.GamePlay.Common
{
    public class Destructible : MonoBehaviour
    {
        public event UnityAction IsDestroyed;
        public event UnityAction CurrentHealthValueChanged;

        [SerializeField] private int maxHeath = 100;
        [SerializeField] private int currentHealth;
        [SerializeField] private bool isDestructible = true;

        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = Mathf.Clamp(value, 0, maxHeath);
                CurrentHealthValueChanged?.Invoke();
                Debug.LogFormat("Current Health {0} changed to {1}", gameObject.name, value);
            }
        }

        private void Start()
        {
            CurrentHealth = maxHeath;
        }

        /// <summary>
        /// Method for Applying Damage to a Destructible Object
        /// </summary>
        /// <param name="damageAmount"></param>
        public void ApplyDamage(int damageAmount)
        {
            if (!isDestructible)
            {
                Debug.LogFormat("{0} is indestructible, damage cannot be applied", gameObject.name);
                return;
            }

            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsDestroyed?.Invoke();
            }
        }

        /// <summary>
        /// Method for Healing a Destructible Object
        /// </summary>
        /// <param name="healAmount"></param>
        public void ApplyHeal(int healAmount)
        {
            if (CurrentHealth >= maxHeath)
            {
                Debug.LogFormat("{0} has full health, healing is not required", gameObject.name);
                return;
            }

            CurrentHealth += healAmount;

            if (CurrentHealth >= maxHeath)
            {
                CurrentHealth = maxHeath;
            }
        }
    }
}