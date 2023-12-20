using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialController : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;

    private void Start()
    {
        if(playerInfo.element == "")
            playerInfo.InitProperties();

        SceneManager.LoadScene(SceneEnum.LoadingScene.ToString());
    }
}
