using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    void FixedUpdate()
    {        
        transform.position = new Vector3(_currentPosition.x + player.position.x, _currentPosition.y, _currentPosition.z + player.position.z);
    }
}
