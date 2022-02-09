using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] private GameObject _trail;
    [SerializeField] private float _distance = -19f;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _trail.SetActive(false);

        if (Input.GetMouseButtonDown(0))
            _trail.SetActive(true);

        _trail.transform.position = GetWorldPositionOnPlane(Input.mousePosition, _distance);
    }

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Camera.main.transform.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
