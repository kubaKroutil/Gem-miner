using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuySuperStrength : MonoBehaviour {

    private int strengthCost = 150;
    private Text strengthCostDisplay;

    private void OnEnable()
    {
        PowerUpManager.Instance.BuySuperStrenghtEvent += BuySuperStrength;
        strengthCostDisplay = GetComponentInChildren<Text>();
        strengthCostDisplay.text = strengthCost.ToString();
    }

    private void OnDisable()
    {
        PowerUpManager.Instance.BuySuperStrenghtEvent -= BuySuperStrength;
    }

    public void BuySuperStrength()
    {
        PowerUpManager.Instance.money -= strengthCost;
        PowerUpManager.Instance.superStrengthQuantity++;
    }
}
