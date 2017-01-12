using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour {

    public Text moneyDisplay;
    public Text bombCostDisplay;
    public Text strengthCostDisplay;
    private int strengthCost = 150;
    private int bombCost = 100; 

    private void Start()
    {
        DisplayPowerupsPrice();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        moneyDisplay.text = PowerUpManager.Instance.money.ToString();
    }

    public void BuyBomb()
    {
        PowerUpManager.Instance.money -= bombCost;
        PowerUpManager.Instance.bombsQuantity++;
        UpdateDisplay();
    }

    public void BuySuperStrength()
    {
        PowerUpManager.Instance.money -= strengthCost;
        PowerUpManager.Instance.superStrengthQuantity++;
        UpdateDisplay();
    }

    private void DisplayPowerupsPrice()
    {
        bombCostDisplay.text = bombCost.ToString();
        strengthCostDisplay.text = strengthCost.ToString();
    }
}
