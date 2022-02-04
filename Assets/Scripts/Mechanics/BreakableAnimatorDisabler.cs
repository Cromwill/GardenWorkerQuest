using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(Breakable))]
public class BreakableAnimatorDisabler : MonoBehaviour
{
    private Animator _animator;
    private Breakable _breakable;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _breakable = GetComponent<Breakable>();
        _breakable.DurabilityEnded += DisabelAnimator;
    }

    private void OnDisable()
    {
        _breakable.DurabilityEnded -= DisabelAnimator;
    }

    private void DisabelAnimator()
    {
        _animator.enabled = false;
    }
}
