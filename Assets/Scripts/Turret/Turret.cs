using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float fireRate;

    [SerializeField] private GameObject projectilePrefab;

    private bool canFire = true;

    private void Start()
    {
        fireRate = 1.0f;
    }

    private void OnDestroy()
    {
        StopCoroutine(FireCoroutine());
    }

    public void Fire()
    {
        if (!canFire) return;

        StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        canFire = false;
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation);
        SetOwnerForProjectile(projectileObject);

        yield return new WaitForSeconds(fireRate);

        canFire = true;
    }

    private void SetOwnerForProjectile(GameObject projectileObject)
    {
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        projectile.SetOwner(transform.root.gameObject.transform);

    }
}
