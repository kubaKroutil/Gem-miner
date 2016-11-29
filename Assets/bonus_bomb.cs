using UnityEngine;
using System.Collections;

public class bonus_bomb : MonoBehaviour {

    private Transform target;
    private float speed = 5f;


 	
	void Update () {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }
        Vector3 dir = target.position - this.transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);

    }
	
	public void SetTarget (Transform newTarget) {
        target = newTarget;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject == target.gameObject)
        {
            Destroy(other.transform.gameObject);
            Destroy(this.gameObject);
        }
    }
}
