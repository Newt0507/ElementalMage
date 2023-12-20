using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreEnergy : MonoBehaviour
{
    public static RestoreEnergy Instance { get; private set; }

    [SerializeField] private PlayerInfo playerInfo;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
        StartCoroutine(Restore());
    }
    
    private IEnumerator Restore()
    {
        if (playerInfo.energy < 20) playerInfo.energy += 1;
        else playerInfo.energy = 20;

        yield return new WaitForSeconds(100f);
        StartCoroutine(Restore());
    }
}
