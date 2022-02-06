using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Task _task;

    private void OnEnable()
    {
        _task.Complete += ThrowOutJunk;
    }

    private void OnDisable()
    {
        _task.Complete -= ThrowOutJunk;
    }

    public void ThrowOutJunk()
    {
        _animator.SetTrigger("CleanCan");
    }
}
