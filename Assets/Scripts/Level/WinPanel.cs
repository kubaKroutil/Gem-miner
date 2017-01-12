using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour {

    public Text scoreDisplay;
    public Text HighscoreDisplay;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;


    private void OnEnable () {
        scoreDisplay.text += GameManager.Instance.levelScore.ToString();
        HighscoreDisplay.text += PlayerPrefs.GetInt(SceneManager.GetActiveScene().name.ToString() + "Highscore").ToString();
    }

    public void TurnStarsOn(int stars)
    {
        string level = SceneManager.GetActiveScene().name;

        if (stars > PlayerPrefs.GetInt(level + "Stars"))
        {
            PlayerPrefs.SetInt(level + "Stars", stars);
        }
        
        switch (stars)
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
}
