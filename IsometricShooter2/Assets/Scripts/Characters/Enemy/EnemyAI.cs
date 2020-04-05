using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bulletHole;
    private GameObject gunEnemy;
    private float health;
    private float damage = 30;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        gunEnemy = gameObject.transform.Find("gunEnemyPos").gameObject;
        Vector3 playerPos = player.transform.position;
        playerPos.y += 2;
        Vector3 dir = playerPos - gunEnemy.transform.position;
        RaycastHit hit;
        Physics.Raycast(gunEnemy.transform.position, dir, out hit);
        if (hit.collider != null)
        {            
            var temp = Instantiate(bulletHole, hit.point, Quaternion.identity);
            temp.transform.SetParent(hit.collider.transform);
            Destroy(temp, 1f);
            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Gun" || hit.collider.gameObject.tag == "PlayerBody" || hit.collider.gameObject.tag == "GunBarrel" || hit.collider.gameObject.tag == "PlayerMisc")
            {
                player.GetComponent<PlayerStats>().PlayerHealth -= damage;
                player.GetComponent<PlayerStats>().playerHealthBar.GetComponent<Image>().fillAmount -= damage * 0.01f;
            }
        }
    }

    public void StartShooting()
    {
        InvokeRepeating("Fire", 1f, 0.2f);
    }

    public void StopShooting()
    {
        CancelInvoke("Fire");
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();  
        player = GameObject.FindGameObjectWithTag("Player");
        health = gameObject.GetComponent<EnemyStats>().EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {     
        anim.SetFloat("distance", Vector3.Distance(gameObject.transform.position, player.transform.position));
    }    
}
