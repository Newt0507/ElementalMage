using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController: MonoBehaviour
{ 
    public MonsterController Instance { get; private set; }

    //Monster Info
    [SerializeField] private MonsterInfo monsterInfo;

    //Components
    private GameObject _player;
    private Animator _anim;

    private void Start()
    {
        Instance = this;

        _player = GameObject.FindGameObjectWithTag("Player");
        _anim = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    private void Movement()
    {
        //Trong Scene có player thì mới di chuyển
        if (_player == null) return;

        transform.LookAt(_player.transform);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, monsterInfo.speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        //Nhận sát thương
        monsterInfo.hp -= damageAmount;

        //Hết máu thì xóa monster khỏi Scene 
        if (monsterInfo.hp <= 0)
        {
            _anim.SetTrigger("isDead");
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerController.Instance.TakeDamage(monsterInfo.powerDamage);
    }

    private void OnAnimatorMove()
    {
        if (_player == null)
            _anim.SetTrigger("Idle");
    }

}
