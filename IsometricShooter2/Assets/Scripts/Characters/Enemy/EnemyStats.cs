using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float enemyHealth = 100;
    public float enemyAmmo = 25;
    public float currentAmmo;
    public bool enemyIsDead = false;
    private Animator anim;

    public float EnemyHealth
    {
        get { return enemyHealth; }
        set { enemyHealth = value; }
    }

    private void Start()
    {
        currentAmmo = enemyAmmo;
    }

    private void Update()
    {
        EnemyDead();
    }

    public void EnemyDead()
    {
        if (enemyHealth <= 0)
        {
            GameObject temp;
            enemyIsDead = true;
            Vector3 tempRot = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 90);
            Destroy(gameObject.GetComponent<Rigidbody>());
            Destroy(gameObject.GetComponent<EnemyAI>());
            Destroy(gameObject.GetComponent<EnemyStats>());
            Destroy(gameObject.GetComponent<LineRenderer>());
            gameObject.GetComponent<Animator>().enabled = false;
            temp = gameObject.transform.Find("minimapIcon").gameObject;
            temp.SetActive(false);
            gameObject.tag = "Untagged";
            gameObject.transform.eulerAngles = tempRot;            
        }
    }
}
