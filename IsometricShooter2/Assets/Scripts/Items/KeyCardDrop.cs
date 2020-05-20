using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDrop : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject enemyWithKeyCard;
    private bool iskeycardDropped = false;
    
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyWithKeyCard = EnemyWithKeyCard(enemies);
    }

    void LateUpdate()
    {
        KeyCardDropCheck();
    }

    private GameObject EnemyWithKeyCard(GameObject[] enemies)
    {
        int num = Random.Range(0, enemies.Length);
        return enemies[num];
    }

    private void KeyCardDropCheck()
    {
        if (iskeycardDropped == true)
            return;
        if (enemyWithKeyCard.GetComponent<EnemyStats>().enemyIsDead)
        {
            enemyWithKeyCard.GetComponent<EnemyStats>().DropKeycard();
            iskeycardDropped = true;
        }
    }
}
