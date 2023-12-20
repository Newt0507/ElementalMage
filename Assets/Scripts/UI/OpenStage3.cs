using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenStage3 : MonoBehaviour
{
    [SerializeField] private GameObject monsterSpawner;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    private void Update()
    {
        if (monsterSpawner.transform.childCount <= 0)
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (monsterSpawner.transform.childCount <= 0 && other.gameObject.tag == "Player")
            SceneManager.LoadScene(SceneEnum.Stage3Scene.ToString());
    }
}
