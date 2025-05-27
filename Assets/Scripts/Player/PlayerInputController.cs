using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetMouseButton(0))
        {
            primaryTurret.Fire();
        }
    }
}
