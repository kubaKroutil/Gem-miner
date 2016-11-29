using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {
    
    public float releaseSpeed;
    public float retractSpeed;
    public bool release = false;   
    public bool retracting = false;


    void Update() {
        if (!release || Time.timeScale == 0) return;
        if (!retracting)
        {
            transform.Translate(Vector3.down * Time.deltaTime * releaseSpeed);
        }
        else transform.Translate(Vector3.up * Time.deltaTime * retractSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
           if (other.gameObject.tag == "Player" && retracting)
            {
                other.gameObject.GetComponent<Miner>().ClawIsBack();
                RetractionDone();
                return;
            }
        if (other.gameObject.tag == "Pickable" && !retracting)
        {
            HookItem(other.gameObject.GetComponent<PickableItem>());
        }
        else if (other.gameObject.tag == "Boundary")
        {
            retracting = true;
        }
    }

    void HookItem(PickableItem item)
    {
        retractSpeed *= item.speedMultiplier;
        item.transform.SetParent(this.transform);
        retracting = true;
    }

    void RetractionDone()
    {
        retracting = false;
        release = false;
        transform.localPosition = new Vector3(0f,-0.5f,0f);
        retractSpeed = 4f;
       
        if (this.transform.childCount > 0)
        {
            Debug.Log("retract done, has child");
            this.transform.GetChild(0).gameObject.GetComponent<PickableItem>().OnCatch();
            GameObject[] pickables = GameObject.FindGameObjectsWithTag("Pickable");
            Debug.Log(pickables.Length.ToString());
            if (pickables.Length == 1) GameManager.Instace.LevelWin();
        }
    }


}
