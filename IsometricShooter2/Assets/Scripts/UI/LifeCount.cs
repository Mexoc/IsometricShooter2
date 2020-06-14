using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    private int lifeCount;
    private GameObject player;
    private Text lifeCountText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lifeCountText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        DisplayLifeCount();
        ReduceLife();
    }

    private void DisplayLifeCount()
    {
        lifeCountText.text = "x " + PlayerLifeCount.playerLife;        
    }

    private void ReduceLife()
    {
        
        if (player.GetComponent<PlayerStats>().isPlayerDead)
        {            
            if (PlayerLifeCount.playerLife > 0)
            {
                PlayerLifeCount.playerLife--;
                lifeCountText.text = "";
                ReloadCurrentScene();
            }    
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator PauseBeforeReloadScene()
    {
        yield return new WaitForSeconds(5);
        ReloadCurrentScene();
    }
}
