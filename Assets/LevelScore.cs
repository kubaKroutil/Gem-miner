using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour {

    public Text scoreDosplay;
    public int score = 0;

    void OnEnable()
    {
        GameManager.Instance.RetractionDoneEvent += LookForCatch;
    }

    void OnDisable()
    {
        GameManager.Instance.RetractionDoneEvent -= LookForCatch;
    }

    private void LookForCatch()
    {
        if (GameManager.Instance.hook.transform.childCount > 0)
        {
            GameManager.Instance.hook.transform.GetChild(0).gameObject.GetComponent<PickableItem>().OnCatch();
        }
    }
}
