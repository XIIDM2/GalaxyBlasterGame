using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;

    private Transform target;

    private void Start()
    {
        target = GameObject.Find("PlayerShip").transform;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.TransformPoint(cameraOffset);
        }
    }
}
