using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenExit : MonoBehaviour
{
    public Action ExitTriggered;

    //public void LoadQuestScene()
    //{
    //    //�� ������ ������� �������
    //    //ExitTriggered?.Invoke();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            ExitTriggered?.Invoke();
    }
}
