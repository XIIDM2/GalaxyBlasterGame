using Scripts.GamePlay.Common;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.GamePlay
{
    public class Health : MonoBehaviour
    {
        public event UnityAction CurrentHealthValueChanged;
        public event UnityAction Death;

        [SerializeField] private int maxHealth = 100;
        [SerializeField] private int currentHealth;

        private Destructible destructible;

        public int MaxHealth => maxHealth;

        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            private set
            {
                int previousHealth = currentHealth;

                currentHealth = Mathf.Clamp(value, 0, maxHealth);

                if (previousHealth != currentHealth)
                {
                    CurrentHealthValueChanged?.Invoke();
                    Debug.LogFormat("Current Health {0} changed to {1}", gameObject.name, currentHealth);
                }
            }
        }

        private void Start()
        {
            destructible = GetComponent<Destructible>();

            CurrentHealth = maxHealth;
        }

        /// <summary>
        /// Method for Applying Damage to a Destructible Object
        /// </summary>
        /// <param name="damageAmount"></param>
        public void ApplyDamage(int damageAmount)
        {
            if (destructible.IsDestructable)
            {
                Debug.LogFormat("{0} is indestructible, damage cannot be applied", gameObject.name);
                return;
            }

            if (CurrentHealth <= 0) return;

            CurrentHealth -= damageAmount;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Death?.Invoke();
                Debug.Log("Event Death invoked");
            }
        }

        /// <summary>
        /// Method for Healing a Destructible Object
        /// </summary>
        /// <param name="healAmount"></param>
        public void ApplyHeal(int healAmount)
        {
            if (CurrentHealth <= 0)
            {
                Debug.LogFormat("{0} is dead, can not heal", gameObject.name);
                return;
            }

            if (CurrentHealth >= maxHealth)
            {
                Debug.LogFormat("{0} has full health, healing is not required", gameObject.name);
                return;
            }

            CurrentHealth += healAmount;

            if (CurrentHealth >= maxHealth)
            {
                CurrentHealth = maxHealth;
            }
        }
    }
}