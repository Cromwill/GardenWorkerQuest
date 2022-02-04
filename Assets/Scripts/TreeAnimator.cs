using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TreeAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent <Animator>();
    }

    public void Shake()
    {
        _animator.SetTrigger("Cuted");
    }
}
