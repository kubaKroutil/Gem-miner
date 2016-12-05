using UnityEngine;
using System.Collections;

public class Miner : MonoBehaviour {
    
    public Hook hook;

    private bool canShoot = true;
    private Animator animator;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        hook = GetComponentInChildren<Hook>();
    }

    void Update()
    {
        if (!canShoot)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, hook.origin);
            lineRenderer.SetPosition(1, hook.gameObject.transform.position);
        }       
    }


    public void LaunchClaw()
    {
        if (canShoot)
        {
            canShoot = false;
            animator.speed = 0;
            hook.release = true;
        }       
    }

    public void ClawIsBack()
    {
        canShoot = true;
        animator.speed = 1;
        lineRenderer.enabled = false;
    }
}
