using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public LevelManager s_Instance;
    [Header("Score Values")] 
    public int actualScore = 0;
    public int highScore;
    public bool highscoreAchieved = false;
    [Header("Level Values")]
    public int enemysAlive;
    public int levelNumber;
    public Spawner spawner;
    [Header("Player Reference")]
    public GameObject playerRef;
    bool playerAlive = true;
    [Header("UI")]
    UIManager uiManager;

    private void Awake()
    {
        //Sets up the singleton instance
        s_Instance = this;   
    }

    private void Start()
    {
        Cursor.visible = false;
        if (PlayerPrefs.HasKey("Highscore"))
            highScore = PlayerPrefs.GetInt("Highscore");
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        levelNumber = 0;
        NewLevel();
        Time.timeScale = 1;

     
    }

    void Update()
    {
        if (actualScore > highScore)
        {
            highScore = actualScore;
            PlayerPrefs.SetInt("Highscore", highScore);
            highscoreAchieved = true;
        }
        uiManager.ShowScore(actualScore);
        if (Input.GetButtonDown("Cancel")&&playerAlive)
        {
            ShowMenuUI();
        }
        if (enemysAlive == 0)
        {
            Invoke("NewLevel", 2f);
        }
        if (playerAlive)
        {
            if (playerRef==null)
            {
                playerAlive = false;
                Invoke("ShowMenuUI",2f);
            }
        }
    }

    void ShowMenuUI()
    {
        uiManager.ShowMenu();
    }
    public void NewLevel()
    {
        CancelInvoke("NewLevel");
        levelNumber++;
        uiManager.ShowLevel(levelNumber);
        GameObject[] _bullets;      
        _bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (var bullet in _bullets)
        {
            bullet.GetComponent<Bullet>().ReturnToPool();
        }
        spawner.Spawn();
    }
    
    
}
