using Scripts.Common;
using UnityEngine;
using UnityEngine.Events;


public class Health : MonoBehaviour
{
    public event UnityAction CurrentHealthValueChanged;
    public event UnityAction Death;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float currentHealth;

    private Destructible destructible;

    public float MaxHealth => maxHealth;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        private set
        {
            float previousHealth = currentHealth;

            currentHealth = Mathf.Clamp(value, 0, maxHealth);

            if (previousHealth != currentHealth)
            {
                CurrentHealthValueChanged?.Invoke();
                Debug.LogFormat("Current Health {0} changed to {1}", gameObject.name, (int)currentHealth);
                Debug.Log($"{Dead}, {FullHealth}");
            }
        }
    }

    public bool Dead = false;
    public bool FullHealth => currentHealth >= 100;

    private void Awake()
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
            Dead = true;
            Death?.Invoke();
            Debug.Log("Event Death invoked");
        }
    }

    /// <summary>
    /// Method for Healing a Destructible Object
    /// </summary>
    /// <param name="healAmount"></param>
    public void ApplyHeal(float healAmount)
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
    }
}