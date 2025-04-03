using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float fireRate;

    [SerializeField] private GameObject projectilePrefab;

    private float fireTimer;

    private void Start()
    {
        fireRate = 1.0f;
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;
    }

    public void Fire()
    {
        if (fireTimer > 0) return;
        
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation);

        SetOwnerForProjectile(projectileObject);

        fireTimer = fireRate;    
    }

    private void SetOwnerForProjectile(GameObject projectileObject)
    {
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        projectile.SetOwner(transform.root.gameObject.transform);

    }
}
