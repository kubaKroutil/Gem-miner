using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int numberOfLevels;
    public Transform buttonParent;
    
    public GameObject button;

    void Start() {
        Time.timeScale = 1;
        if (!PlayerPrefs.HasKey("FirstLog"))
        {
            FirstLogSetUp();
        }

        CreateLevelButtons();
	}
	
	void CreateLevelButtons () {
        for (int i = 1; i <= numberOfLevels; i++)

        {
            GameObject newButton = (GameObject)Instantiate(button, buttonParent);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.GetComponent<LevelButton>().SetButton(i);
        }
	}

    void FirstLogSetUp()
    {
        PlayerPrefs.SetInt("FirstLog", 1);
        PlayerPrefs.SetInt("Level1", 1);
        PlayerPrefs.SetInt("Level2", 1);
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

   
}
