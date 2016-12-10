using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_BuyBomb : MonoBehaviour {

    private int bombCost = 100;
    private Text bombCostDisplay;

    void Start () {
        bombCostDisplay = GetComponentInChildren<Text>();
        bombCostDisplay.text = bombCost.ToString();
	}
	

	public void BuyBomb () {
        //PowerUp_manager.Instace.ChangeBombsQuantity(1);
        //PowerUp_manager.Instace.ChangeMoneyQuantity(-bombCost);
	}
}
