using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Animator))]
public class Saw : MonoBehaviour
{
    [SerializeField] private InputActionAdapter _adapter;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _adapter.Released += Cut;
    }

    private void OnDisable()
    {
        _adapter.Released -= Cut;
    }

    private void Cut()
    {
        _animator.SetTrigger("Cut");
    }
}
