using System;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public static event Action<IInteractable> OnInterectableDetected;
    public static event Action<IInteractable> OnInterectableLost;

    public void DetectInteractable(IInteractable interactable)
    {
        OnInterectableDetected?.Invoke(interactable);
    }

    public void LoseInteractable(IInteractable interactable)
    {
        OnInterectableLost?.Invoke(interactable);
    }
}
