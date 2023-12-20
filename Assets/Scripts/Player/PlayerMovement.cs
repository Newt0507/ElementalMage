using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    
    //Player Info
    [SerializeField] private PlayerInfo playerInfo;

    private NavMeshAgent _agent;

    //Di chuyển
    private Vector3 _direction;
    private float _horizontalInput, _verticalInput;
    private bool _isMoving;

    //Animation
    private Animator _anim;

    private void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Lấy input di chuyển với script UltimateJoystick
        _horizontalInput = UltimateJoystick.GetHorizontalAxis("Movement"); //Input.GetAxis("Horizontal");
        _verticalInput = UltimateJoystick.GetVerticalAxis("Movement"); //Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Movement();
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

    private void OnAnimatorMove()
    {
        //Animation khi di chuyển
        if (_direction == Vector3.zero)
        {
            _anim.SetBool("isMoving", false);
        }
        else
        {
            _anim.SetBool("isMoving", true);
        }
    }
}
