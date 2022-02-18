using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPoint : MonoBehaviour
{
    private QuestArrowCreator _arrowCreator;
    private void Start()
    {
        _arrowCreator = FindObjectOfType<QuestArrowCreator>();
        _arrowCreator.CreatePointingArrow(this);
    }
}
