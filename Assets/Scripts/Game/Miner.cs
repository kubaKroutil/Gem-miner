using UnityEngine;
using System.Collections;

public class Miner : MonoBehaviour {
    
    public Hook claw;
    public bool canShoot = true;
    public Animator animator;
    private LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        claw = GetComponentInChildren<Hook>();
    }

    void Update()
    {
        if (!canShoot)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, claw.origin);
            lineRenderer.SetPosition(1, claw.gameObject.transform.position);
        }       
    }


    public void LaunchClaw()
    {
        if (canShoot)
        {
            canShoot = false;
            animator.speed = 0;
            claw.release = true;
        }
        
    }

    public void ClawIsBack()
    {
        canShoot = true;
        animator.speed = 1;
        lineRenderer.enabled = false;
    }
}
