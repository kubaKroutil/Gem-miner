using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SuperStrengthGameButton : MonoBehaviour {

    private Text quantityDisplay;
    //private Miner miner;
    private int quantity;



    void Start()
    {
        quantityDisplay = GetComponentInChildren<Text>();
        UpdateText();
    }

    public void ActivateSuperPower () {
        if (PowerUpManager.Instance.superStrengthQuantity >= 1 && Time.timeScale == 1 && !PowerUpManager.Instance.superStrengthUsed)
        {
            PowerUpManager.Instance.superStrengthQuantity--;
            PowerUpManager.Instance.superStrengthUsed = true;
            PowerUpManager.Instance.CallUseSuperStrenghtEvent();
            UpdateText();
        }
	
	}

    private void UpdateText()
    {
        quantityDisplay.text = PowerUpManager.Instance.superStrengthQuantity.ToString();
    }
}
