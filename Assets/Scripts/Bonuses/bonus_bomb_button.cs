using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bonus_bomb_button : MonoBehaviour {

    public GameObject bombPrefab;

    private Text quantityDisplay;
    //private Miner miner;
    private int bombs;
    public bool canShoot = true;



    void Start()
    {
        //miner = GameObject.FindObjectOfType<Miner>();
        bombs = PlayerPrefs.GetInt("Bombs");
        quantityDisplay = GetComponentInChildren<Text>();
        quantityDisplay.text = bombs.ToString();       
    }

    public void SpawnBomb()
    {
        //if (miner.Hook.transform.childCount > 0 && Time.timeScale ==1 && bombs >=1 && canShoot)
        //{
        //    canShoot = false;
        //    GameObject bomb = (GameObject)Instantiate(bombPrefab, miner.transform.position, Quaternion.identity);
        //    bomb.GetComponent<bonus_bomb>().SetTarget(miner.Hook.transform.GetChild(0));

        //    bombs--;
        //    //PowerUp_manager.Instace.ChangeBombsQuantity(-1);
        //    quantityDisplay.text = bombs.ToString();
        //}

    }
}
