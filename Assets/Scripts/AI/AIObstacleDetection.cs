using Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIObstacleDetection : MonoBehaviour
{
    [SerializeField] private CircleCollider2D obstacleDetecionArea;
    [SerializeField] private float radius = 5.0f;

    [SerializeField] private float raycastDistance = 10f;

    [SerializeField] private bool inCollisionRangeDanger;
    [SerializeField] private bool collisionOnPathDanger;

    private Transform owner;

    private Timer timerToUpdateRayCast;
    private float timeToUpdateRayCast = 0.3f;

    private void Start()
    {
        owner = transform.root;

        if (obstacleDetecionArea != null)
        {
            obstacleDetecionArea.radius = radius;
            obstacleDetecionArea.isTrigger = true;
        }
        else
        {
            Debug.LogFormat("{0} does not contain component CircleCollider2D", gameObject.name);
        }
        timerToUpdateRayCast = new Timer(timeToUpdateRayCast);
    }

    private void Update()
    {
        timerToUpdateRayCast.Tick(Time.deltaTime);

        if (timerToUpdateRayCast.IsTimerFinished)
        {
            CheckIfRayCastHitCollision();
            timerToUpdateRayCast.Reset(timeToUpdateRayCast);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CheckIfCollisionNeedToBeAvoided(collision)) return;

        inCollisionRangeDanger = true;

        Debug.LogFormat("{0} entered Danger radius for {1}", collision.transform.root.name, gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!CheckIfCollisionNeedToBeAvoided(collision)) return;

        inCollisionRangeDanger = false;

        Debug.LogFormat("{0} exit Danger radius for {1}", collision.transform.root.name, gameObject.name);
    }

    public bool CollisionDanger()
    {
        return (inCollisionRangeDanger || collisionOnPathDanger);
    }

    private bool CheckIfCollisionNeedToBeAvoided(Collider2D collision)
    {
        Transform rootTransform = collision.transform.root;

        bool isProjectile = rootTransform.TryGetComponent<Projectile>(out _);
        bool isShip = rootTransform.TryGetComponent<SpaceShip>(out _);

        return (!isProjectile && !isShip);
    }

    private void CheckIfRayCastHitCollision()
    {
       RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, raycastDistance);

        collisionOnPathDanger = false;

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider == obstacleDetecionArea || hit.collider.transform.root == owner) continue;

                collisionOnPathDanger = true;

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
