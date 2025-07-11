using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    public float VerticalInput => verticalInput;
    public float HorizontalInput => horizontalInput;

    private Turret primaryTurret;

    private void Start()
    {
        primaryTurret = GetComponentInChildren<Turret>();

    }

    public void OnMove(InputValue value)
    {
        verticalInput = value.Get<Vector2>().y;
        horizontalInput = value.Get<Vector2>().x;
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {         
            primaryTurret.Fire();
           
        }
    }

}
