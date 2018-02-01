using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    [SerializeField] private float timeToLoad = 1f;

    // Use this for initialization
    void Start()
    {
        Invoke("LoadGame", timeToLoad);
    }

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
