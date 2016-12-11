using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMoneyDisplay : MonoBehaviour {

    private Text moneyDisplay;
    
    void Start() {
        moneyDisplay = GetComponent<Text>();       
	}
	
	void Update () {
        moneyDisplay.text = PowerUpManager.Instance.money.ToString();
    }
}
