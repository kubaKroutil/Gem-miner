using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWin : MonoBehaviour {

    public Text scoreDisplay;
    public Text HighscoreDisplay;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

	
	// Update is called once per frame
	void OnEnable () {
        TurnStarsOn(GameManager_level.Instace.ReachedStars());
        scoreDisplay.text += GameManager_level.Instace.score.ToString();
        HighscoreDisplay.text += GameManager_level.Instace.GetHighscore();
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + GameManager_level.Instace.score);
    }

    void TurnStarsOn(int starts)
    {
        switch (starts)
        {
            case 0: break;
            case 1:
                star1.SetActive(true);
                break;
            case 2:
                star1.SetActive(true);
                star2.SetActive(true);
                break;
            case 3:
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
                break;
        }
    }

    public void GetHighscore()
    {

    }
}
