using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookLineRender : MonoBehaviour {

    private LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Enable () {
        
        GameManager.Instance.ReleaseHookEvent += Toggle;
        GameManager.Instance.RetractionDoneEvent += Toggle;
    }

    void OnDisable()
    {
        GameManager.Instance.ReleaseHookEvent -= Toggle;
        GameManager.Instance.RetractionDoneEvent -= Toggle;
    }

    private void Update()
    {
        if (lineRenderer.enabled)
        {
               lineRenderer.SetPosition(0,GameManager.Instance.hook.origin);
               lineRenderer.SetPosition(1, this.transform.position);
        }
    }

    void Toggle()
        {           
                lineRenderer.enabled = !lineRenderer.enabled;           
        }
}

