using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    [SerializeField] private GameObject restoreEnergy;
    [SerializeField] private GameObject userInfo;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject rate;

    private void Start()
    {
        HideRestoreEnergyPopup();
        HideUserInfoPopup();
        HideSettingPopup();
        HideRatePopup();
    }

    public void LoadRestoreEnergyPopup()
    {
        restoreEnergy.SetActive(true);
    }
    
    public void HideRestoreEnergyPopup()
    {
        restoreEnergy.SetActive(false);
    }
    
    public void LoadUserInfoPopup()
    {
        restoreEnergy.SetActive(true);
    }

    public void HideUserInfoPopup()
    {
        restoreEnergy.SetActive(false);
    }

    public void LoadSettingPopup()
    {
        setting.SetActive(true);
    }
    
    public void HideSettingPopup()
    {
        setting.SetActive(false);
    }

    public void LoadRatePopup()
    {
        rate.SetActive(true);
    }

    public void HideRatePopup()
    {
        rate.SetActive(false);
    }



    public void LoadRewardScene()
    {
        LoadSceneController.Instance.RewardSceneOnLoad();
    }

    public void LoadStageScene()
    {
        LoadSceneController.Instance.StageSceneOnLoad();
    }

    public void LoadShopScene()
    {
        LoadSceneController.Instance.ShopSceneOnLoad();
    }

    public void LoadPowerScene()
    {
        LoadSceneController.Instance.PowerSceneOnLoad();
    }

}
