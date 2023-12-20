using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseElementController: MonoBehaviour
{
    public static ChooseElementController Instance { get; private set; }

    [SerializeField] private GameObject popupElementInfo;
    [SerializeField] private GameObject popupNotice;
    [SerializeField] private TMP_Text txtElementName;
    [SerializeField] private TMP_Text txtBaseHealth;
    [SerializeField] private TMP_Text txtBaseDamge;
    [SerializeField] private TMP_Text txtBaseSpeed;

    [SerializeField] private PlayerInfo playerInfo;

    private void Start()
    {
        Instance = this;

        //khởi tạo giá trị
        playerInfo.InitData();
        HideElementInfo();
        ShowNotice();


        SoundManager.Instance.SetActiveVFXSound(true);
    }

    //hiển thị các giá trị của ngtố 
    public void ShowElementInfo(ElementInfo elementInfo)
    {
        txtElementName.text = elementInfo.elementName;
        txtBaseHealth.text = elementInfo.baseMaxHp.ToString();
        txtBaseDamge.text = elementInfo.baseDamage.ToString();
        txtBaseSpeed.text = elementInfo.baseSpeed.ToString();

        popupElementInfo.SetActive(true);
    }

    public void HideElementInfo()
    {
        popupElementInfo.SetActive(false);
    }

    public void ShowNotice()
    {
        popupNotice.SetActive(true);
    }

    public void HideNotice()
    {
        SoundManager.Instance.PlayEffect();
        popupNotice.SetActive(false);
    }

    //khi player chọn nguyên tố thì lưu dữ liệu vào playerInfo -> load scene transform
    public void ChooseElement()
    {
        SoundManager.Instance.PlayEffect();
        playerInfo.element = txtElementName.text;
        playerInfo.baseMaxHp = int.Parse(txtBaseHealth.text);
        playerInfo.baseDamage = int.Parse(txtBaseDamge.text);
        playerInfo.baseSpeed = int.Parse(txtBaseSpeed.text);

        playerInfo.UpdateStats();

        SoundManager.Instance.SetActiveVFXSound(false);
        SceneManager.LoadScene(SceneEnum.TransformScene.ToString());
    }
}
