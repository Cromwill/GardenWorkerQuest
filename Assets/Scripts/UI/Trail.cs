using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] private GameObject _trail;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _trail.SetActive(false);

        if (Input.GetMouseButtonDown(0))
            _trail.SetActive(true);

        _trail.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
