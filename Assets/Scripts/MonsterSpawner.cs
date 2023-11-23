using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monster;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Instantiate(monster, transform.position, Quaternion.identity).transform.parent = transform;
    }
}
