using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementMovement: MonoBehaviour
{
    [SerializeField] private ElementInfo elementInfo;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    void FixedUpdate()
    {
        //sử dụng hàm Sin để nguyên tố chuyển động lên xuống theo trục y (độ cao)
        transform.position = new Vector3(_currentPosition.x, Mathf.Sin(Time.time) * 0.25f + _currentPosition.y, _currentPosition.z);
        //transform.Rotate(0f, 20 * Time.fixedDeltaTime, 0f, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            ChooseElementController.Instance.ShowElementInfo(elementInfo);
    }

    private void OnTriggerExit(Collider other)
    {
        ChooseElementController.Instance.HideElementInfo();
    }
}
