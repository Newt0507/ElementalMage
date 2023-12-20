using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonstersController
{
    //[SerializeField] private GameObject spawnMonsterArea;
    [SerializeField] private GameObject monsterSpawner;
    [SerializeField] private GameObject[] monsterPrefabs;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float timeBetweenAttacks;

    private bool _isSummonning;

    private float _lastAttack = 0f;
    private float _delayTime = 20f;

    private bool _alreadyAttacked = false;

    public override void AttackPlayer(NavMeshAgent agent, GameObject player, Animator anim)
    {
        transform.LookAt(player.transform);
        
        if (!_isSummonning)
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("isSummonning", false);
            BaseAttack();
            _isSummonning = true;
        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isSummonning", true);

            if (Time.time >= _lastAttack + _delayTime)
            {
                SpawnMonster();
                UpdateCastSpellTime();
            }
            _isSummonning = false;
        }

    }

    private Vector3 GetRandomPosition(float y)
    {
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 6);

        Vector3 position = new Vector3(x, y, z);
        return position;
    }

    private GameObject GetSpawnMonster()
    {
        GameObject spawnMonster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        return spawnMonster;
    }

    private void SpawnMonster()
    {
        Instantiate(GetSpawnMonster(), GetRandomPosition(1), Quaternion.identity).transform.SetParent(monsterSpawner.transform);
        Instantiate(GetSpawnMonster(), GetRandomPosition(1), Quaternion.identity).transform.SetParent(monsterSpawner.transform);
        Instantiate(GetSpawnMonster(), GetRandomPosition(1), Quaternion.identity).transform.SetParent(monsterSpawner.transform);
    }

    private void BaseAttack()
    {
        if (!_alreadyAttacked)
        {
            Instantiate(projectile, GetRandomPosition(10), Quaternion.Euler(180, 0, 0));
            Instantiate(projectile, GetRandomPosition(10), Quaternion.Euler(180, 0, 0));
            Instantiate(projectile, GetRandomPosition(10), Quaternion.Euler(180, 0, 0));

            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void UpdateCastSpellTime()
    {
        _lastAttack = Time.time;
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    private void NextAttack()
    {
        _alreadyAttacked = false;
    }

}
