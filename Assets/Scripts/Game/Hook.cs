﻿using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public Vector3 origin;
    public bool release = false;
    public bool retracting = false;
    
    public HookSpeed hookSpeed;



    void Start()
    {
        origin = transform.position;
        hookSpeed = new HookSpeed(HookSpeed.DefaultReleaseSpeed, HookSpeed.DefaultRetractSpeed);
        //bombButton = GameObject.FindObjectOfType<bonus_bomb_button>();
    }

    void OnEnable()
    {
        GameManager.Instance.ReleaseHookEvent += ReleaseHook;
        GameManager.Instance.RetractHookEvent += Retracting;
        GameManager.Instance.RetractionDoneEvent += RetractionDone;
    }

    void OnDisable()
    {
        GameManager.Instance.ReleaseHookEvent -= ReleaseHook;
        GameManager.Instance.RetractHookEvent -= Retracting;
        GameManager.Instance.RetractionDoneEvent -= RetractionDone;
    }

    void Update() {
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
        hookSpeed.SetRetractSpeed(HookSpeed.DefaultRetractSpeed);
        //bombButton.canShoot = true;

        
    }


   


    //public void ActivateSuperStrengthBonus()
    //{
    //    baseRetractSpeed = 10;
    //    basereleaseSpeed = 10;
    //}

    //public void BombExploded()
    //{
    //    variableRetractSpeed = 1;
    //}


}
