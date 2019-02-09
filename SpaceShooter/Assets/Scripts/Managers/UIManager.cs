using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    public Text highScoreText;
    public Text actualScore;
    public Text LevelText;
    int highscore;
    public GameObject mainButtons;
    public GameObject settingsButtons;
    public Slider volume;

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
}
