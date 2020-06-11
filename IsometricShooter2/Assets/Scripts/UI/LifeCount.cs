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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform.parent);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lifeCount = player.GetComponent<PlayerStats>().lifeCount;
        lifeCountText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        DisplayLifeCount();
        ReduceLife();
    }

    private void DisplayLifeCount()
    {
        lifeCountText.text = "x " + lifeCount;        
    }

    private void ReduceLife()
    {
        if (player.GetComponent<PlayerStats>().isPlayerDead)
        {
            if (lifeCount > 0)
            {
                lifeCount--;
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
        StartCoroutine("PauseBeforeReloadScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private IEnumerator PauseBeforeReloadScene()
    {
        yield return new WaitForSeconds(5);        
    }
}
