using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PackManager: MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private ShopPack shopPack;

    [SerializeField] private TMP_Text txtGem;
    [SerializeField] private TMP_Text txtGold;

    private void Start()
    {
        txtGem.text = shopPack.packCost.ToString("N0");
        txtGold.text = shopPack.packReward.ToString("N0");        
    }
    private void Update()
    {
        if (playerInfo.gem >= shopPack.packCost)
            txtGem.color = Color.white;
        else
            txtGem.color = Color.red;
    }

    public void PurchaseGemToGold()
    {
        SoundManager.Instance.PlayEffect();
        if (playerInfo.gem >= shopPack.packCost)
        {
            playerInfo.gem -= shopPack.packCost;
            playerInfo.gold += shopPack.packReward;
            playerInfo.CheckMaxValue();
        }
    }
}
