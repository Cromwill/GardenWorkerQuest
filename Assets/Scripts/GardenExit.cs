using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenExit : MonoBehaviour
{
    public Action ExitTriggered;

    //public void LoadQuestScene()
    //{
    //    //на всякий оставим вариант
    //    //ExitTriggered?.Invoke();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            ExitTriggered?.Invoke();
    }
}
