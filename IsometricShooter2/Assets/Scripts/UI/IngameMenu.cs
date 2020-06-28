using System.Collections;
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
        CursorUICheck();        
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
                ingameMenu.SetActive(false);
            }
                
        }
    }

    private void CursorUICheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform.gameObject.layer);
            //if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            //{
            //    player.GetComponent<PlayerStats>().CanPlayerShoot = false;
            //}
            //else
            //    player.GetComponent<PlayerStats>().CanPlayerShoot = true;
        }
    }

    private void CloseIngameMenu()
    {
        ingameMenu.SetActive(false);
    }
}
