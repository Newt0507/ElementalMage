using UnityEngine;

public class ShopController : MonoBehaviour
{
    public void LoadHomeScene()
    {
        LoadSceneController.Instance.HomeSceneOnLoad();
    }
}
