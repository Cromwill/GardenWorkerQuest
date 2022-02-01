using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private Mask[] _masks;
    [SerializeField] private GameObject _panel;

    private int _count;

    private void OnEnable()
    {
        foreach (var mask in _masks)
        {
            mask.Completed += TryShow;
        }
    }

    private void OnDisable()
    {
        foreach (var mask in _masks)
        {
            mask.Completed -= TryShow;
        }
    }

    private void TryShow()
    {
        _count++;

        if(_count>=_masks.Length)
            _panel.SetActive(true);
    }
}
