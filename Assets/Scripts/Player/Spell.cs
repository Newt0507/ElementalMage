using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //Player Info
    [SerializeField] private PlayerInfo playerInfo;

    private void Start()
    {
        Destroy(gameObject, 2.5f);
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("MonsterWeapon"))
        {
            Destroy(gameObject);
            if (other.gameObject.tag == "Monster")
                other.gameObject.GetComponent<MonstersController>().TakeDamage(playerInfo.damage);
        }
    }
}
