using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ButtonEvents
{
    public static void NewGameStart()
    {
        SceneManager.LoadScene(1);
    }

    public static void GameExit()
    {
        Application.Quit();
    }
    
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
