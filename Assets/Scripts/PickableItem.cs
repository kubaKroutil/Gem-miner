using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public float speedMultiplier;
    public int itemValue;

	public virtual void OnCatch () {
        GameManager.Instace.UpdateScore(itemValue);
        Destroy(this.gameObject);
    }
}
