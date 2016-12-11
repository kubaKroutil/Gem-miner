using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public Vector3 origin;
    public bool release = false;
    public bool retracting = false;   
    public HookSpeed hookSpeed;
    public PickableItem catchedItem;



    private void Start()
    {
        origin = transform.position;
        hookSpeed = new HookSpeed(HookSpeed.DefaultReleaseSpeed, HookSpeed.DefaultRetractSpeed);
        //bombButton = GameObject.FindObjectOfType<bonus_bomb_button>();
    }

    private void OnEnable()
    {
        GameManager.Instance.ReleaseHookEvent += ReleaseHook;
        GameManager.Instance.RetractHookEvent += Retracting;
        GameManager.Instance.RetractionDoneEvent += RetractionDone;
        GameManager.Instance.RetractionDoneEvent += RestoreRetractSpeed;
        PowerUpManager.Instance.BombExplodeEvent += RestoreRetractSpeed;
    }

    private void OnDisable()
    {
        GameManager.Instance.ReleaseHookEvent -= ReleaseHook;
        GameManager.Instance.RetractHookEvent -= Retracting;
        GameManager.Instance.RetractionDoneEvent -= RetractionDone;
        GameManager.Instance.RetractionDoneEvent -= RestoreRetractSpeed;
        PowerUpManager.Instance.BombExplodeEvent -= RestoreRetractSpeed;
    }

    private void Update() {
        if (!release) return;
        if (!retracting)
        {
            transform.Translate(Vector3.down * Time.deltaTime * hookSpeed.ReleaseSpeed);
        }
        else transform.Translate(Vector3.up * Time.deltaTime * hookSpeed.RetractSpeed);
    }

    private void ReleaseHook()
    {
        release = true;
    }

    private void Retracting()
    {
        retracting = true;
    }

    private void RetractionDone()
    {
        retracting = false;
        release = false;
        transform.position = origin;
        
        if (catchedItem) catchedItem.IncreaseScoreAndDestroy();       
    }

    private void RestoreRetractSpeed()
    {
        if (!PowerUpManager.Instance.superStrengthUsed) hookSpeed.SetRetractSpeed(HookSpeed.DefaultRetractSpeed);
    }
}
