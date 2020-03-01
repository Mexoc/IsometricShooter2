using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseFSM : StateMachineBehaviour
{
    public GameObject enemy;
    public GameObject opponent;
    public float speed = 5f;
    public float rotSpeed = 5f;
    public float movementAccuracy = 3f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject;
        opponent = enemy.GetComponent<EnemyAI>().GetPlayer();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
    }
}
