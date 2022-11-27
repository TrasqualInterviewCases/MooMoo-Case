using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string InteractionInfoText { get; set; }

    public Transform GetTransform() => transform;

    public void Interact()
    {
        GetPickedUp();
    }

    public void Lose()
    {

    }

    public abstract void GetPickedUp();
}
