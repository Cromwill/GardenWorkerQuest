using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Action<Vector3> MoveCalled;
    public Action Stoped;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        if (_playerInput.Player.Move.inProgress)
        {
            Vector2 inputDirection = _playerInput.Player.Move.ReadValue<Vector2>();
            Vector3 _direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            MoveCalled?.Invoke(_direction);
        }

        if (_playerInput.Player.Move.inProgress == false)
            Stoped?.Invoke();
    }
}
