using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private float vInput;
    private float hInput;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        vInput = Input.GetAxis("Vertical") * movementSpeed;
        hInput = Input.GetAxis("Horizontal") * rotationSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * vInput;

        //rb.AddForce(Time.fixedDeltaTime * transform.up * vInput);

        rb.MoveRotation(rb.rotation - hInput * Time.fixedDeltaTime);
    }
}
