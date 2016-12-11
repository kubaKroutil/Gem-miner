using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_BuySuperStrength : MonoBehaviour {

    private int strengthCost = 150;
    private Text strengthCostDisplay;

    private void Start()
    {
        strengthCostDisplay = GetComponentInChildren<Text>();
        strengthCostDisplay.text = strengthCost.ToString();
    }


    public void BuyStrength()
    {
        //PowerUp_manager.Instace.ChangeSuperStrengthQuantity(1);
        //PowerUp_manager.Instace.ChangeMoneyQuantity(-strengthCost);
    }
}
