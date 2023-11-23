using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController: MonoBehaviour
{ 
    public MonsterController Instance { get; private set; }

    //Monster Info
    [SerializeField] private MonsterInfo _monsterInfo;

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
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _monsterInfo.speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        //Nhận sát thương
        _monsterInfo.hp -= damageAmount;

        //Hết máu thì xóa monster khỏi Scene 
        if (_monsterInfo.hp <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayerController.Instance.TakeDamage(_monsterInfo.powerDamage);
    }

    private void OnAnimatorMove()
    {
        if (_player == null)
            _anim.SetTrigger("Idle");
    }

}
