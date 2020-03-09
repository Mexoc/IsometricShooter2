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
    public Animator playerAnim;
    public bool isHorizontalMove;
    public bool isVerticalMove;
    public bool isSprint;
    private float sprintSpeed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        playerRigidBody = player.GetComponent<Rigidbody>();
        dirVert = Vector3.forward + Vector3.right;
        dirHor = Vector3.forward + Vector3.left;     
        speed = 1f * Time.deltaTime;
        sprintSpeed = 0.03f;
    }

    private void Update()
    {
        PlayerMove();
        PlayerSprint();
        PlayerAnimationSet();
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
            speed += sprintSpeed;
            isSprint = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= sprintSpeed;
            isSprint = false;
        }
    }

    private void PlayerAnimationSet()
    {
        if (playerAnim == null)
            playerAnim = gameObject.GetComponent<Animator>();
        if (horizontal != 0)
            isHorizontalMove = true;
        else
            isHorizontalMove = false;
        if (vertical != 0)
            isVerticalMove = true;
        else
            isVerticalMove = false;
        playerAnim.SetBool("isHorizontalMove", isHorizontalMove);
        playerAnim.SetBool("isVerticalMove", isVerticalMove);
        playerAnim.SetBool("isSprint", isSprint);
    }
    
}
