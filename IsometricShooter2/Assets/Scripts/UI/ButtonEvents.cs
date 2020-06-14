using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ButtonEvents
{
    public static void NewGameStart()
    {
        SceneManager.LoadScene(0);
    }

    public static void GameExit()
    {
        Application.Quit();
    }
    
}
