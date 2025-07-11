using Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private GameObject deathEffectPrefab;

    public Health Health {  get; private set; }

    private void Start()
    {
        Health = GetComponent<Health>();

        Health.Death += OnSpaceShipDestroy;
    }

    private void OnDestroy()
    {
        Health.Death -= OnSpaceShipDestroy;
    }

    protected virtual void OnSpaceShipDestroy()
    {
        GameObject deathEffect = Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);

        ParticleSystem particleSystem = deathEffect.GetComponent<ParticleSystem>();

        Destroy(deathEffect, particleSystem.main.duration);

        Destroy(gameObject);
    }
}
