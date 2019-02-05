using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    public Text highScoreText;
    int highscore;

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
            highscore = 0;
        highScoreText.text = "Highscore: " + highscore;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
