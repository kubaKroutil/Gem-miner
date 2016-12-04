using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_manager : MonoBehaviour {

    public static PowerUp_manager Instace = null;
    private int Bombs;
    private int SuperStrength;
    private int money;

    void Awake () {
        
            Instace = this;
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
