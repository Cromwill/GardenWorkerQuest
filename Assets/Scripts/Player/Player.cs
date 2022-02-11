using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PositionPersistence _positionPersistence;
    private void Start()
    {
        _positionPersistence = FindObjectOfType<PositionPersistence>();

        if (_positionPersistence.HasSavedPosition())
            transform.position = _positionPersistence.LoadPosition();
        else
            transform.position = _positionPersistence.DefaultPosition;
    }
}
