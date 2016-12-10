using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerAnimator : MonoBehaviour {

    public Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        GameManager.Instance.RetractionDoneEvent += ResumeAnimation;
        GameManager.Instance.ReleaseHookEvent += StopAnimation;
    }

    void OnDisable()
    {

        GameManager.Instance.RetractionDoneEvent -= ResumeAnimation;
        GameManager.Instance.ReleaseHookEvent -= StopAnimation;
    }

    private void StopAnimation()
    {
        animator.speed = 0;
    }

    private void ResumeAnimation()
    {
        animator.speed = 1;
    }
}
