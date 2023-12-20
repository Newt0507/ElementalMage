using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowElement : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private TMP_Text txtElement;

    private void Start()
    {
        txtElement.text = playerInfo.element;
    }
}
