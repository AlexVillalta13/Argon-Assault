using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
    {
        int numbMusicPlayers = FindObjectsOfType<MusicManager>().Length;

        if (numbMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
	}
	
}
