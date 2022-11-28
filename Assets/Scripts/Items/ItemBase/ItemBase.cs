using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IInteractable
{
    [field: SerializeField] public string InteractionInfoText {get;set;}

    protected InteractionHandler _interactor;

    public Transform GetTransform() => transform;

    public void Interact(InteractionHandler interactor)
    {
        _interactor = interactor;
        GetPickedUp();
    }

    public abstract void GetPickedUp();
    public abstract void GetDropped();
}
