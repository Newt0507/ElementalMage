using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstersController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _player;
    private Animator _anim;

    [SerializeField] private LayerMask whatIsPlayer;

    [SerializeField] private int maxHp;
    private int _currentHP;
    [SerializeField] private int damage;

    //HP
    [SerializeField] private HealthBar _healthBar;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _anim = gameObject.GetComponent<Animator>();

        _currentHP = maxHp;
        _healthBar.UpdateHPBar(_currentHP, maxHp);
    }

    private void FixedUpdate()
    {
        if (_player == null)
        {
            _anim.SetBool("isMoving", false);
            _anim.SetBool("isAttacking", false);
            _agent.SetDestination(transform.position);
            return;
        }

        AttackPlayer(_agent, _player, _anim);
    }

    public virtual void AttackPlayer(NavMeshAgent agent, GameObject player, Animator anim)
    {

    }

    public void TakeDamage(int damageAmount)
    {
        //Nhận sát thương
        _currentHP -= damageAmount;
        _healthBar.UpdateHPBar(_currentHP, maxHp);

        //Hết máu thì xóa monster khỏi Scene 
        if (_currentHP <= 0)
        {
            //_anim.SetTrigger("Death");
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            PlayerController.Instance.TakeDamage(damage); ;

    }
}
