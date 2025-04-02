using Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIObstacleDetection : MonoBehaviour
{
    [SerializeField] private float radius = 5.0f;
    [SerializeField] private float raycastDistance = 10f;

    [SerializeField] private bool inCollisionDanger;

    private CircleCollider2D circleCollider;

    public bool InCollisionDanger => inCollisionDanger;

    private Transform owner;

    private void Start()
    {
        owner = transform;

        if (TryGetComponent<CircleCollider2D>(out circleCollider))
        {
            circleCollider.radius = radius;
            circleCollider.isTrigger = true;
        }
        else
        {
            Debug.LogFormat("{0} does not contain component CircleCollider2D", gameObject.name);
        }
    }

    private void Update()
    {
        CheckIfRayCastHitCollision();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CheckIfCollisionNeedToBeAvoided(collision)) return;

        inCollisionDanger = true;

        Debug.LogFormat("{0} entered Danger radius for {1}", collision.transform.root.name, gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CheckIfCollisionNeedToBeAvoided(collision)) return;

        inCollisionDanger = false;

        Debug.LogFormat("{0} exit Danger radius for {1}", collision.transform.root.name, gameObject.name);
    }

    private bool CheckIfCollisionNeedToBeAvoided(Collider2D collision)
    {
        Transform rootTransform = collision.transform.root;

        bool isProjectile = rootTransform.TryGetComponent<Projectile>(out _);
        bool isShip = rootTransform.TryGetComponent<Health>(out _);

        return (!isProjectile && !isShip);
    }

    private void CheckIfRayCastHitCollision()
    {
       RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, raycastDistance);

        inCollisionDanger = false;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider == circleCollider || hit.collider.transform.root == owner) continue;

                inCollisionDanger = true;

                Debug.LogFormat("{0} on the path of {1}", hit.collider.transform.root.name, gameObject.name);

                break;
            }
        }     
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * raycastDistance);
    }
}
