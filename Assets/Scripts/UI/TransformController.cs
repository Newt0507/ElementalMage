using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransformController : MonoBehaviour
{
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private AudioClip transformMusic;

    [SerializeField] private Transform player;
    [SerializeField] private Transform powerBall;
    [SerializeField] private Transform equipmentCamera;
    [SerializeField] private GameObject elementBall;

    [SerializeField] private ParticleSystem[] lstPowers;
    [SerializeField] private ParticleSystem[] lstAuras;
    [SerializeField] private Material[] lstMaterials;

    private void Start()
    {
        StartCoroutine(SetPower(playerInfo.element));

        SoundManager.Instance.PlayMusic(transformMusic);
    }

    private void Update()
    {
        //hạ cam -> tạo hiệu ứng nhận sức mạnh
        if (equipmentCamera.position.y <= 0.35f)
            GetAura(playerInfo.element);
    }

    private void FixedUpdate()
    {
        SetUpCamera();
    }

    private IEnumerator SetPower(string element)
    {
        ControlPower(element);
        SetElement(element);
        yield return new WaitForSeconds(7f);
        SceneManager.LoadScene(SceneEnum.LoadingScene.ToString());
    }

    //gán hiệu ứng theo power player chọn
    private void ControlPower(string element)
    {
        foreach (var power in lstPowers)
        {
            if (power.tag == element)
            {
                Instantiate(power, powerBall.position, Quaternion.identity).transform.SetParent(powerBall);
            }                
        }
    }

    //gán vật liệu theo power player chọn
    private void SetElement(string element)
    {
        if(element == "Fire")
            elementBall.GetComponent<Renderer>().material = lstMaterials[0];

        if (element == "Water")
            elementBall.GetComponent<Renderer>().material = lstMaterials[1];
        
        if (element == "Wind")
            elementBall.GetComponent<Renderer>().material = lstMaterials[2];     
    }

    //gán hiệu ứng theo power player chọn
    private void GetAura(string element)
    {
        foreach (var aura in lstAuras)
        {
            if (aura.tag == element)
            {
                if (!player.Find(aura.name + "(Clone)"))
                    Instantiate(aura, player.position, Quaternion.Euler(90, 0, 0)).transform.SetParent(player);
            }
        }
    }
    
    private void SetUpCamera()
    {
        //hạ cam
        if (equipmentCamera.position.y >= 0.35f)
            equipmentCamera.Translate(Vector3.down * Time.fixedDeltaTime);        
    }
}
