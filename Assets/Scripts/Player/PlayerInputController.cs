using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    public bool Fire;

    public float VerticalInput => verticalInput;
    public float HorizontalInput => horizontalInput;

    private void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            Fire = true;
        }
    }
}
