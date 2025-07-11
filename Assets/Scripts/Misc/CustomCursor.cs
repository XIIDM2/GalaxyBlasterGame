using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour, IStartUpManagers
{
    [SerializeField] private Texture2D cursorTexture;

    [SerializeField] private Vector2 cursorHotSpot;

    public ManagerStatus Status { get; private set; }

    public void StartUp()
    {
        Status = ManagerStatus.Initializing;

        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);

        Status = ManagerStatus.Started;

    }
    
}
