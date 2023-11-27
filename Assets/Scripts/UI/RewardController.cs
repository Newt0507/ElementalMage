using UnityEngine;

public class RewardController : MonoBehaviour
{
    public void LoadHomeScene()
    {
        LoadSceneController.Instance.HomeSceneOnLoad();
    }
}
