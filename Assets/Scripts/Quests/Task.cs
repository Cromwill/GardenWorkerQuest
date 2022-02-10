using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    protected int MaxValue;
    private int counter;
    public int Counter => MaxValue;

    public Action Complete;
    public Action<int,int> CounterChanged;

    protected void CheckComplition()
    {
        counter++;

        CounterChanged?.Invoke(counter, MaxValue);

        Debug.Log(counter);
        if (counter >= MaxValue)
            TaskComplete();
    }

    public void TaskComplete()
    {
        Complete?.Invoke();
    }
}
