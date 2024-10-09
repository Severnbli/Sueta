using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehavior : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange = 2f;
    float chaseRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 4;

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < attackRange)
        {
            animator.SetBool("isAttacking", true);
        }

        if (distance > chaseRange)
        {
            AudioSource audioSource = agent.GetComponent<AudioSource>();
            audioSource.Stop();
            animator.SetBool("isChasing", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 2;
    }
}
