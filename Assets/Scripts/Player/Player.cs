using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PositionPersistence _positionPersistence;
    private void Awake()
    {
        _positionPersistence = FindObjectOfType<PositionPersistence>();

        transform.position = _positionPersistence.LoadPosition();
    }
}
