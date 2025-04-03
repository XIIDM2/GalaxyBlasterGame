using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    private PatrolZone patrolZone;

    private AIObstacleDetection aIObstacleDetection;

    private Vector3 positionToMove;

    private Timer timerAfterChangingPatrolPosition;
    private float timeAfterChangingPatrolPosition = 0.5f;

    private void Start()
    {
        patrolZone = GameObject.Find("PatrolZone").GetComponent<PatrolZone>();

        aIObstacleDetection = GetComponent<AIObstacleDetection>();

        timerAfterChangingPatrolPosition = new Timer(timeAfterChangingPatrolPosition);

        CalculatePositionToMove();
    }

    private void Update()
    {
        MoveToPatrolPosition();

        FindNewPositionToAvoidCollision();

        FindNewPositionAfterReachingDestination();
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

        RotateToPosition();
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

    private void RotateToPosition()
    {
        Vector2 direction = (Vector2)(positionToMove - transform.position);

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
