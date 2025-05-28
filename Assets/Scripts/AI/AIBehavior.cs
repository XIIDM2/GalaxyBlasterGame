using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private float stoppingDistance = 10.0f;
    [SerializeField] private float fireDistance = 15.0f;

    [SerializeField] private float timeToCalculateNewPosition = 1f;

    private PatrolZone patrolZone;

    private AIObstacleDetection obstacleDetection;
    private AIPlayerDetection playerDetection;

    private Turret primaryTurret;

    private Vector3 positionToMove;

    private bool avoidingCollision = false;

    private void Start()
    {
        patrolZone = GameObject.Find("PatrolZone").GetComponent<PatrolZone>();

        if (patrolZone == null )
        {
            Debug.LogErrorFormat("{0} did not find Patrol Zone", gameObject.name);
        }

        obstacleDetection = GetComponentInChildren<AIObstacleDetection>();
        playerDetection = GetComponentInChildren<AIPlayerDetection>();

        primaryTurret = GetComponentInChildren<Turret>();


        CalculatePositionToMove();
    }

    private void Update()
    {
        if (!playerDetection.IsInFight)
        {
            HandlePatrol();
        }
        else
        {
            HandleTarget();
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void HandlePatrol()
    {
        MoveToPatrolPosition();

        if (obstacleDetection.CollisionDanger() && !avoidingCollision)
        {
            StartCoroutine(FindNewPositionToAvoidCollisionRoutine());
        }

        FindNewPositionAfterReachingDestination();
    }

    private void HandleTarget()
    {
        var (target, distance, hasTarget) = CalculateDistanceToTarget();

        if (!hasTarget) return;

        RotateToTarget(target.position);

        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }

        if (distance <= fireDistance)
        {
            primaryTurret.Fire();
        }
    }

    private void CalculatePositionToMove()
    {
        if (patrolZone != null)
        {
            positionToMove = patrolZone.GetRandomPositionInsideZone();
        }
    }

    private void MoveToPatrolPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, movementSpeed * Time.deltaTime);

        RotateToTarget(positionToMove);
    }

    private void FindNewPositionAfterReachingDestination()
    {
        if (Vector3.Distance(transform.position, positionToMove) <= 0.2f)
        {
            CalculatePositionToMove();
        }
    }

    private IEnumerator FindNewPositionToAvoidCollisionRoutine()
    {
        avoidingCollision = true;
        CalculatePositionToMove();

        yield return new WaitForSeconds(timeToCalculateNewPosition);

        avoidingCollision = false;
        
    }

    private (Transform target, float distance, bool hasTarget) CalculateDistanceToTarget()
    {
        if (!playerDetection.Player)
        {
            return (null, 0.0f, false);
        }

        Transform targetPosition = playerDetection.Player;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition.position);

        return (targetPosition, distanceToTarget, true);
    }

    private void RotateToTarget(Vector3 rotationTarget)
    {
        Vector2 direction = (Vector2)(rotationTarget - transform.position);

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, positionToMove);
    }
}
