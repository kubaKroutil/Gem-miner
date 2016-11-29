using UnityEngine;
using System.Collections;

public class Miner : MonoBehaviour {

    public Claw claw;
    public bool canShoot = true;
    public Animator animator;
    private LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        animator = GetComponent<Animator>();
        claw = GetComponentInChildren<Claw>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            LaunchClaw();
        }
        if (!canShoot)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, claw.gameObject.transform.position);
        }
        
    }


    void LaunchClaw()
    {
        canShoot = false;
        animator.speed = 0;
        claw.release = true;
    }

    public void ClawIsBack()
    {
        canShoot = true;
        animator.speed = 1;
        lineRenderer.enabled = false;
    }
}
