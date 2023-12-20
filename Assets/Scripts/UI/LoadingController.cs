using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingController : MonoBehaviour
{
    public static LoadingController Instance { get; private set; }

    [SerializeField] private PlayerInfo playerInfo;

    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text progressText;

    // Start is called before the first frame update
    private void Start()
    {
        Instance = this;
        if(playerInfo.element != "")
            StartCoroutine(LoadingAsync(SceneEnum.HomeScene.ToString()));
        else
            StartCoroutine(LoadingAsync(SceneEnum.ChooseELementScene.ToString()));
    }

    //Load Async Scene
    public IEnumerator LoadingAsync(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";
            
            yield return null;
        }
    }
}
