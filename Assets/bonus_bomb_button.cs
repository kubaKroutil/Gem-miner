using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bonus_bomb_button : MonoBehaviour {

    public GameObject bombPrefab;

    private Text quantityDisplay;
    private Miner miner;
    private int bombs = 10;



    void Start()
    {
        miner = GameObject.FindObjectOfType<Miner>();
        quantityDisplay = GetComponentInChildren<Text>();
        quantityDisplay.text = bombs.ToString();       
    }

    public void SpawnBomb()
    {
        if (miner.claw.transform.childCount > 0 && Time.timeScale ==1)
        {
            GameObject bomb = (GameObject)Instantiate(bombPrefab, miner.transform.position, Quaternion.identity);
            bomb.GetComponent<bonus_bomb>().SetTarget(miner.claw.transform.GetChild(0));

            bombs--;
            quantityDisplay.text = bombs.ToString();

        }
        else
        {
            Debug.Log("nothin on claw");
        }
    }

}
