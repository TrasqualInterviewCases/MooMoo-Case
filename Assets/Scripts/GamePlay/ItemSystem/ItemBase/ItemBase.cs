using Main.GamePlay.InteractionSystem;
using UnityEngine;

namespace Main.GamePlay.ItemSystem
{
    public abstract class ItemBase : MonoBehaviour, IInteractable
    {
        [field: SerializeField] public string InteractionInfoText { get; set; }
        protected InteractionHandler _interactor;

        public Transform GetTransform() => transform;

        protected bool isActive = true;
        public bool IsActive() => isActive;

        public void Interact(InteractionHandler interactor)
        {
            _interactor = interactor;
            isActive = false;
            GetPickedUp();
        }

        public abstract void GetPickedUp();
        public abstract void GetDropped();
    }
}