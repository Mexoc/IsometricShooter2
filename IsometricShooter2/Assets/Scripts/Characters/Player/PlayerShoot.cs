using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private GameObject player;
    public bool isPlayerShooting;
    public bool canPlayerShoot;
    public GameObject shootingResult;
    private GameObject playerGunBarrel;
    private Vector3 collisionPoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canPlayerShoot = false;
    }

    void Update()
    {
        PlayerShooting();        
    }    

    private void PlayerShooting()
    {
        if (playerGunBarrel == null)
        {
            playerGunBarrel = GameObject.FindGameObjectWithTag("GunBarrel");
        }
        if (Input.GetMouseButtonDown(0))
        {
            isPlayerShooting = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag != "Player" && hit.collider.gameObject.tag != "Gun" && hit.collider.gameObject.tag != "PlayerBody" && hit.collider.gameObject.tag != "GunBarrel")
                {
                    Vector3 shootDirection = hit.point - playerGunBarrel.transform.position;
                    RaycastHit gunHit;
                    if (Physics.Raycast(playerGunBarrel.transform.position, shootDirection, out gunHit))
                    {
                        isPlayerShooting = true;
                        GameObject temp = Instantiate(shootingResult, gunHit.point, Quaternion.identity);
                        Vector3 tempScale = temp.transform.localScale;
                        temp.transform.LookAt(player.transform);
                        temp.transform.SetParent(gunHit.transform, true);
                        if (gunHit.collider.gameObject.tag == "Ground")
                        {
                            temp.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
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
}
