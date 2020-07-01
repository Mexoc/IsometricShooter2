using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenuButtons : MonoBehaviour
{
    private GameObject newGameButton;
    private GameObject exitButton;
    private GameObject optionsButton;
    private GameObject optionsMenu;
    private GameObject mainMenu;
    private GameObject backToMenuButton;

    void Start()
    {
        optionsMenu = GameObject.Find("OptionsMenu");
        mainMenu = GameObject.Find("MainMenuPanel");
        newGameButton = GameObject.Find("NewGameButton");
        exitButton = GameObject.Find("ExitButton");
        optionsButton = GameObject.Find("OptionsButton");        
        backToMenuButton = GameObject.Find("BackToMenuButton");
        newGameButton.GetComponent<Button>().onClick.AddListener(ButtonEvents.NewGameStart);
        exitButton.GetComponent<Button>().onClick.AddListener(ButtonEvents.GameExit);
        optionsButton.GetComponent<Button>().onClick.AddListener(OpenOptions);
        backToMenuButton.GetComponent<Button>().onClick.AddListener(BackToMenu);
        optionsMenu.SetActive(false);

    }

    private void OpenOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void BackToMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
