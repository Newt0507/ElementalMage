using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] PlayerInfo playerInfo;

    public void LoadHomeScene()
    {
        SoundManager.Instance.PlayEffect();
        HomeController.Instance.LoadHomeScene();
    }
}
