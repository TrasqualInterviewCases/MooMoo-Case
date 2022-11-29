using UnityEngine;

namespace Main.GamePlay.InteractionSystem
{
    public interface IInteractable
    {
        public string InteractionInfoText { get; set; }
        public void Interact(InteractionHandler interactor);
        public Transform GetTransform();
        public bool IsActive();
    }
}