using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Interactable _interactable;

    private void OnEnable()
    {
        _interactable.Taped += Shake;
    }

    private void OnDisable()
    {
        _interactable.Taped -= Shake;
    }

    public void Shake()
    {
        _animator.SetTrigger("Taped");
    }
}
