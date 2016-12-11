using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollisions : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Miner" && GameManager.Instance.hook.retracting)
        {
            GameManager.Instance.CallHookRetractedEvent();
            return;
        }
        if (other.gameObject.tag == "Pickable" && !GameManager.Instance.hook.retracting)
        {
            HookItem(other.gameObject.GetComponent<PickableItem>());
            GameManager.Instance.CallRetractHookEvent();
        }
        else if (other.gameObject.tag == "Boundary" && !GameManager.Instance.hook.retracting)
        {
            GameManager.Instance.CallRetractHookEvent();
        }
    }


    private void HookItem(PickableItem item)
    {
        if (!PowerUpManager.Instance.superStrengthUsed) GameManager.Instance.hook.hookSpeed.SetRetractSpeed(item.itemSpeed);
        item.transform.SetParent(this.transform);
        GameManager.Instance.hook.catchedItem = item;
    }
}
