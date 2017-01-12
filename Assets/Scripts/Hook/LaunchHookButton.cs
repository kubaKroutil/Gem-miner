using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchHookButton : MonoBehaviour {

	public void LaunchHook()
    {
        GameManager.Instance.CallReleaseHookEvent();
    }
}
