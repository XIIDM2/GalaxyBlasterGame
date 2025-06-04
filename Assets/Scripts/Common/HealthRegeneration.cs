using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthRegeneration : MonoBehaviour
{
    [SerializeField] private float regenerationRate;
    [SerializeField] private float regenerationInterval;

    private Health health;

    private Coroutine regenerationCoroutine;

    private void Awake()
    {
        health = GetComponent<Health>();

        if (health == null)
        {
            Debug.LogError($"Cannot assign Health Regeneration to object without health - {gameObject.name}");
            enabled = false;
            return;
        }
    }

    private void OnEnable()
    {
        StartRegeneration();
    }

    private void OnDisable()
    {
        StopRegeneration();
    }
    private void StartRegeneration()
    {
        if ( regenerationCoroutine == null)
        {
            regenerationCoroutine = StartCoroutine(RegenerationRoutine());
        }
    }

    private void StopRegeneration()
    {
        if (regenerationCoroutine != null)
        {
            StopCoroutine(regenerationCoroutine);
            regenerationCoroutine = null;
        }
    }

    private IEnumerator RegenerationRoutine()
    {
        while (true)
        {
            if (health.Dead)
            {
                break;
            }


            if (health.FullHealth)
            {
                while (health.FullHealth)
                {
                    yield return null;
                }    
            }

            float healthRegenerationAmount = regenerationRate * regenerationInterval;

            health.ApplyHeal(healthRegenerationAmount);

            yield return new WaitForSeconds(regenerationInterval);
        }
    }

    public void SetRegenerationValues(float regenerationRate, float regenerationInterval)
    {
        this.regenerationRate = regenerationRate;
        this.regenerationInterval = regenerationInterval;
    }
}


