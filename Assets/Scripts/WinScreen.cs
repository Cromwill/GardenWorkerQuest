using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Mask _mask;
    [SerializeField] private GameObject _panel;

    private void OnEnable()
    {
        _mask.Completed += Show;
    }

    private void OnDisable()
    {
        _mask.Completed -= Show;
    }

    private void Show()
    {
        _panel.SetActive(true);
    }
}
