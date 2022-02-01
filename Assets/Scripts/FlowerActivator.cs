using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerActivator : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Flower flower))
        {
            flower.Interact();
        }
    }
}
