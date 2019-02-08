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
    [Header("Level Values")]
    public int enemysAlive;
    public int levelNumber;
    public Spawner spawner;
    [Header("Player Reference")]
    public GameObject playerRef;
    [Header("UI")]
    public GameObject menu;
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
        }
        uiManager.ShowScore(actualScore);
        if (Input.GetButtonDown("Cancel"))
        {
            Menu();
        }
        if (enemysAlive == 0)
        {
            Invoke("NewLevel", 2f);
        }
    }
    public void NewLevel()
    {
        CancelInvoke("NewLevel");
        levelNumber++;
        uiManager.ShowLevel(levelNumber);

        spawner.Spawn();
    }

    void Menu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            Cursor.visible = true;
        }
    }
    
}
