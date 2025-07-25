using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private PlayerInputController inputController;

    private Rigidbody2D rigidBody;

    private void Start()
    {
        inputController = GetComponent<PlayerInputController>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 verticalMovement = Vector2.up * inputController.VerticalInput;
        Vector3 horizontalMovement = Vector2.right * inputController.HorizontalInput;

        rigidBody.linearVelocity = (verticalMovement + horizontalMovement).normalized * movementSpeed;

        // rb.AddForce(Time.fixedDeltaTime * transform.up * vInput);

        RotatePlayerToLookingPosition();

    }

    private void RotatePlayerToLookingPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = Mathf.LerpAngle(rigidBody.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
    }
}
