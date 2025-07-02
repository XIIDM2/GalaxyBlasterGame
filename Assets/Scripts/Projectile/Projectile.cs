using Scripts.GamePlay;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    [SerializeField] private float speed;

    [SerializeField] private int damage;

    [SerializeField] private GameObject impactEffect;

    private Transform owner;

    private void Start()
    {
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
            ship.ApplyDamage(damage);
            Managers.Audio.PlaySpaceShipHitSound();
        }

        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void SetOwner(Transform owner)
    {
        this.owner = owner;
    }
}
