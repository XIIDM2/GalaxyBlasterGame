using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    private void Update()
    {
        if (Managers.ManagersInit)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
