using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolZone : MonoBehaviour
{
    [SerializeField] private float radius;

    public Vector3 GetRandomPositionInsideZone()
    {
        Vector3 randomPosition = Random.insideUnitCircle * radius;
        randomPosition.z = 0.0f;

        return randomPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, radius);
    }
}
