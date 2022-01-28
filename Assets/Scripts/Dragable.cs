using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragable : Interactable
{
    public override void Interact(Vector2 position)
    {
        Vector3 positionOnScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, positionOnScreen.z));

        transform.position = mouseWorldPosition;
    }
}
