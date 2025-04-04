using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;
    [SerializeField] private float stoppingDistance = 10.0f;
    [SerializeField] private float fireDistance = 15.0f;

    private PatrolZone patrolZone;

    private AIObstacleDetection aIObstacleDetection;
    private AIPlayerDetection aIPlayerDetection;

    private Turret primaryTurret;

    private Vector3 positionToMove;

    private Timer timerAfterChangingPatrolPosition;
    private float timeAfterChangingPatrolPosition = 1f;

    private void Start()
    {
        patrolZone = GameObject.Find("PatrolZone").GetComponent<PatrolZone>();

        aIObstacleDetection = GetComponentInChildren<AIObstacleDetection>();
        aIPlayerDetection = GetComponentInChildren<AIPlayerDetection>();

        primaryTurret = GetComponentInChildren<Turret>();

        timerAfterChangingPatrolPosition = new Timer(timeAfterChangingPatrolPosition);

        CalculatePositionToMove();
    }

    private void Update()
    {
        if (!aIPlayerDetection.IsInFight)
        {
            MoveToPatrolPosition();

            FindNewPositionToAvoidCollision();

            FindNewPositionAfterReachingDestination();
        }
        else
        {
            MoveToTarget();

            FireAtTarget();
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

    private void FindNewPositionToAvoidCollision()
    {
        if (aIObstacleDetection.CollisionDanger())
        {
            timerAfterChangingPatrolPosition.Tick(Time.deltaTime);

            if (timerAfterChangingPatrolPosition.IsTimerFinished)
            {
                CalculatePositionToMove();
                timerAfterChangingPatrolPosition.Reset(timeAfterChangingPatrolPosition);
            }

        }
    }

    private void MoveToTarget()
    {
        if (!aIPlayerDetection.Player) return;

        var (target, distance) = CalculateDistanceToTarget();

        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }

        RotateToTarget(target.position);
    }

    private void FireAtTarget()
    {
        if (!aIPlayerDetection.Player) return;

        var (target, distance) = CalculateDistanceToTarget();

        RotateToTarget(target.position);

        if (distance <= fireDistance)
        {
            primaryTurret.Fire();
        }


    }

    private (Transform target, float distance) CalculateDistanceToTarget()
    {
        Transform targetPosition = aIPlayerDetection.Player;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition.position);

        return (targetPosition, distanceToTarget);
    }

        

    private void RotateToTarget(Vector3 rotationTarget)
    {
        Vector2 direction = (Vector2)(rotationTarget - transform.position);

        // Sprite looking up, so we adding "-90.0f" to angle
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
