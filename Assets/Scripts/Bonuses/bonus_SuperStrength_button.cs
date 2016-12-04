using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class bonus_SuperStrength_button : MonoBehaviour {

    private Text quantityDisplay;
    private Miner miner;
    private int quantity;



    void Start()
    {
        miner = GameObject.FindObjectOfType<Miner>();
        quantity = PlayerPrefs.GetInt("Strength");
        quantityDisplay = GetComponentInChildren<Text>();
        quantityDisplay.text = quantity.ToString();
    }

    public void ActivateSuperPower () {
        if (quantity >= 1 && Time.timeScale == 1)
        {
            quantity--;
            PowerUp_manager.Instace.ChangeSuperStrengthQuantity(-1);
            miner.claw.ActivateSuperStrengthBonus();
            quantityDisplay.text = quantity.ToString();
        }
	
	}
}
