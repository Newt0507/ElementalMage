using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardController : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private AudioClip rewardMusic;
    [SerializeField] private TMP_Text txtRewardGold;
    [SerializeField] private TMP_Text txtRewardGem;

    private string _stageScene;
    private int _rewardGold, _rewardGem;


    private void Start()
    {
        SoundManager.Instance.PlayMusic(rewardMusic);
        _stageScene = StageController.stage;
        GetReward();
        ShowReward();
    }

    private void GetReward()
    {
        if (_stageScene == SceneEnum.Stage1Scene.ToString())
        {
            _rewardGold = 0;
            _rewardGem = 0;
        }

        if (_stageScene == SceneEnum.Stage2Scene.ToString())
        {
            _rewardGold = 1000;
            _rewardGem = 10;
        }

        if (_stageScene == SceneEnum.Stage3Scene.ToString())
        {
            _rewardGold = 2000;
            _rewardGem = 20;
        }
    }

    private void ShowReward()
    {
        txtRewardGold.text = _rewardGold.ToString("N0");
        txtRewardGem.text = _rewardGem.ToString("N0");
    }

    public void LoadHomeScene()
    {
        SoundManager.Instance.PlayEffect();
        playerInfo.gold += _rewardGold;
        playerInfo.gem += _rewardGem;
        HomeController.Instance.LoadHomeScene();
    }    
}
