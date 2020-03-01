using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Animator anim;
    public GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {

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
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        anim.SetFloat("distance", Vector3.Distance(gameObject.transform.position, player.transform.position));
    }    
}
