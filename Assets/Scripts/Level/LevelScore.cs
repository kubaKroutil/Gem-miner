using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelScore : MonoBehaviour {

    public Text scoreDisplay;
    public int score1Star;
    public int score2Star;
    public int score3Star;

    public GameObject winPanel;
    public GameObject losePanel;

    private void Start()
    {
        string level = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt(level , 1);
    }

    private void OnEnable()
    {
        GameManager.Instance.GameOverEvent += CheckHighscore;
        GameManager.Instance.GameOverEvent += CheckScore;
        GameManager.Instance.RetractionDoneEvent += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.Instance.GameOverEvent -= CheckHighscore;
        GameManager.Instance.GameOverEvent -= CheckScore;
        GameManager.Instance.RetractionDoneEvent -= UpdateScore;
    }

    private void UpdateScore()
    {
        scoreDisplay.text = GameManager.Instance.levelScore.ToString();
    }

    private void CheckScore()
    {
        if (GameManager.Instance.levelScore >= score1Star) LevelWon();
        else LevelLost();
    }

    private void LevelWon()
    {
        PowerUpManager.Instance.money += GameManager.Instance.levelScore;
        winPanel.SetActive(!winPanel.activeSelf);
        if (GameManager.Instance.levelScore >= score3Star) winPanel.GetComponent<WinPanel>().TurnStarsOn(3);
        else if (GameManager.Instance.levelScore >= score2Star) winPanel.GetComponent<WinPanel>().TurnStarsOn(2);
        else winPanel.GetComponent<WinPanel>().TurnStarsOn(1);
    }

    private void LevelLost()
    {
        losePanel.SetActive(!losePanel.activeSelf);
    }

    public void CheckHighscore()
    {
        int levelHighscore = PlayerPrefs.GetInt(SceneManager.GetActiveScene().name.ToString() + "Highscore");
        if (GameManager.Instance.levelScore > levelHighscore)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name.ToString() + "Highscore", GameManager.Instance.levelScore);            
        }      
    }
}
