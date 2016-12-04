using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour {
    public float speed = 3;
    private Vector3 targetRot;
    private bool goLeft = true;

    // Use this for initialization
    void Start () {
        targetRot = this.transform.rotation.eulerAngles;
	}

    // Update is called once per frame
    void Update() {
        if (goLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
       
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRot), Time.deltaTime * 3);
    }

    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag != "Boundary") return;

        goLeft = !goLeft;
        targetRot = transform.rotation.eulerAngles + new Vector3(180f, 0f, 0f);       
    }
}
