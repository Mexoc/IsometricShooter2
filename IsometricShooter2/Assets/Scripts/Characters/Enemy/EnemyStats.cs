using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private float enemyHealth = 100;

    public float EnemyHealth
    {
        get { return enemyHealth; }
        set { enemyHealth = value; }
    }

    private void Update()
    {
        //Debug.Log("Enemy health is "+EnemyHealth);
        EnemyIsDead();
    }

    public void EnemyIsDead()
    {
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
}
