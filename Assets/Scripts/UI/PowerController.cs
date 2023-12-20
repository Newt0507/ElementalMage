using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerController : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private TMP_Text txtGemElement;
    [SerializeField] private TMP_Text txtGoldStats;

    [SerializeField] private TMP_Text txtHealth;
    [SerializeField] private TMP_Text txtDamage;
    [SerializeField] private TMP_Text txtSpeed;

    [SerializeField] private GameObject[] txtListSelectedElement;

    [SerializeField] private GameObject popupConfirm;

    private void Start()
    {        
        foreach (var element in txtListSelectedElement)
        {
            if (element.tag == playerInfo.element)
                element.SetActive(true);
            else
                element.SetActive(false);
        }

        popupConfirm.SetActive(false);
    }

    private void Update()
    {
        ShowValue();
    }

    private void ShowValue()
    {
        txtHealth.text = playerInfo.baseMaxHp.ToString();
        txtDamage.text = playerInfo.baseDamage.ToString();
        txtSpeed.text = playerInfo.baseSpeed.ToString();

        if (playerInfo.gem < 5000)
            txtGemElement.color = Color.red;
        else
            txtGemElement.color = Color.white;

        if (playerInfo.gold < 5000)
            txtGoldStats.color = Color.red;
        else
            txtGoldStats.color = Color.white;
    }

    public void LoadHomeScene()
    {
        SoundManager.Instance.PlayEffect();
        HomeController.Instance.LoadHomeScene();
    }

    public void LoadShopScene()
    {
        SoundManager.Instance.PlayEffect();
        HomeController.Instance.LoadShopScene();
    }

    public void ShowConfirm()
    {
        if (playerInfo.gem >= 5000)
        {
            SoundManager.Instance.PlayEffect();
            popupConfirm.SetActive(true);
        }
        else
            LoadShopScene();
    }

    public void HideConfirm()
    {
        SoundManager.Instance.PlayEffect();
        popupConfirm.SetActive(false);
    }

    public void UpgradeStats()
    {
        SoundManager.Instance.PlayEffect();
        if (playerInfo.gold >= 5000)
        {
            playerInfo.gold -= 5000;
            playerInfo.baseMaxHp += 100;
            playerInfo.baseDamage += 20;
            playerInfo.baseSpeed += 2;
            playerInfo.UpdateStats();
        }
        else
            LoadShopScene();
    }
    
    public void ChangeElement()
    {
        SoundManager.Instance.PlayEffect();
        playerInfo.gem -= 5000;
        playerInfo.element = "";
        SceneManager.LoadScene(SceneEnum.LoadingScene.ToString());
    }
}
