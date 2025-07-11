using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectile", menuName = "Projectiles/Projectile Object")]
public class ProjectileObject : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private AudioClip shipImpactSound;

    public float Speed => speed;
    public int Damage => damage;
    public float LifeTime => lifeTime;
    public GameObject ImpactEffect => impactEffect;
    public AudioClip ShipImpactSound => shipImpactSound;
}
