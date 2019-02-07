using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static public LevelManager s_Instance;
    public int enemysAlive;
    public int actualScore=0;
    public int highScore;
    public GameObject playerRef;
    private void Awake()
    {
        //Sets up the singleton instance
        s_Instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highScore = PlayerPrefs.GetInt("Highscore");
    }

    void Update()
    {
        if (actualScore > highScore)
        {
            highScore = actualScore;
            PlayerPrefs.SetInt("Highscore", highScore);
        }
    }
}
