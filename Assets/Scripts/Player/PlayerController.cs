using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    private NavMeshAgent _agent;

    //Player Info
    [SerializeField] private PlayerInfo playerInfo;

    //Vật liệu
    [SerializeField] private Transform spawnSpellPoint;
    [SerializeField] private GameObject elementBall;
    [SerializeField] private GameObject[] lstPowers;
    [SerializeField] private Material[] lstMaterials;
    private GameObject _power;

    //Di chuyển
    private Vector3 _direction;
    private float _horizontalInput, _verticalInput;
    private bool _isMoving;
    private bool _isAttacking;

    //private Rigidbody _rb;

    //Animation
    private Animator _anim;

    //Tấn công
    [SerializeField] private GameObject monsterSpawner;
    [SerializeField] private float spellSpeed;
    private float _castSpellTime = 0.5f;
    private float _lastCastSpellTime = 0f;

    //HP
    [SerializeField] private HealthBar _healthBar;

    private void Start()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;

        _agent = gameObject.GetComponent<NavMeshAgent>();
        _anim = gameObject.GetComponent<Animator>();

        SetElement(playerInfo.element);
        UpdateCastSpellTime();

        _agent.speed = playerInfo.speed;
        _healthBar.UpdateHPBar(playerInfo.currentHp, playerInfo.maxHp);

    }

    private void Update()
    {
        //Lấy input di chuyển với script UltimateJoystick
        _horizontalInput = UltimateJoystick.GetHorizontalAxis("Movement"); //Input.GetAxis("Horizontal");
        _verticalInput = UltimateJoystick.GetVerticalAxis("Movement"); //Input.GetAxis("Vertical");

        Attack();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    //gán element theo power player chọn
    private void SetElement(string element)
    {
        switch(element)
        {
            case "Fire":
                elementBall.GetComponent<Renderer>().material = lstMaterials[0];
                break;
            case "Water":
                elementBall.GetComponent<Renderer>().material = lstMaterials[1];
                break;
            default:
                elementBall.GetComponent<Renderer>().material = lstMaterials[2];
                break;
        }


        foreach (var power in lstPowers)
        {
            if (power.tag == element)
            {
                _power = power;
            }
        }
    }

    private void Movement()
    {
        _direction = new Vector3(_horizontalInput, 0, _verticalInput).normalized;

        transform.LookAt(transform.position + _direction);
        _agent.Move(_direction * _agent.speed * Time.fixedDeltaTime);

        if (_direction == Vector3.zero)
            _isMoving = false;
        else
            _isMoving = true;

        SoundManager.Instance.SetMovingSound(_isMoving);
    }

    public GameObject GetNearestMonster()
    {
        Dictionary<GameObject, float> _lstMonster = new Dictionary<GameObject, float>();

        //Tạo 1 dict với key là monster và value = khoảng cách từ monster đó đến player
        foreach (Transform monster in monsterSpawner.transform)
        {
            float distance = Vector3.Distance(monster.GetChild(1).position, transform.position);

            //_lstMonster.Add(monster.gameObject, distance);
            _lstMonster[monster.GetChild(1).gameObject] = distance;

        }

        GameObject monsterNearest = _lstMonster.OrderBy(k => k.Value).FirstOrDefault().Key;

        return monsterNearest;
    }

    private void Attack()
    {
        SoundManager.Instance.SetAttackingSound(_isAttacking);

        //Chỉ khi player k di chuyển thì mới đc tấn công
        if (_direction != Vector3.zero)
        {
            _isAttacking = false;
            return;
        }

        //Nếu trong Scene có monster thì tiếp tục tấn công
        if (monsterSpawner.transform.childCount <= 0)
        {
            _isAttacking = false;
            return;
        }

        GameObject _currentTarget = GetNearestMonster();
        if (_currentTarget == null)
        {
            _isAttacking = false;
            return;
        }
                   
        //Hướng player về vị trí monster có khoảng cách nhỏ nhất đó 
        transform.LookAt(_currentTarget.transform.position);

        _isAttacking = true;
        CastSpell();
    }

    private void UpdateCastSpellTime()
    {
        _lastCastSpellTime = Time.time;
    }

    private void CastSpell()
    {
        if (Time.time >= _lastCastSpellTime + _castSpellTime)
        {
            GameObject spell = Instantiate(_power, spawnSpellPoint.position, Quaternion.identity);
            spell.GetComponent<Rigidbody>().velocity = spawnSpellPoint.forward * spellSpeed;
            UpdateCastSpellTime();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        //Nhận sát thương
        playerInfo.currentHp -= damageAmount;
        _healthBar.UpdateHPBar(playerInfo.currentHp, playerInfo.maxHp);

        SoundManager.Instance.SetHittingSound();

        //Hết máu thì xóa player khỏi Scene 
        if (playerInfo.currentHp <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
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
