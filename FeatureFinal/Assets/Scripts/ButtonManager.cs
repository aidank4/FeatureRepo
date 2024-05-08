using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Kelly, Aidan
/// 05/07/2024
/// controls buttons for scene management
/// </summary>

public class ButtonManager : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("play");
        SceneManager.LoadScene(2);
    }

    public void Controls()
    {
        Debug.Log("controls");
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
