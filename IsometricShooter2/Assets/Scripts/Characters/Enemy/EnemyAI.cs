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
    private float damage = 30;
    private LineRenderer enemyShootTrace;
    public bool enemyIsShotAt;
    private float currentAmmo;
    private float enemyAmmo;
    private bool isPlayerDead;
    private bool enemyIsDead;
    private float enemyHealth;
    private float angle;
    private AudioSource enemyAudioSource;

    public GameObject GetPlayer()
    {
        return player;
    }

    void Fire()
    {
        PlayerDeathCheck();
        AmmoCheck();
        enemyAudioSource.clip = gameObject.GetComponent<EnemyAudioClips>().enemyShotClip;
        enemyAudioSource.Play();
        gunEnemy = gameObject.transform.Find("gunEnemyPos").gameObject;
        Vector3 playerPos = player.transform.position;
        playerPos.y += 2;
        Vector3 dir = playerPos - gunEnemy.transform.position;
        RaycastHit hit;
        Physics.Raycast(gunEnemy.transform.position, dir, out hit);
        if (hit.collider != null)
        {
            if (enemyShootTrace == null)
            {
                enemyShootTrace = gameObject.AddComponent<LineRenderer>();
            }            
            enemyShootTrace.startWidth = 0.015f;
            enemyShootTrace.material.color = Color.red;
            enemyShootTrace.SetPosition(0, gunEnemy.transform.position);
            enemyShootTrace.SetPosition(1, playerPos);
            StartCoroutine("EnemyShootTraceRemove");
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
        enemyHealth = gameObject.GetComponent<EnemyStats>().EnemyHealth;
        enemyAmmo = gameObject.GetComponent<EnemyStats>().enemyAmmo;
        currentAmmo = gameObject.GetComponent<EnemyStats>().currentAmmo;
        enemyIsDead = gameObject.GetComponent<EnemyStats>().enemyIsDead;
        enemyAudioSource = gameObject.GetComponent<AudioSource>();
        enemyIsShotAt = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {                   
        anim.SetFloat("distance", Vector3.Distance(gameObject.transform.position, player.transform.position));
        anim.SetBool("enemyIsShotAt", enemyIsShotAt);
        anim.SetFloat("playerInSightAngle", PlayerInSightAngle());
        anim.SetBool("isPlayerVisible", IsPlayerVisible());
    }    

    private IEnumerator EnemyShootTraceRemove()
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject.GetComponent<LineRenderer>());
    }

    private IEnumerator EnemyReload()
    {
        StopShooting();
        enemyAudioSource.clip = gameObject.GetComponent<EnemyAudioClips>().enemyReloadClip;
        enemyAudioSource.Play();
        yield return new WaitForSeconds(2f);
        currentAmmo = enemyAmmo;
        StartShooting();
    }

    private void AmmoCheck()
    {              
        if (currentAmmo > 0)
        {
        currentAmmo -= 1;
        }
        else
        {
            StartCoroutine("EnemyReload");
        }
    }

    private void PlayerDeathCheck()
    {
        isPlayerDead = player.GetComponent<PlayerStats>().isPlayerDead;
        if (isPlayerDead)
        {
            StopShooting();
        }
    }

    private float PlayerInSightAngle()
    {
        Vector3 playerDir = player.transform.position - this.transform.position;
        angle = Vector3.Angle(playerDir, this.transform.forward);
        return angle;
    }

    private bool IsPlayerVisible()
    {
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+2, gameObject.transform.position.z), gameObject.transform.forward*50);    
        if (Physics.Raycast(ray, out hit, 50) == false)
        {
            return false;
        }
        else 
            if (hit.collider.gameObject.tag == "Player" || hit.collider.gameObject.tag == "Gun" || hit.collider.gameObject.tag == "PlayerBody" || hit.collider.gameObject.tag == "GunBarrel" || hit.collider.gameObject.tag == "PlayerMisc")
            {
                return true;
            }
            else
                return false;        
    }
}
