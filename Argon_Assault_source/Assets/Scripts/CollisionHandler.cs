using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")] [SerializeField] GameObject deathFx;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFx.SetActive(true);
        Invoke("RestartScene", levelLoadDelay);
    }

    private void StartDeathSequence()
    {
        SendMessage("PlayerDeath");
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(1);
    }
}
