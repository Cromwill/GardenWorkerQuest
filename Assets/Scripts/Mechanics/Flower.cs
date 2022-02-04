using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Interactable
{
    public override void OnInteract()
    {
        if(transform.localScale.magnitude<=2)
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
