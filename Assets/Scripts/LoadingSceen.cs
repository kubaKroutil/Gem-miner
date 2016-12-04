using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceen : MonoBehaviour {

    AsyncOperation AsOperation;
    public GameObject loadingBG;
    public Slider progressSlider;
    public Button startLevelButton;


    public void LoadLevel(int number)
    {
        loadingBG.SetActive(true);
        progressSlider.gameObject.SetActive(true);
        StartCoroutine(LoadingLevel(number));
    }

    private IEnumerator LoadingLevel(int number)
    {
        yield return new WaitForSeconds(0.5f);
        AsOperation = SceneManager.LoadSceneAsync(number);
        AsOperation.allowSceneActivation = false;

        while (!AsOperation.isDone)
        {
            progressSlider.value = AsOperation.progress;
            if (AsOperation.progress == 0.9f)
            {
                
                startLevelButton.gameObject.SetActive(true);
            }
            yield return null;
        }
    }

    public void StartLevel()
    {
        AsOperation.allowSceneActivation = true;
    }
}
