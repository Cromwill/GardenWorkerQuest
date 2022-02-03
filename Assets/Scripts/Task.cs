using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    protected int _counter;

    public Action Complete;

    protected void CheckComplition()
    {
        _counter--;

        Debug.Log(_counter);
        if (_counter <= 0)
            TaskComplete();
    }

    public void TaskComplete()
    {
        Complete?.Invoke();
    }
}
