using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonstersController
{
    public override void AttackPlayer(NavMeshAgent agent, GameObject player, Animator anim)
    {
        transform.LookAt(player.transform);
        agent.SetDestination(player.transform.position);
        anim.SetBool("isMoving", true);
    }
}
