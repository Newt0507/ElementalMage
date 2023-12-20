using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCube : MonoBehaviour
{
    [SerializeField] private int cubeDamage;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("MonsterWeapon") ||
            other.gameObject.layer != LayerMask.NameToLayer("Power") ||
            other.gameObject.layer != LayerMask.NameToLayer("WhatIsGround"))
        {
            Destroy(gameObject);
            if (other.gameObject.tag == "Player")
                PlayerController.Instance.TakeDamage(cubeDamage);

            if (other.gameObject.tag == "Monster")
                other.gameObject.GetComponent<MonstersController>().TakeDamage(cubeDamage);
        }
    }

}
