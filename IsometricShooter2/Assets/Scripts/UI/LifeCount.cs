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
        StartCoroutine("LifeCheck");
    }

    private void DisplayLifeCount()
    {
        lifeCountText.text = "";
        lifeCountText.text = "x " + PlayerLifeCount.playerLife;
    }

    private IEnumerator LifeCheck()
    {
        if (player.GetComponent<PlayerStats>().isPlayerDead)
        {            
            if (PlayerLifeCount.playerLife > 0)
            {                
                yield return new WaitForSeconds(2f);
                ReloadCurrentScene();
                PlayerLifeCount.playerLife--;
            }
            else
            {
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(0);
            }
        }
    }

    private void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
