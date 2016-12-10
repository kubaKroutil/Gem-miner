using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HookSpeed
{
    public const float DefaultReleaseSpeed = 4;
    public const float DefaultRetractSpeed = 4;
    public float ReleaseSpeed { get; private set; }
    public float RetractSpeed { get; private set; }
    

    public HookSpeed(float releaseSpeed, float retractSpeed)
    {
        this.ReleaseSpeed = releaseSpeed;
        this.RetractSpeed = retractSpeed;
    }

    public void SetRetractSpeed(float retractSpeed)
    {
        RetractSpeed = retractSpeed;
    }

    public void SetReleaseSpeed(float releaseSpeed)
    {
        ReleaseSpeed = releaseSpeed;
    }
}

