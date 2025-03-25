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
        transform.position = target.TransformPoint(cameraOffset);
    }
}
