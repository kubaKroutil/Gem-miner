using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    public GameObject bombExplosion;

    private float speed = 10f;
    private Vector3 direction;
    private bool isExploded = false;

    private void OnEnable()
    {
        direction = GameManager.Instance.hook.catchedItem.transform.position - this.transform.position;
    }

    private void Update ()
    {
        if (isExploded) return;
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
	
    private void OnTriggerEnter(Collider other)
    {
        if (isExploded) return;
        if (other.transform.gameObject == GameManager.Instance.hook.catchedItem.gameObject)
        {
            SpawnExplosion();
        }
    }

    private void SpawnExplosion()
    {
        GetComponent<MeshRenderer>().enabled = false;
        isExploded = true;
        bombExplosion.SetActive(true);
        GameManager.Instance.hook.catchedItem.IncreaseScoreAndDestroy();
        PowerUpManager.Instance.CallBombExplodeEvent();
        Destroy(this.gameObject, 1f);
    }
}
