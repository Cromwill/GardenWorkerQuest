using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TreeCrownAnimator : MonoBehaviour
{
    [SerializeField] private Breakable _breakable;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _breakable.DurabilityEnded += StartAnimation;
    }

    private void OnDisable()
    {
        _breakable.DurabilityEnded -= StartAnimation;
    }

    private void StartAnimation()
    {
        _animator.SetTrigger("DeadBrunchCuted");
    }
}
