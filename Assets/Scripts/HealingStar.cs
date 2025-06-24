using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingStar : MonoBehaviour
{
    [SerializeField] private float healingAmount = 30f;
    [SerializeField] private GameObject healingParticleEffectPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent<PlayerShip>(out PlayerShip ship))
        {
            ship.ApplyHeal(healingAmount);

            GameObject healingEffect = Instantiate(healingParticleEffectPrefab, transform.position, Quaternion.identity);

            ParticleSystem particleSystem = healingEffect.GetComponent<ParticleSystem>();

            Destroy(healingEffect, particleSystem.main.duration);

            Destroy(gameObject);
        }
    }
}
