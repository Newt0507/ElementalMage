using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    public static LoadSceneController Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public void HomeSceneOnLoad()
    {
        SceneManager.LoadScene(SceneEnum.HomeScene.ToString());
    }

    public void RewardSceneOnLoad()
    {
        SceneManager.LoadScene(SceneEnum.RewardScene.ToString());
    }

    public void StageSceneOnLoad()
    {
        SceneManager.LoadScene(SceneEnum.Stage1Scene.ToString());
    }

    public void ShopSceneOnLoad()
    {
        SceneManager.LoadScene(SceneEnum.ShopScene.ToString());
    }

    public void PowerSceneOnLoad()
    {
        SceneManager.LoadScene(SceneEnum.PowerScene.ToString());
    }

}
