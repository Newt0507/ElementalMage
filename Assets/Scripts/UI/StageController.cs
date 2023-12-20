using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject monsterSpawner;

    [SerializeField] private GameObject pausePopup;
    [SerializeField] private GameObject settingPopup;

    public static string stage;

    private void Start()
    {
        stage = SceneManager.GetActiveScene().name;

        pausePopup.SetActive(false);
        settingPopup.SetActive(false);

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (player == null || monsterSpawner == null)
        {            
            SoundManager.Instance.SetActiveVFXSound(false);
            StartCoroutine(Reward());
        }
    }

    private IEnumerator Reward()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneEnum.RewardScene.ToString());
    }

    public void ShowPausePopup()
    {
        SoundManager.Instance.PlayEffect();
        pausePopup.SetActive(true);
        Time.timeScale = 0;
        SoundManager.Instance.ToggleVFX();
    }
    
    public void ShowSettingPopup()
    {
        SoundManager.Instance.PlayEffect();
        settingPopup.SetActive(true);
    }
    
    public void HidePausePopup()
    {
        SoundManager.Instance.PlayEffect();
        pausePopup.SetActive(false);
        Time.timeScale = 1;
        SoundManager.Instance.ToggleVFX();
    }
    
    public void HideSettingPopup()
    {
        SoundManager.Instance.PlayEffect();
        settingPopup.SetActive(false);
    }

    public void LoadHomeScene()
    {
        SoundManager.Instance.PlayEffect();
        HomeController.Instance.LoadHomeScene();
    }
}
