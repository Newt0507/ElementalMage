using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(_currentPosition.x + target.position.x, _currentPosition.y, _currentPosition.z + target.position.z);
    }
}
