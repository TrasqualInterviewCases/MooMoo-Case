using UnityEngine;

public interface IInteractable
{
    public string InteractionInfoText { get; set; }
    public void Interact();
    public void Lose();
    public Transform GetTransform();
}
