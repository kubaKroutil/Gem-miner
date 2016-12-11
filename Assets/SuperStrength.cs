using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStrength : MonoBehaviour {

    private int bonusSpeed = 10;

    private void OnEnable()
    {
        PowerUpManager.Instance.UseSuperStrenghtEvent += UseSuperStrength;
    }

    private void OnDisable()
    {
        PowerUpManager.Instance.UseSuperStrenghtEvent -= UseSuperStrength;
    }

    private void UseSuperStrength()
    {
        GameManager.Instance.hook.hookSpeed.SetReleaseSpeed(bonusSpeed);
        GameManager.Instance.hook.hookSpeed.SetRetractSpeed(bonusSpeed);
    }
}
