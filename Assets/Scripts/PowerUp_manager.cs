using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_manager : MonoBehaviour {


    private int Bombs;
    private int SuperStrength;
    private int money;
    private static PowerUp_manager instance;
    

    public static PowerUp_manager Instance
    {
        get
        {
            if (instance == null)
            {
                PowerUp_manager[] instances = GameObject.FindObjectsOfType<PowerUp_manager>();

                if (instances.Length == 1) instance = instances[0];
                else
                {
                    foreach (PowerUp_manager gm in instances)               // If theres 0 or 2 or more PowerUp Managers
                    {
                        Destroy(gm.gameObject);                         // Destroy all Game Managers
                    }
                    GameObject singleton = new GameObject();            // And create new one
                    singleton.name = "PowerUpSingleton";
                    instance = singleton.AddComponent<PowerUp_manager>();
                }
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }
    void Awake () {
        
            SetUp();
            DontDestroyOnLoad(this);
  
	}

    void SetUp () {
        Bombs = PlayerPrefs.GetInt("Bombs");
        SuperStrength = PlayerPrefs.GetInt("Strength");
        money = PlayerPrefs.GetInt("Money");
    }

    public void ChangeMoneyQuantity(int InOrDeCrease)
    {
        money += InOrDeCrease;
        PlayerPrefs.SetInt("Money", money);
    }

    public void ChangeBombsQuantity(int InOrDeCrease)
    {
        Bombs += InOrDeCrease;
        PlayerPrefs.SetInt("Bombs", Bombs);
    }

    public void ChangeSuperStrengthQuantity(int InOrDeCrease)
    {
        SuperStrength += InOrDeCrease;
        PlayerPrefs.SetInt("Strength", SuperStrength);
    }
}
