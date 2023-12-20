using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject target;

    private void FixedUpdate()
    {
        transform.parent.position = target.transform.position + new Vector3(0, target.transform.localScale.y * 4f, 0);
    }

    public void UpdateHPBar(int currentHP, int maxHp)
    {
        slider.maxValue = maxHp;
        slider.value = currentHP;
    }
}
