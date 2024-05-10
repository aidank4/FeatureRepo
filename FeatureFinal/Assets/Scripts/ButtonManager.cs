using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

/// <summary>
/// Kelly, Aidan
/// 05/07/2024
/// controls buttons for scene management
/// </summary>

public class ButtonManager : MonoBehaviour
{

    private void Awake()
    {
        Cursor.visible = true;
    }

    //change language to english
    public void English()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
    
    //change language to spanish
    public void Spanish()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }

    //play button
    public void Play()
    {
        Debug.Log("play");
        SceneManager.LoadScene(2);
    }

    //control page button
    public void Controls()
    {
        Debug.Log("controls");
        SceneManager.LoadScene(1);
    }

    //quit button
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
