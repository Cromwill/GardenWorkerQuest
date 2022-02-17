using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private InputActionAdapter _inputHandler;
    [SerializeField] private HandPointer _hand;

    public event Action<Vector3> TouchedInteractable;
    public event Action<Vector3> HoldedOnInteractable;

    private void OnEnable()
    {
        //_inputHandler.Touched += OnTouch;
        _hand = FindObjectOfType<HandPointer>();

        if(_hand!= null)
            _hand.MouseDown += OnTouch;

        _inputHandler.Holded += OnHold;
    }

    private void OnDisable()
    {
        //_inputHandler.Touched -= OnTouch;
        if (_hand != null)
            _hand.MouseDown -= OnTouch;
        _inputHandler.Holded -= OnHold;
    }

    private Interactable TryGetInteractable(Vector2 mousePosition, out RaycastHit hitInfo)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
            if (hitInfo.collider.TryGetComponent(out Interactable interactable))
                return interactable;

        return null;
    }

    private void OnTouch(Vector2 position)
    {
        Interactable interactable = TryGetInteractable(position, out RaycastHit hitInfo);

        if (interactable != null)
        {
            interactable.Interact();
            TouchedInteractable?.Invoke(hitInfo.point);
        }
    }

    private void OnHold(Vector2 position)
    {
        Interactable interactable = TryGetInteractable(position, out RaycastHit hitInfo);

        if (interactable != null)
        {
            interactable.Interact(position);
            HoldedOnInteractable?.Invoke(hitInfo.point);
        }
    }

}
