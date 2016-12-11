using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombGameButton : MonoBehaviour {

    public GameObject bombPrefab;

    private Text quantityDisplay;

    private void Start()
    {
        quantityDisplay = GetComponentInChildren<Text>();
        UpdateText();
    }

    private void OnEnable()
    {
        PowerUpManager.Instance.BombExplodeEvent += CanUseBombAgain;
    }

    private void OnDisable()
    {
        PowerUpManager.Instance.BombExplodeEvent -= CanUseBombAgain;
    }

    public void SpawnBomb()
    {
        if (GameManager.Instance.hook.catchedItem && Time.timeScale == 1 && PowerUpManager.Instance.bombsQuantity >= 1 && !PowerUpManager.Instance.bombUsed)
        {
            PowerUpManager.Instance.bombUsed = true;
            PowerUpManager.Instance.CallUseBombEvent();
            PowerUpManager.Instance.bombsQuantity--;
            Instantiate(bombPrefab, GameManager.Instance.hook.origin, Quaternion.identity);
            UpdateText();
        }

    }

    private void UpdateText()
    {
        quantityDisplay.text = PowerUpManager.Instance.bombsQuantity.ToString();
    }
    private void CanUseBombAgain()
    {
        PowerUpManager.Instance.bombUsed = false;
    }
}
