using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private GameObject player;
    private float horizontal;
    private float vertical;
    private float speed;
    private float gravity;
    private float jumpForce;
    private Rigidbody playerRigidBody;
    private Vector3 dirVert;
    private Vector3 dirHor;
    private bool canJump;
    private GameObject ground;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        playerRigidBody = player.GetComponent<Rigidbody>();
        dirVert = Vector3.forward + Vector3.right;
        dirHor = Vector3.forward + Vector3.left;     
        speed = 2f * Time.deltaTime;
    }

    private void Update()
    {
        PlayerMove();
        PlayerSprint();
    }

    private void PlayerMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0)
        {
            player.transform.Translate(-horizontal * dirHor * speed);
        }
        if (vertical != 0)
        {
            player.transform.Translate(vertical * dirVert * speed);
        }
        player.transform.Translate(0, gravity, 0);
    } 

    private void PlayerSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += 0.04f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= 0.04f;
        }
    }
    
}
