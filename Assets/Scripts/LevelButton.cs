using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {

    public Text levelNumber;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    void Start () {
		
	}
	
	// Update is called once per frame
	public void SetButton (int levelNum) {
        levelNumber.text = levelNum.ToString();
        if (PlayerPrefs.GetInt("Level" + levelNum) == 1)
        {
            GetComponent<Button>().interactable = true;
            GetComponent<Button>().onClick.AddListener(() => LoadScene(levelNum));
            TurnStarsOn(PlayerPrefs.GetInt("Level" + levelNum + "Stars"));
        }
    }

    public void LoadScene(int lvlNum)
    {
        SceneManager.LoadScene("Level"+lvlNum.ToString());
    }

    void TurnStarsOn(int starts)
    {

        switch (starts)
        {
            case 0: break;
            case 1: star1.SetActive(true);
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
