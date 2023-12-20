using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public static HomeController Instance { get; private set; }

    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip battleMusic;

    [SerializeField] private GameObject restoreEnergy;
    //[SerializeField] private GameObject userInfo;
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject rate;
    [SerializeField] private TMP_Text txtEnergyCost;

    private void Start()
    {
        Instance = this;
        restoreEnergy.SetActive(false);
        //userInfo.SetActive(false);
        setting.SetActive(false);
        rate.SetActive(false);

        SoundManager.Instance.PlayMusic(backgroundMusic);
    }

    private void Update()
    {
        if (playerInfo.gold >= 2500)
            txtEnergyCost.color = Color.white;
        else
            txtEnergyCost.color = Color.red;

    }

    /*--------------POP UP--------------*/

    public void LoadRestoreEnergyPopup()
    {
        SoundManager.Instance.PlayEffect();
        restoreEnergy.SetActive(true);
    }
    
    public void HideRestoreEnergyPopup()
    {
        SoundManager.Instance.PlayEffect();
        restoreEnergy.SetActive(false);
    }
    
    /*public void LoadUserInfoPopup()
    {
        SoundManager.Instance.PlayEffect();
        userInfo.SetActive(true);
    }

    public void HideUserInfoPopup()
    {
        SoundManager.Instance.PlayEffect();
        userInfo.SetActive(false);
    }*/

    public void LoadSettingPopup()
    {
        SoundManager.Instance.PlayEffect();
        setting.SetActive(true);
    }
    
    public void HideSettingPopup()
    {
        SoundManager.Instance.PlayEffect();
        setting.SetActive(false);
    }

    public void LoadRatePopup()
    {
        SoundManager.Instance.PlayEffect();
        rate.SetActive(true);
    }

    public void HideRatePopup()
    {
        SoundManager.Instance.PlayEffect();
        rate.SetActive(false);
    }

    public void BuyEnergy()
    {
        SoundManager.Instance.PlayEffect();
        if (playerInfo.gold >= 2500 && playerInfo.energy < 20)
        {
            playerInfo.gold -= 2500;
            playerInfo.energy = 20;
            HideRestoreEnergyPopup();
        }
        else
            LoadShopScene();
    }

    /*--------------Load Scene--------------*/

    public void LoadHomeScene()
    {
        SceneManager.LoadScene(SceneEnum.HomeScene.ToString());
    }

    public void LoadRewardScene()
    {
        SoundManager.Instance.PlayEffect();
        SceneManager.LoadScene(SceneEnum.RewardScene.ToString());
    }

    public void LoadStageScene()
    {
        if (playerInfo.energy >= 5)
        {
            SoundManager.Instance.PlayEffect();
            playerInfo.energy -= 5;
            playerInfo.UpdateStats();
            SoundManager.Instance.PlayMusic(battleMusic);
            SoundManager.Instance.SetActiveVFXSound(true);
            SceneManager.LoadScene(SceneEnum.Stage1Scene.ToString());
        }
        else
            LoadRestoreEnergyPopup();
    }

    public void LoadShopScene()
    {
        SoundManager.Instance.PlayEffect();
        SceneManager.LoadScene(SceneEnum.ShopScene.ToString());
    }

    public void LoadPowerScene()
    {
        SoundManager.Instance.PlayEffect();
        SceneManager.LoadScene(SceneEnum.PowerScene.ToString());
    }

}
