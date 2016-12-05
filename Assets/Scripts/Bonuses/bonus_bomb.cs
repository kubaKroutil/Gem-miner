using UnityEngine;
using System.Collections;

public class bonus_bomb : MonoBehaviour {

    private Transform target;
    private float speed = 10f;
    private bool exploded = false;


 	
	void Update () {
        if (exploded == true) return;
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);

    }
	
	public void SetTarget (Transform newTarget) {
        target = newTarget;
	}

    void OnTriggerEnter(Collider other)
    {
        if (exploded == true) return;
        if (other.transform.gameObject == target.gameObject)
        {
            exploded = true;
            GameObject.FindObjectOfType<Hook>().BombExploded();
            Destroy(other.transform.gameObject);
            Transform explosion = transform.GetChild(0);
            explosion.gameObject.SetActive(true);               //explosion
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(this.gameObject,2f);
        }
    }
}
