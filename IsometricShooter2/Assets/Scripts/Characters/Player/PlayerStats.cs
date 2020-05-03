using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    private float playerHealth = 100;
    public float playerStamina = 100;
    public GameObject playerHealthBar;
    public GameObject playerStaminaBar;
    public bool isPlayerDead = false;
    private Animator playerAnim;

    private void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        playerHealth = Mathf.Clamp(playerHealth, 0, 100);
        playerStamina = Mathf.Clamp(playerStamina, 0, 100);
        playerHealthBar = GameObject.Find("PlayerHealthBar");
        playerStaminaBar = GameObject.Find("PlayerStaminaBar");
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
        }
    }

    private void Update()
    {
        PlayerDeath();
    }
}
