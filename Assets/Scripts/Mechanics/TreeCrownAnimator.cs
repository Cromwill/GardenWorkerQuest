using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Animator))]
public class TreeCrownAnimator : MonoBehaviour
{
    [SerializeField] private Breakable _breakable;
    [SerializeField] private RayfireRigid _rayFireRigid;
    [SerializeField] private TreeAnimator _treAnimator;

    private float _timeBeforeLeafDrop = 0.8f;
    private bool _leafDroped;
    private Animator _animator;

    public event Action LeafDroped;

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

        if(_leafDroped == false)
            StartCoroutine(DropLeafs());
    }

    private IEnumerator DropLeafs()
    {
        float time = 0;

        while(_timeBeforeLeafDrop > time)
        {
            time += Time.deltaTime;

            yield return null;
        }

        if(_treAnimator != null)
            _treAnimator.Shake();

        _leafDroped = true;
        _rayFireRigid.Initialize();
    }
}
