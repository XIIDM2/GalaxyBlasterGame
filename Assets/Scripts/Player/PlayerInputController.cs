using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private float vInput;
    private float hInput;

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * movementSpeed;
        hInput = Input.GetAxis("Horizontal") * rotationSpeed;
    }
}
