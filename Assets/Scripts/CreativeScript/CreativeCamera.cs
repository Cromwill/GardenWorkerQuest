using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreativeCamera : MonoBehaviour
{
    public Camera Camera;
    public Vector3 TargetPosition;
    public float changeSpeed;
    public CameraMover _mover;
    public string creo = "asd";

    private void Start()
    {
        if (PlayerPrefs.HasKey(creo) == false)
            StartCoroutine(CloseUp());
        else
            _mover.enabled = true;

        PlayerPrefs.SetFloat(creo, 0f);
    }
    IEnumerator CloseUp()
    {
        while (Camera.transform.position != TargetPosition)
        {
            Camera.transform.position = Vector3.MoveTowards(Camera.transform.position, TargetPosition, changeSpeed * Time.deltaTime);

            yield return null;
        }

        _mover.enabled = true;
    }
}
