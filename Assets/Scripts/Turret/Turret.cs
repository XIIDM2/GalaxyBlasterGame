using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float fireRate;

    [SerializeField] private GameObject projectilePrefab;

    private PlayerInputController inputController;

    private float fireTimer;

    private void Start()
    {
        inputController = transform.root.GetComponent<PlayerInputController>();

        fireRate = 1.0f;
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;

        Fire();
    }

    private void Fire()
    {
        if (fireTimer > 0)
        {
            inputController.Fire = false;
            return;
        }

        if (inputController.Fire)
        {
            GameObject projectileObject = Instantiate(projectilePrefab, transform.position, transform.rotation);

            SetOwnerForProjectile(projectileObject);

            fireTimer = fireRate;

            inputController.Fire = false;
        }
    }

    private void SetOwnerForProjectile(GameObject projectileObject)
    {
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        projectile.SetOwner(transform.root.gameObject.transform);

    }
}
