using Scripts.GamePlay;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileObject projectileData;

    private float lifeTime;
    private float speed;
    private int damage;
    private GameObject impactEffect;
    private AudioClip shipImpactSound;

    private Transform owner;

    private void Start()
    {
        speed = projectileData.Speed;
        damage = projectileData.Damage;
        lifeTime = projectileData.LifeTime;
        impactEffect = projectileData.ImpactEffect;
        shipImpactSound = projectileData.ShipImpactSound;

        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger || collision.gameObject.transform.root == owner) return;

        if (collision.gameObject.transform.root.TryGetComponent<SpaceShip>(out SpaceShip ship))
        {
            ship.Health.ApplyDamage(damage);
            Managers.AudioController.PlayClip(shipImpactSound);
        }

        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetOwner(Transform owner)
    {
        this.owner = owner;
    }
}
