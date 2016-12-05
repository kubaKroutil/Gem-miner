using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public Vector3 origin;
    public bool release = false;

    private float basereleaseSpeed = 4;
    private float baseRetractSpeed = 4f;
    private float variableRetractSpeed = 1f;
    private float retractSpeed { get { return baseRetractSpeed * variableRetractSpeed; } }
    private bool retracting = false;
    private bonus_bomb_button bombButton;

    void Start()
    {
        origin = transform.position;
        bombButton = GameObject.FindObjectOfType<bonus_bomb_button>();
    }

    void Update() {
        if (!release || Time.timeScale == 0) return;
        if (!retracting)
        {
            transform.Translate(Vector3.down * Time.deltaTime * basereleaseSpeed);
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
        variableRetractSpeed *= item.speedMultiplier;
        item.transform.SetParent(this.transform);
        retracting = true;   
    }

    void RetractionDone()
    {
        retracting = false;
        release = false;
        transform.position = origin;
        variableRetractSpeed = 1f;
        bombButton.canShoot = true;

        if (this.transform.childCount > 0)
        {
            this.transform.GetChild(0).gameObject.GetComponent<PickableItem>().OnCatch();
            LookForPickableItems();
        }
    }

    void LookForPickableItems()
    {
        GameObject[] pickables = GameObject.FindGameObjectsWithTag("Pickable");
        if (pickables.Length == 1) GameManager_level.Instace.LevelWin();
    }
    public void ActivateSuperStrengthBonus()
    {
        baseRetractSpeed = 10;
        basereleaseSpeed = 10;
    }

    public void BombExploded()
    {
        variableRetractSpeed = 1;
        LookForPickableItems();
    }

    
}
