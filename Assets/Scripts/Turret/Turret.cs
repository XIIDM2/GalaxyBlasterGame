using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private TurretObject turretData;

    private float fireRate;
    private GameObject projectilePrefab;
    private AudioClip fireSound;

    private bool canFire = true;

    private void Start()
    {
        fireRate = turretData.FireRate;
        projectilePrefab = turretData.ProjectilePrefab;
        fireSound = turretData.FireSound;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
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

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        SetOwnerForProjectile(projectile);

        Managers.AudioController.PlayClip(fireSound);

        yield return new WaitForSeconds(fireRate);

        canFire = true;
    }

    private void SetOwnerForProjectile(Projectile projectile)
    {
        projectile.SetOwner(transform.root.gameObject.transform);

    }
}
