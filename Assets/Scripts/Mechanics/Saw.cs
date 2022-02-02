using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

[RequireComponent(typeof(Animator))]
public class Saw : MonoBehaviour
{
    [SerializeField] private InputActionAdapter _adapter;
    [SerializeField] private float _delay;

    private float _timeStamp;
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
        if (IsOnCooldown())
        {
            _timeStamp = Time.time + _delay;
            _animator.SetTrigger("Cut");
        }
    }

    private bool IsOnCooldown()
    {
        return _timeStamp <= Time.time;
    }
}
