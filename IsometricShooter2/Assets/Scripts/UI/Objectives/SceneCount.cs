using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneCount
{
    public static int GetCurrentSceneInt()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            return 1;
        }
        else
            return 2;
    }
}
