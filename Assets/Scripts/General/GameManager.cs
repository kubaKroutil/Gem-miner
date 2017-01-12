using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public delegate void EventHandler();

    public event EventHandler PauseGameEvent;
    public event EventHandler ReleaseHookEvent;
    public event EventHandler RetractHookEvent;
    public event EventHandler RetractionDoneEvent;
    public event EventHandler GameOverEvent;

    private static GameManager instance;
    private static bool applicationIsQuitting = false;
    public int levelScore = 0;
    public Hook hook;
    public bool isGameOver = false;
    
    public static GameManager Instance
    {
        get
        {
            if (applicationIsQuitting) return null;
            if (instance == null)
            {
                GameManager[] instances = GameObject.FindObjectsOfType<GameManager>();

                if (instances.Length == 1) instance = instances[0];
                else
                {
                    foreach (GameManager gm in instances)               // If theres 0 or 2 or more Game Managers
                    {
                        Destroy(gm.gameObject);                         // Destroy all Game Managers
                    }
                    GameObject singleton = new GameObject();            // And create new one
                    singleton.name = "GameManagerSingleton";
                    instance = singleton.AddComponent<GameManager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    private void Awake()                                                                // every time scene load do this...
    {
        SceneManager.sceneLoaded += OnLoadScene;
    }
    private void OnLoadScene(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex !=0)                                                      // if you are not in menu
        {
            hook = GameObject.FindGameObjectWithTag("Player").GetComponent<Hook>();   // Hook reference
        }
        isGameOver = false;
        levelScore = 0;
        Time.timeScale = 1;

    }

    public void CallPauseGameEvent()
    {
        if (PauseGameEvent != null)
        {
            PauseGameEvent();
        }
    }

    public void CallReleaseHookEvent()
    {
        if (ReleaseHookEvent != null)
        {
            ReleaseHookEvent();
        }
    }

    public void CallRetractHookEvent()
    {
        if (RetractHookEvent != null)
        {
            RetractHookEvent();
        }
    }

    public void CallHookRetractedEvent()
    {
        if (RetractionDoneEvent != null)
        {
            RetractionDoneEvent();
        }
    }

    public void CallGameOverEvent()
    {
        if (GameOverEvent != null)
        {
            isGameOver = true;
            GameOverEvent();
        }
    }

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }
}
