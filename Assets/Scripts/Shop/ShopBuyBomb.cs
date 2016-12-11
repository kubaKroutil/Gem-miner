using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyBomb : MonoBehaviour {

    private int bombCost = 100;
    private Text bombCostDisplay;

    private void OnEnable()
    {
        bombCostDisplay = GetComponentInChildren<Text>();
        bombCostDisplay.text = bombCost.ToString();
        PowerUpManager.Instance.BuyBombEvent += BuyBomb;
    }

    private void OnDisable()
    {
        PowerUpManager.Instance.BuyBombEvent -= BuyBomb;
    }

    public void BuyBomb()
    {
        PowerUpManager.Instance.money -= bombCost;
        PowerUpManager.Instance.bombsQuantity++;
    }
}
