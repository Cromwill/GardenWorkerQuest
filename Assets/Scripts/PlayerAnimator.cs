using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _inputHandler.MoveCalled += PlayWalkingAnimation;
        _inputHandler.Stoped += PlayerIdleAnimation;
    }

    private void OnDisable()
    {
        _inputHandler.MoveCalled -= PlayWalkingAnimation;
        _inputHandler.Stoped -= PlayerIdleAnimation;
    }

    private void PlayWalkingAnimation(Vector3 a)
    {
        _animator.SetFloat(PlayerAnimatorController.Param.Speed, 2);
    }

    private void PlayerIdleAnimation()
    {
        _animator.SetFloat(PlayerAnimatorController.Param.Speed, 0);
    }
}
