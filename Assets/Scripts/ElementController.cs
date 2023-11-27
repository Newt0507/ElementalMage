using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{
    [SerializeField] private ElementInfo elementInfo;

    private Vector3 _currentPosition;

    private void Start()
    {
        _currentPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(_currentPosition.x, Mathf.Sin(Time.time) * 0.25f + _currentPosition.y, _currentPosition.z);
        //transform.Rotate(0f, 20 * Time.fixedDeltaTime, 0f, Space.Self);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            ChooseElementController.Instance.ShowElementInfo(elementInfo);
        else
            ChooseElementController.Instance.HideElementInfo();
    }
}
