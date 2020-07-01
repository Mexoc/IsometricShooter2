using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    private float playerHealth = 100;
    public float playerStamina = 100;
    public bool isKeycardLooted = false;
    private static bool canPlayerShoot;
    public GameObject playerHealthBar;
    public GameObject playerStaminaBar;
    private Animator playerAnim;
    public bool isPlayerDead;

    private void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        playerHealthBar = GameObject.Find("PlayerHealthBar");
        playerStaminaBar = GameObject.Find("PlayerStaminaBar");
        isPlayerDead = false;
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
            isPlayerDead = true;            
            playerAnim.SetBool("isPlayerDead", true);
            Destroy(gameObject.GetComponent<PlayerTurn>());
            Destroy(gameObject.GetComponent<PlayerMovement>());
            Destroy(gameObject.GetComponent<PlayerShoot>());
            Destroy(gameObject.GetComponent<LineRenderer>());
        }
    }

    public bool CanPlayerShoot
    {
        get { return canPlayerShoot; }
        set { canPlayerShoot = value; }
    }

    private void Update()
    {
        PlayerDeath();
    }
}
