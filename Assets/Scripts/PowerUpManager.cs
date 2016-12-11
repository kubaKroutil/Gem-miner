using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {

    private int bombs;
    private int superStrength;
    private int money;
    private static PowerUpManager instance;
    private static bool applicationIsQuitting = false;

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
            SetUp();
	}

    public void OnDestroy()
    {
        applicationIsQuitting = true;
    }

    void SetUp () {
        bombs = PlayerPrefs.GetInt("Bombs");
        superStrength = PlayerPrefs.GetInt("Strength");
        money = PlayerPrefs.GetInt("Money");
    }

    public void ChangeMoneyQuantity(int InOrDeCrease)
    {
        money += InOrDeCrease;
        PlayerPrefs.SetInt("Money", money);
    }

    public void ChangeBombsQuantity(int InOrDeCrease)
    {
        bombs += InOrDeCrease;
        PlayerPrefs.SetInt("Bombs", bombs);
    }

    public void ChangeSuperStrengthQuantity(int InOrDeCrease)
    {
        superStrength += InOrDeCrease;
        PlayerPrefs.SetInt("Strength", superStrength);
    }
}
