using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_level : MonoBehaviour {
    public static GameManager_level Instace;

    public int Score1Star;
    public int Score2Star;
    public int Score3Star;
    public Text scoreDosplay;
    
    public GameObject WinPanel;
    public GameObject LosePanel;


    
    public int score = 0;


    void Start () {
        Instace = this;
        Time.timeScale = 1;
        UpdateScore(0);
    }

    

	public void UpdateScore (int addScore) {
        score += addScore;
        scoreDosplay.text = score.ToString() + " / " + Score3Star.ToString();
	}

    public void LevelWin()
    {
        
        WinPanel.SetActive(true);
    }

    void LevelLose()
    {
        LosePanel.SetActive(true);
    }

    public int ReachedStars()
    {
        int stars = 0;
        if (score >= Score3Star) stars= 3;
        else if (score >= Score2Star) stars= 2;
        else stars= 1;
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name.ToString() + "Stars", stars);
        return stars;
    }

    public int GetHighscore ()
    {
        int levelHighscore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name.ToString() + "Highscore");
        if (score > levelHighscore)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name.ToString() + "Highscore", score);
            return score;
        }
        else return levelHighscore;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
