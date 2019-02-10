using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [Header("Score Texts")]
    public Text highScoreText;
    public Text actualScore;
    [Header("Main Menu Texts")]
    public GameObject mainButtons;
    public GameObject settingsButtons;
    public Slider volume;
    [Header("Gameplay")]
    public Text LevelText;
    [Header("Paused and Status Menu")]
    public GameObject menu;
    public Text statusText;
    public Text highscoreAchievedText;
    private int highscore;

    private void Start()
    {
        ShowScore(0);
    }
    #region Main Buttons
    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }       
    
    public void SettingsButton()
    {
        mainButtons.SetActive(false);
        settingsButtons.SetActive(true);
        float value;
        bool result = Settings.s_Instance.mixer.GetFloat("Volume", out value);
        if (result)
            volume.value = value;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion

    #region Settings Buttons
    public void VolumeSlider()
    {
        float volumeValue = volume.value;
        Settings.s_Instance.SetVolume(volumeValue);
    }

    public void EraseScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        ShowScore(0);
    }

    public void SettingsBack()
    {
        mainButtons.SetActive(true);
        settingsButtons.SetActive(false);
    }   
    #endregion

    public void ShowScore(int score)
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highscore = PlayerPrefs.GetInt("Highscore");
        else
        {
            highscore = 0;
            PlayerPrefs.SetInt("Highscore", highscore);
        }

        highScoreText.text = "Highscore: " + highscore;
        if (actualScore!=null)
            actualScore.text = "Score " + score;
    }
    #region Gameplay
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowLevel(int levelNumber)
    {
        LevelText.text = "Level: " + levelNumber;
    }
    #endregion

    public void ShowMenu()
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
            statusText.text = "Paused";
            if (LevelManager.s_Instance.playerRef==null)
            {
                statusText.text = "You Lost";
                if (LevelManager.s_Instance.highscoreAchieved)
                {
                    highscoreAchievedText.gameObject.SetActive(true);
                    highscoreAchievedText.text = "Highscore achieved at " + LevelManager.s_Instance.actualScore + " points!";
                }
            }
        }
    }
}
