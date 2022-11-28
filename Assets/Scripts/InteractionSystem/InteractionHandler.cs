using System;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public event Action<IInteractable> OnInterectableDetected;
    public event Action OnInterectableLost;

    [SerializeField] private InteractionUI interactionUIPrefab;

    [SerializeField] private float detectionRange = 3f;

    private IInteractable currentInteractableObject;

    private void Awake()
    {
        var UI = Instantiate(interactionUIPrefab);
        UI.Initialize(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            DetectInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            LoseInteractable();
        }
    }

    public void DetectInteractable(IInteractable interactable)
    {
        OnInterectableDetected?.Invoke(interactable);
        currentInteractableObject = interactable;
    }

    public void LoseInteractable()
    {
        OnInterectableLost?.Invoke();
        currentInteractableObject = null;
    }

    public void Interact()
    {
        if (currentInteractableObject != null)
            currentInteractableObject.Interact(this);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        GetComponent<SphereCollider>().radius = detectionRange;
    }
#endif
}
