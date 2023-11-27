using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseElementController: MonoBehaviour
{
    public static ChooseElementController Instance { get; private set; }

    [SerializeField] private GameObject popupElementInfo;
    [SerializeField] private TMP_Text txtElementName;
    [SerializeField] private TMP_Text txtBaseHealth;
    [SerializeField] private TMP_Text txtBaseDamge;
    [SerializeField] private TMP_Text txtBaseSpeed;

    [SerializeField] private PlayerInfo playerInfo;

    private int a;

    private void Start()
    {
        Instance = this;

        HideElementInfo();
    }

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

    public void ChooseElement()
    {
        playerInfo.element = txtElementName.text;

        playerInfo.baseMaxHp = int.Parse(txtBaseHealth.text);
        playerInfo.baseDamage = int.Parse(txtBaseDamge.text);
        playerInfo.baseSpeed = int.Parse(txtBaseSpeed.text);

        playerInfo.ResetData();

        SceneManager.LoadScene(SceneEnum.TransformScene.ToString());
    }
}
