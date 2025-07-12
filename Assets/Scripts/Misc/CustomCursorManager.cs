using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursorManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    [SerializeField] private Texture2D cursorTexture;

    [SerializeField] private Vector2 cursorHotSpot;

    public void StartUp()
    {
        Status = ManagerStatus.Initializing;

        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);

        Status = ManagerStatus.Started;

    }
    
}
