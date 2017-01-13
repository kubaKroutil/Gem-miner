using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelTimer : MonoBehaviour {

    public Text timeDisplay;
    public float levelTime = 50f;

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        levelTime -= Time.deltaTime;
        timeDisplay.text = ((int)levelTime).ToString();
        if (levelTime <= 0)
        {
            GameManager.Instance.CallGameOverEvent();
        }
    }
}
