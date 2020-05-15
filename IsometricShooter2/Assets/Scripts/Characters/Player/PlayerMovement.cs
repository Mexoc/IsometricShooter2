using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement: MonoBehaviour
{
    private GameObject player;
    private float horizontal;
    private float vertical;
    [SerializeField]
    private float currentSpeed;
    private float baseSpeed;
    private float gravity = -0.001f;
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
    private Vector3 mousePos;
    private Vector3 mouseVector;
    private float mouseAngle;
    private bool isLookingAside;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        playerRigidBody = player.GetComponent<Rigidbody>();
        dirVert = Vector3.forward + Vector3.right;
        dirHor = Vector3.forward + Vector3.left;     
        baseSpeed = 2f * Time.deltaTime;
        currentSpeed = baseSpeed;
    }

    private void Update()
    {       
        PlayerMove();
        PlayerSprint();
        PlayerAnimationSet();
        PlayerMouseViewAngle();
    }

    private void PlayerMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal != 0)
        {
            player.transform.Translate(-horizontal * dirHor * currentSpeed);
        }
        if (vertical != 0)
        {
            player.transform.Translate(vertical * dirVert * currentSpeed);
        }
        player.transform.Translate(0, gravity, 0);
    } 

    private float PlayerMouseViewAngle()
    {
        mousePos = gameObject.GetComponent<PlayerTurn>().mousePoint;
        Vector3 origin = (dirHor * 10000) - player.transform.position;
        mouseVector = mousePos - player.transform.position;
        mouseAngle = Vector3.Angle(origin, mouseVector);
        return mouseAngle;
    }

    private void PlayerSprint()
    {
        var sprintSpeed = 6f * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift) && (horizontal != 0 || vertical != 0))
        {
            
            if (player.GetComponent<PlayerStats>().playerStamina <= 0)
            {
                player.GetComponent<PlayerStats>().playerStamina = 0;
                isSprint = false;
                currentSpeed = baseSpeed;
                return;
            }
            else
            {
                isSprint = true;
                currentSpeed = sprintSpeed;
                player.GetComponent<PlayerStats>().playerStamina -= Time.deltaTime * 20;
                player.GetComponent<PlayerStats>().playerStaminaBar.GetComponent<Image>().fillAmount -= Time.deltaTime * 0.2f;
            }
        }        
        else if (Input.GetKey(KeyCode.LeftShift) == false)
        {            
            isSprint = false;
            currentSpeed = baseSpeed;
            if (player.GetComponent<PlayerStats>().playerStamina >= 100)
            {
                player.GetComponent<PlayerStats>().playerStamina = 100;
            }
            player.GetComponent<PlayerStats>().playerStamina += Time.deltaTime * 40;
            player.GetComponent<PlayerStats>().playerStaminaBar.GetComponent<Image>().fillAmount += Time.deltaTime * 0.4f;
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
        if ((mouseAngle > 135 && mouseAngle < 180) || (mouseAngle > 0 && mouseAngle < 45))
        {
            isLookingAside = true;
        }
        else
            isLookingAside = false;
        playerAnim.SetBool("isHorizontalMove", isHorizontalMove);
        playerAnim.SetBool("isVerticalMove", isVerticalMove);
        playerAnim.SetBool("isSprint", isSprint);
        playerAnim.SetBool("isLookingAside", isLookingAside);
    }
}
