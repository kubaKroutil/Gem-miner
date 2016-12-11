using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToggle : MonoBehaviour {

    public GameObject UIPausePanel;
    public bool isPaused = false;

    private void OnEnable()
    {
        GameManager.Instance.PauseGameEvent += Pause;
        GameManager.Instance.PauseGameEvent += TogglePausePanel;
        GameManager.Instance.GameOverEvent += Pause;
    }

    private void OnDisable()
    {
        GameManager.Instance.PauseGameEvent -= TogglePausePanel;
        GameManager.Instance.PauseGameEvent -= Pause;
        GameManager.Instance.GameOverEvent -= Pause;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel") && !GameManager.Instance.isGameOver)
        {
            GameManager.Instance.CallPauseGameEvent();
        }
    }
    private void Pause () {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
	}

    private void TogglePausePanel()
    {
        UIPausePanel.SetActive(!UIPausePanel.activeSelf);
    }
}
