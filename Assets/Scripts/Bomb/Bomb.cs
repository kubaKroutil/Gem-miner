using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    
    private float speed = 10f;
    private Vector3 direction;

    private void OnEnable()
    {
        direction = GameManager.Instance.hook.catchedItem.transform.position - this.transform.position;
    }

    private void Update ()
    {
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject == GameManager.Instance.hook.catchedItem.gameObject)
        {
            PowerUpManager.Instance.CallBombExplodeEvent();
            Destroy(this.gameObject);
        }
    }
}
