using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_MoneyDisplay : MonoBehaviour {

    private Text moneyDisplay;
    // Use this for initialization
    void Start() {
        moneyDisplay = GetComponent<Text>();       
	}
	
	void Update () {
        moneyDisplay.text = PlayerPrefs.GetInt("Money").ToString();
    }
}
