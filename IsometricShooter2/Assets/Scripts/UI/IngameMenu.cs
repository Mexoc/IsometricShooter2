﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    private GameObject ingameMenu;
    private GameObject toMainMenuButton;
    private GameObject backToGameButton;
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ingameMenu = GameObject.Find("IngameMenu");
        toMainMenuButton = GameObject.Find("ToMainMenuButton");
        backToGameButton = GameObject.Find("BackToGameButton");
        backToGameButton.GetComponent<Button>().onClick.AddListener(CloseIngameMenu);
        toMainMenuButton.GetComponent<Button>().onClick.AddListener(ButtonEvents.LoadMainMenu);
        ingameMenu.SetActive(false);
    }

    void Update()
    {
        ToggleGameMenu();   
    }

    private void ToggleGameMenu()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ingameMenu.activeSelf == false)
            {
                ingameMenu.SetActive(true);
            }
            else
            {
                CloseIngameMenu();
            }
                
        }
    }

    private void CloseIngameMenu()
    {
        ingameMenu.SetActive(false);
    }
}
