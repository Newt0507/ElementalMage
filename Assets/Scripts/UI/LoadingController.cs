using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingController : MonoBehaviour
{
    public static LoadingController Instance { get; private set; }

    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text progressText;

    [SerializeField] private PlayerInfo playerInfo;


    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;

        if(playerInfo.element == "")
            StartCoroutine(LoadingAsync(SceneEnum.ChooseELementScene.ToString()));
        else
            StartCoroutine(LoadingAsync(SceneEnum.HomeScene.ToString()));
    }

    public IEnumerator LoadingAsync(string HomeScene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(HomeScene);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            
            yield return null;
        }
    }
}
