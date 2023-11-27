using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    
    //Player Info
    [SerializeField] private PlayerInfo playerInfo;

    //Di chuyển
    private Vector3 _direction;
    private Rigidbody _rb;

    //Animation
    private Animator _anim;

    //Tấn công
    [SerializeField] private GameObject monsterSpawner;
    private Dictionary<GameObject, float> _lstMonster;


    private void Start()
    {
        Instance = this;

        playerInfo.ResetData();

        _rb = gameObject.GetComponent<Rigidbody>();
        _anim = gameObject.GetComponent<Animator>();
        _lstMonster = new Dictionary<GameObject, float>();
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        //Lấy input di chuyển
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        //Giữ nguyên hướng nếu k di chuyển
        if (_direction == Vector3.zero) return;

        //Lấy góc xoay 
        Quaternion targetRotation = Quaternion.LookRotation(_direction);

        //Di chuyển theo hướng của input
        _rb.MovePosition(_rb.position + _direction * playerInfo.speed * Time.fixedDeltaTime);
        _rb.MoveRotation(targetRotation); //Xoay player theo hướng di chuyển
    }

    private void GetMonsters()
    {
        //Tạo 1 dict với key là monster và value = khoảng cách từ monster đó đến player
        foreach (Transform monster in monsterSpawner.transform)
            if (monster.tag == "Monster" && monster.gameObject.activeSelf)
            {
                float distance = Vector3.Distance(monster.position, transform.position);
                _lstMonster[monster.gameObject] = distance;
            }
    }

    private void Attack()
    {
        //Chỉ khi player k di chuyển thì mới đc tấn công
        if (_direction != Vector3.zero) return;

        //Nếu trong Scene có monster thì tiếp tục tấn công
        if (monsterSpawner.transform.childCount <= 0) return;

        //Lấy dữ liệu và cập nhật khoảng cách
        GetMonsters();

        //Sắp xếp _lstMonster theo thứ tự tăng dần về khoảng cách của monster đối với player
        //Sau đó lấy giá trị khoảng cách đầu tiên (giá trị nhỏ nhất)
        GameObject monsterNearest = _lstMonster.OrderBy(k => k.Value).FirstOrDefault().Key;
       
        //Hướng player về vị trí monster có khoảng cách nhỏ nhất đó
        transform.LookAt(monsterNearest.transform);        
    }

    public void TakeDamage(int damageAmount)
    {
        //Nhận sát thương
        playerInfo.currentHp -= damageAmount;

        //Hết máu thì xóa player khỏi Scene 
        if (playerInfo.currentHp <= 0)
            Destroy(gameObject);
    }

    public void Heal(int healAmount)
    {
        //Hồi máu
        playerInfo.currentHp += healAmount;

        //Nếu hồi quá _maxHP thì k tăng
        if (playerInfo.currentHp >= playerInfo.maxHp)
            playerInfo.currentHp = playerInfo.maxHp;
    }

    private void OnAnimatorMove()
    {
        //Animation khi di chuyển
        if (_direction == Vector3.zero)
        {
            _anim.SetBool("isMoving", false);
            _anim.SetBool("isAttacking", false);

            //Amimation tấn công khi còn monster trong Scene
            if (monsterSpawner.transform.childCount > 0)
                _anim.SetBool("isAttacking", true);
        }
        else
        {
            _anim.SetBool("isMoving", true);
            _anim.SetBool("isAttacking", false);
        }
    }
}
