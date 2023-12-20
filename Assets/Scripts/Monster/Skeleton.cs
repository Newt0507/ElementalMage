using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonstersController
{
    [SerializeField] private LayerMask whatIsGround;

    //Patroling
    [SerializeField] private float walkPointRange;
    private Vector3 _walkPoint;
    private bool _walkPointSet;


    //Attacking
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform spawnArrowPoint;
    [SerializeField] private float arrowSpeed;
    [SerializeField] private float timeBetweenAttacks;
    private bool _alreadyAttacked;

    public override void AttackPlayer(NavMeshAgent agent, GameObject player, Animator anim)
    {

        if (!_walkPointSet) SearchWalkPoint();

        Debug.DrawLine(transform.position, _walkPoint);

        if (_walkPointSet)
        {
            transform.LookAt(_walkPoint);
            agent.SetDestination(_walkPoint);
            anim.SetBool("isMoving", true);
            anim.SetBool("isAttacking", false);
        }

        Vector3 distanceToWalkPoint = transform.position - _walkPoint;

        if (distanceToWalkPoint.magnitude < 1f || !CheckDestination(agent, _walkPoint))
        {
            agent.SetDestination(transform.position);
            transform.LookAt(player.transform);
            anim.SetBool("isMoving", false);
            anim.SetBool("isAttacking", true);

            if (!_alreadyAttacked)
            {
                GameObject arrow = Instantiate(arrowPrefab, spawnArrowPoint.position, Quaternion.identity);

                arrow.transform.LookAt(player.transform);
                arrow.GetComponent<Rigidbody>().velocity = spawnArrowPoint.forward * arrowSpeed;

                _alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
            _walkPointSet = false;
        }

    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        _walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        _walkPointSet = true;
    }

    private bool CheckDestination(NavMeshAgent agent, Vector3 targetDestination)
    {
        if (NavMesh.SamplePosition(targetDestination, out NavMeshHit hit, 1f, NavMesh.AllAreas))
        {
            //agent.SetDestination(hit.position);
            return true;
        }
        return false;
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }


}
