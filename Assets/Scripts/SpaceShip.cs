using Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : Health
{
    [SerializeField] private GameObject deathEffectPrefab;

    private void Start()
    {
        Death += OnSpaceShipDestroy;
    }

    private void OnDestroy()
    {
        Death -= OnSpaceShipDestroy;
    }
    protected virtual void OnSpaceShipDestroy()
    {
        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

        ParticleSystem particleSystem = deathEffect.GetComponent<ParticleSystem>();

        Destroy(deathEffect, particleSystem.main.duration);

        Destroy(gameObject);
    }
}
