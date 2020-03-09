using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;
    public GameObject bulletHole;
    private GameObject gunEnemy;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        gunEnemy = GameObject.FindGameObjectWithTag("GunEnemy");
        Vector3 playerPos = player.transform.position;
        playerPos.y += 2;
        Vector3 dir = playerPos - gunEnemy.transform.position;
        //Ray ray = new Ray(gunEnemy.transform.position, dir);
        RaycastHit hit;
        Physics.Raycast(gunEnemy.transform.position, dir, out hit);
        if (hit.collider != null)
        {
            var temp = Instantiate(bulletHole, hit.point, Quaternion.identity);
            temp.transform.SetParent(hit.collider.transform);
            Destroy(temp, 1f);
        }
    }

    public void StartShooting()
    {
        InvokeRepeating("Fire", 1f, 1f);
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
    }

    // Update is called once per frame
    void Update()
    {
        //if (player == null)
        //    player = GameObject.FindGameObjectWithTag("Player");
        anim.SetFloat("distance", Vector3.Distance(gameObject.transform.position, player.transform.position));
    }    
}
