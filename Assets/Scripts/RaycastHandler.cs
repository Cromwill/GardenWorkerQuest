using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private InputActionAdapter _inputHandler;

    private void OnEnable()
    {
        _inputHandler.Touched += OnTouch;
        _inputHandler.Holded += OnHold;
    }

    private void OnDisable()
    {
        _inputHandler.Touched -= OnTouch;
        _inputHandler.Holded -= OnHold;
    }

    private Interactable TryGetInteractable(Vector2 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
            if (hitInfo.collider.TryGetComponent(out Interactable interactable))
                return interactable;

        return null;
    }

    private void OnTouch(Vector2 position)
    {

        Interactable interactable = TryGetInteractable(position);

        if (interactable != null)
            interactable.Interact();
    }

    private void OnHold(Vector2 position)
    {
        Interactable interactable = TryGetInteractable(position);

        if (interactable != null)
            interactable.Interact(position);
    }
}
