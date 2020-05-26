using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    private GameObject player;
    public bool isPlayerShooting;
    public bool canPlayerShoot;
    public GameObject shootingResult;
    private GameObject playerGunBarrel;
    private Vector3 collisionPoint;
    public Animator playerAnim;
    private PlayerMovement playerMoveComponent;
    public bool playerCanShoot;
    private GameObject bulletDisplay;
    private int bulletCount;
    private int maxAmmo;
    private LineRenderer bulletTraceLine;
    private AudioSource audioSource;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.GetComponent<AudioSource>();
        playerCanShoot = true;
        canPlayerShoot = false;
        maxAmmo = 9;
        bulletCount = maxAmmo;
        
    }

    void Update()
    {
        BulletCount();
        PlayerShooting();        
    }    

    private void PlayerShooting()
    {
        if (playerGunBarrel == null)
        {
            playerGunBarrel = GameObject.FindGameObjectWithTag("GunBarrel");
        }
        if (playerMoveComponent == null)
        {
            playerMoveComponent = gameObject.GetComponent<PlayerMovement>();
        }
        if (bulletTraceLine == null)
        {
            bulletTraceLine = gameObject.AddComponent<LineRenderer>();
            bulletTraceLine.startColor = Color.blue;
            bulletTraceLine.endColor = Color.blue;
            bulletTraceLine.material.color = Color.blue;
            bulletTraceLine.startWidth = 0.015f;
        }
        if (Input.GetMouseButtonDown(0) && playerMoveComponent.isVerticalMove || playerMoveComponent.isHorizontalMove || playerMoveComponent.isSprint)
            return;
        if (playerCanShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPlayerShooting = true;
                bulletCount -= 1;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {                    
                    if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Gun" && hit.collider.gameObject.tag != "PlayerBody" && hit.collider.gameObject.tag != "GunBarrel" && hit.collider.gameObject.tag != "PlayerMisc")
                    {
                        Vector3 shootDirection = hit.point - playerGunBarrel.transform.position;
                        RaycastHit gunHit;                               
                        if (Physics.Raycast(playerGunBarrel.transform.position, shootDirection, out gunHit))
                        {
                            audioSource.clip = gameObject.GetComponent<PlayerAudioClips>().shootingClip;
                            audioSource.Play();
                            bulletTraceLine.SetPosition(0, playerGunBarrel.transform.position);
                            bulletTraceLine.SetPosition(1, gunHit.point);
                            StartCoroutine("BulletLineTraceDisappear");
                            GameObject temp = Instantiate(shootingResult, gunHit.point, Quaternion.identity);
                            Vector3 tempScale = temp.transform.localScale;
                            temp.transform.LookAt(player.transform);
                            temp.transform.SetParent(gunHit.transform, true);
                            if (gunHit.collider.gameObject.tag == "Ground")
                            {
                                temp.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
                            }
                            if (gunHit.collider.gameObject.tag == "Enemy" || gunHit.collider.gameObject.tag == "EnemyMisc")
                            {
                                //gunHit.collider.gameObject.GetComponent<EnemyAI>().enemyIsShotAt = true;
                                gunHit.collider.gameObject.GetComponent<EnemyStats>().EnemyHealth -= 20;
                            }
                            Destroy(temp, 1f);
                        }
                    }
                }
            }
            else
            {
                isPlayerShooting = false;
            }
        }
        else return;
    }

    private void ShootingAnimationSet()
    {
        if (playerAnim == null)
            playerAnim = gameObject.GetComponent<PlayerMovement>().playerAnim;
        playerAnim.SetBool("isPlayerShooting", isPlayerShooting);
    }

    private void BulletCount()
    {
        if (bulletDisplay == null)
        {
            bulletDisplay = GameObject.Find("PistolAmmo");
        }
        if (bulletCount == 0)
        {
            playerCanShoot = false;
        }
        else
        {
            playerCanShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("Reload");
        }
        bulletDisplay.GetComponent<Text>().text = bulletCount + "/" + maxAmmo;
    }

    private IEnumerator Reload()
    {
        audioSource.clip = gameObject.GetComponent<PlayerAudioClips>().reloadClip;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        bulletCount = maxAmmo;
    }

    private IEnumerator BulletLineTraceDisappear()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject.GetComponent<LineRenderer>());
    }
}
