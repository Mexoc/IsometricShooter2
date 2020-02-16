using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    private float enemyMoveSpeed;
    private float enemyAggroDistance;
    private float enemyAggroAngle;
    private float enemyPatrolDistance;
    private UnityEvent enemyState = null;
    private bool enemyIsChasing = false;
    private bool enemyIsPatrolling = true;
    float timePatrol = 0f;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        EnemyIsChasing();
    }

    private void EnemyIsChasing()
    {
        enemyAggroDistance = 10;
        enemyAggroAngle = 50;
        enemyIsChasing = true;
        enemyIsPatrolling = false;
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);
        if (Vector3.Distance(player.transform.position, this.transform.position) < enemyAggroDistance && angle < enemyAggroAngle)
        {
            if (enemyMoveSpeed == 0)
            {
                enemyMoveSpeed = 0.1f;
            }
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 6f * Time.deltaTime);
            if (direction.magnitude > 5)
            {
                this.transform.Translate(0, 0, 3f * Time.deltaTime);
            }
        }
    }

    private void EnemyController()
    {

    }
}