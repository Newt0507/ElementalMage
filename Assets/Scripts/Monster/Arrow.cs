using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private int arrowDamage;

    private void Start()
    {
        Destroy(gameObject, 2.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Power") ||
            collision.gameObject.layer != LayerMask.NameToLayer("MonsterWeapon") ||
            collision.gameObject.tag != "Monster")
        {
            Destroy(gameObject);
            if (collision.gameObject.tag == "Player")
                PlayerController.Instance.TakeDamage(arrowDamage);
        }
    }
}
