using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public float speedMultiplier;
    public int itemValue;

	public void OnCatch () {
        GameManager_level.Instace.UpdateScore(itemValue);
        Destroy(this.gameObject);
    }
}
