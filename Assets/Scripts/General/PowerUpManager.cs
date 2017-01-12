using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpManager : MonoBehaviour {

    public delegate void EventHandler();

    public event EventHandler BuyBombEvent;
    public event EventHandler UseBombEvent;
    public event EventHandler BombExplodeEvent;
    public event EventHandler BuySuperStrenghtEvent;
    public event EventHandler UseSuperStrenghtEvent;

    public int bombsQuantity;
    public int superStrengthQuantity;
    public int money;
    public bool bombUsed = false;
    public bool superStrengthUsed = false;

    private static bool applicationIsQuitting = false;
    private static PowerUpManager instance;

    public static PowerUpManager Instance
    {
        get
        {
            if (applicationIsQuitting) return null;
            if (instance == null)
            {
                PowerUpManager[] instances = GameObject.FindObjectsOfType<PowerUpManager>();

                if (instances.Length == 1) instance = instances[0];
                else
                {
                    foreach (PowerUpManager gm in instances)               // If theres 0 or 2 or more PowerUp Managers
                    {
                        Destroy(gm.gameObject);                         // Destroy all Game Managers
                    }
                    GameObject singleton = new GameObject();            // And create new one
                    singleton.name = "PowerUpSingleton";
                    instance = singleton.AddComponent<PowerUpManager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void Awake ()
    {
        //DeleteAll();
        Time.timeScale = 1;
        if (!PlayerPrefs.HasKey("FirstLog"))
        {
            FirstLogSetUp();
        }
        SetUp();
            SceneManager.sceneLoaded += OnLoadScene;
    }

    private void SetUp()
    {
        bombsQuantity = PlayerPrefs.GetInt("Bombs");
        superStrengthQuantity = PlayerPrefs.GetInt("SuperStrength");
        money = PlayerPrefs.GetInt("Money");
    }

    private void OnLoadScene(Scene scene, LoadSceneMode mode)           // new OnLevelLoad
    {
        superStrengthUsed = false;
    }
    public void OnDestroy()
    {
        SavePlayerPrefs();
        applicationIsQuitting = true;
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("Bombs", bombsQuantity);
        PlayerPrefs.SetInt("SuperStrength", superStrengthQuantity);
    }

    private void FirstLogSetUp()
    {
        PlayerPrefs.SetInt("FirstLog", 1);
        PlayerPrefs.SetInt("Level1", 1);
        PlayerPrefs.SetInt("Money", 2000);
        PlayerPrefs.SetInt("Bombs", 1);
        PlayerPrefs.SetInt("SuperStrength", 1);
    }

    private void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void CallBuyBombEvent()
    {
        if (BuyBombEvent != null)
        {
            BuyBombEvent();
        }
    }

    public void CallUseBombEvent()
    {
        if (UseBombEvent != null)
        {
            UseBombEvent();
        }
    }

    public void CallBombExplodeEvent()
    {
        if (BombExplodeEvent != null)
        {
            BombExplodeEvent();
        }
    }

    public void CallBuySuperStrenghtEvent()
    {
        if (BuySuperStrenghtEvent != null)
        {
            BuySuperStrenghtEvent();
        }
    }

    public void CallUseSuperStrenghtEvent()
    {
        if (UseSuperStrenghtEvent != null)
        {
            UseSuperStrenghtEvent();
        }
    }
}
