using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonCreater : MonoBehaviour {

    public int numberOfLevels;
    public Transform buttonParent;
    
    public GameObject button;

    private void Start() {
        CreateLevelButtons();
	}

    private void CreateLevelButtons () {
        for (int i = 1; i <= numberOfLevels; i++)

        {
            GameObject newButton = (GameObject)Instantiate(button, buttonParent);
            newButton.transform.localScale = new Vector3(1, 1, 1);
            newButton.GetComponent<LevelButton>().SetButton(i);
        }
	}
}
