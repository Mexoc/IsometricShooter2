using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyBaseFSM
{
    private Vector3 direction;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        enemy.GetComponent<EnemyAI>().StartShooting();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = opponent.transform.position - enemy.transform.position;
        direction.y = 0;
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.GetComponent<EnemyAI>().StopShooting();
    }    
}
