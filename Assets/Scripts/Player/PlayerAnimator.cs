using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private InputActionAdapter _inputHandler;
    [SerializeField] private Animator _animator;

    private GardenExit _gardenExit;
    private void OnEnable()
    {
        _gardenExit = FindObjectOfType<GardenExit>();

        if (_gardenExit != null)
            _gardenExit.ExitTriggered += Celebration;

        _inputHandler.MoveCalled += PlayWalkingAnimation;
        _inputHandler.MoveCanceled += PlayerIdleAnimation;
    }

    private void OnDisable()
    {
        if (_gardenExit != null)
            _gardenExit.ExitTriggered += Celebration;

        _inputHandler.MoveCalled -= PlayWalkingAnimation;
        _inputHandler.MoveCanceled -= PlayerIdleAnimation;
    }

    private void PlayWalkingAnimation(Vector3 position)
    {
        _animator.SetFloat(PlayerAnimatorController.Param.Speed, 2);
    }

    private void PlayerIdleAnimation()
    {
        _animator.SetFloat(PlayerAnimatorController.Param.Speed, 0);
    }

    private void Celebration()
    {
        transform.localEulerAngles = new Vector3(0, 90f, 0);
        _animator.SetTrigger(PlayerAnimatorController.State.Celebration);
    }
}
