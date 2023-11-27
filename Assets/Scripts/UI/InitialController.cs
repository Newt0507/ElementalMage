using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene(SceneEnum.LoadingScene.ToString());

        //Play music, sound,..
    }
}
