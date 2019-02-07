using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    public Text highScoreText;
    int highscore;
    public GameObject mainButtons;
    public GameObject settingsButtons;
    public Slider volume;
	void Start ()
    {
        ShowScore();       
	}

    public void StartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void ShowScore()
    {
        if (PlayerPrefs.HasKey("Highscore"))
            highscore = PlayerPrefs.GetInt("Highscore");
        else
        {
            highscore = 0;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
            
        highScoreText.text = "Highscore: " + highscore;
    }
    public void EraseScore()
    {
        PlayerPrefs.SetInt("Highscore", 0);
        ShowScore();
    }
    public void ExitGame()
    {
        Application.Quit();
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

    public void SettingsBack()
    {
        mainButtons.SetActive(true);
        settingsButtons.SetActive(false);
    }

    public void VolumeSlider()
    {
        float volumeValue = volume.value;
        Settings.s_Instance.SetVolume(volumeValue);
    }
}
