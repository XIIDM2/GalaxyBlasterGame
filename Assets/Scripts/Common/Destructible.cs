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
                Debug.LogFormat("������� �������� {0} ���������� �� {1}", gameObject.name, value);
            }
        }

        private void Start()
        {
            CurrentHealth = maxHeath;
        }

        /// <summary>
        /// ����� ��������� ����� ������������ �������
        /// </summary>
        /// <param name="damageAmount"></param>
        public void ApplyDamage(int damageAmount)
        {
            if (!isDestructible)
            {
                Debug.LogFormat("{0} �������������, ������� ���� ����������", gameObject.name);
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
        /// ����� ������� ������������ �������
        /// </summary>
        /// <param name="healAmount"></param>
        public void ApplyHeal(int healAmount)
        {
            if (CurrentHealth >= maxHeath)
            {
                Debug.LogFormat("� {0} ������ ��������, ������� �� ���������", gameObject.name);
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