using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    private float playerHealth = 100;
    public bool isPlayerDead = false;
    private Animator playerAnim;

    private void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
    }

    public float PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    public void PlayerDeath()
    {        
        if (PlayerHealth <= 0)
        {
            playerAnim.SetBool("isPlayerDead", true);
            Destroy(gameObject.GetComponent<PlayerTurn>());
            Destroy(gameObject.GetComponent<PlayerMovement>());
            Destroy(gameObject.GetComponent<PlayerShoot>());
        }
    }

    private void Update()
    {
        PlayerDeath();
        Debug.Log(PlayerHealth);
    }
}
