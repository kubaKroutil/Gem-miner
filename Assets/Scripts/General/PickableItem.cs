using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public float itemSpeed;
    public int itemValue;

    public void IncreaseScoreAndDestroy()
    {
            GameManager.Instance.levelScore += GameManager.Instance.hook.catchedItem.itemValue;
            Destroy(this.gameObject);
    }

    public virtual void OnHook()
    {
        //Debug.Log(this.gameObject.name);
    }
}
