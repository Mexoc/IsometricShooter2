using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenuButtons : MonoBehaviour
{
    private GameObject newGameButton;
    private GameObject exitButton;

    void Start()
    {
        newGameButton = GameObject.Find("NewGameButton");
        exitButton = GameObject.Find("ExitButton");
        newGameButton.GetComponent<Button>().onClick.AddListener(ButtonEvents.NewGameStart);
        exitButton.GetComponent<Button>().onClick.AddListener(ButtonEvents.GameExit);
    }
}
