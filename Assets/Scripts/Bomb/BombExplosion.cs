using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour {

    public GameObject bombExplosion;

    private void OnEnable()
    {
        PowerUpManager.Instance.BombExplodeEvent += SpawnExplosion;
    }

    private void OnDisable()
    {
        PowerUpManager.Instance.BombExplodeEvent -= SpawnExplosion;
    }
    
    void SpawnExplosion ()
    {
        GameObject explosion = (GameObject)Instantiate(bombExplosion, GameManager.Instance.hook.catchedItem.transform.position, Quaternion.identity);
        GameManager.Instance.hook.catchedItem.IncreaseScoreAndDestroy();
        Destroy(explosion, 1f);
	}
}
