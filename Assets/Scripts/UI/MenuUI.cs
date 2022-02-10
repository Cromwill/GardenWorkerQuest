using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private Canvas _cameraSpaceCanvas;

    void Start()
    {
        _cameraSpaceCanvas.worldCamera = Camera.main;
    }
}
