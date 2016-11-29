using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instace;

    public int moneyForBeatLevel;
    public Text moneyDisplay;
    public Text timeDisplay;
    public GameObject WinPanel;
    public GameObject LosePanel;


    public float levelTime = 50f;
    private int money = 0;


    void Start () {
        Instace = this;
        UpdateScore(0);
        Time.timeScale = 1;
	}

    void Update()
    {
        levelTime -= Time.deltaTime;
        timeDisplay.text = ((int)levelTime).ToString();
        if (levelTime < 0)
        {
            if (money >= moneyForBeatLevel) LevelWin();
            else LevelLose();
        }

    }

	public void UpdateScore (int addScore) {
        money += addScore;
        moneyDisplay.text = money.ToString() + " / " + moneyForBeatLevel.ToString();
	}

    public void LevelWin()
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }


    void LevelLose()
    {
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
