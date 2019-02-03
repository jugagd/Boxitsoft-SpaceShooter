using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    int highscore;
    int actualScore;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");
        if (objs.Length > 1)        
            Destroy(this.gameObject);        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highscore = PlayerPrefs.GetInt("Highscore");
    }

    void Update () {
        if (actualScore>highscore)
        {
            highscore = actualScore;
            PlayerPrefs.SetInt("Highscore",highscore);
        }		
	}
}
