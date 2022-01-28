using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputActionAdapter : MonoBehaviour
{
    public event Action<Vector3> MoveCalled;
    public event Action MoveCanceled;
    public event Action<Vector2> Touched;
    public event Action<Vector2> Holded;

    private PlayerAction _input;

    private void Awake()
    {
        _input = new PlayerAction();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Start()
    {
        _input.Player.Move.canceled += ctx => OnMoveCanceled();
        _input.Player.Touch.started += ctx => OnTouch();
    }

    private void Update()
    {
        if (_input.Player.Hold.inProgress)
        {
            Holded?.Invoke(_input.Player.Hold.ReadValue<Vector2>());
        }

        if (_input.Player.Move.inProgress)
            OnMove();
    }

    private void OnMove()
    {
        MoveCalled?.Invoke(_input.Player.Move.ReadValue<Vector2>());
    }

    private void OnMoveCanceled()
    {
        MoveCanceled?.Invoke();
    }

    private void OnTouch()
    {
        Touched?.Invoke(_input.Player.TouchPosition.ReadValue <Vector2>());
    }
}
