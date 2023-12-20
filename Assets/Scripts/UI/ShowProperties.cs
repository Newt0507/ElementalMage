using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowProperties : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private TMP_Text txtEnergy;
    [SerializeField] private TMP_Text txtGold;
    [SerializeField] private TMP_Text txtGem;

    private void Update()
    {
        txtEnergy.text = playerInfo.energy.ToString() + " / 20";
        txtGold.text = playerInfo.gold.ToString("N0");
        txtGem.text = playerInfo.gem.ToString("N0");

    }

}
