using UnityEngine;

public class PowerController : MonoBehaviour
{
    public void LoadHomeScene()
    {
        LoadSceneController.Instance.HomeSceneOnLoad();
    }

    public void LoadShopScene()
    {
        LoadSceneController.Instance.ShopSceneOnLoad();
    }
}
