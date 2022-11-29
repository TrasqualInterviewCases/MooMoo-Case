using Main.GamePlay.InteractionSystem;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Main.GamePlay.UISystem
{
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactionButton;
        private InteractionHandler _interactionHandler;
        private TMP_Text interactionText;

        private IEnumerator interactionUpdate;

        private Camera mainCam;

        public void Initialize(InteractionHandler interactionHandler)
        {
            mainCam = Camera.main;
            interactionText = interactionButton.GetComponentInChildren<TMP_Text>();

            _interactionHandler = interactionHandler;
            _interactionHandler.OnInterectableDetected += ActivateInteractionUI;
            _interactionHandler.OnInterectableLost += DeactivateInteractionUI;
        }

        private void ActivateInteractionUI(IInteractable interactable)
        {
            StopInteractionUpdate();
            interactionUpdate = UpdateInteractionUI(interactable);
            StartCoroutine(interactionUpdate);
        }

        private void DeactivateInteractionUI()
        {
            StopInteractionUpdate();
            interactionButton.SetActive(false);
        }

        private void StopInteractionUpdate()
        {
            if (interactionUpdate != null)
            {
                StopCoroutine(interactionUpdate);
            }
        }

        IEnumerator UpdateInteractionUI(IInteractable interactable)
        {
            interactionButton.SetActive(true);
            interactionText.SetText(interactable.InteractionInfoText);

            while (true)
            {
                var screenPos = mainCam.WorldToScreenPoint(interactable.GetTransform().position);
                interactionButton.transform.position = screenPos + new Vector3(0f, 250f, 0f);
                yield return null;
            }
        }

        public void OnInteractionButtonPressed()
        {
            _interactionHandler.Interact();
            DeactivateInteractionUI();
        }

        private void OnDisable()
        {
            _interactionHandler.OnInterectableDetected -= ActivateInteractionUI;
            _interactionHandler.OnInterectableLost -= DeactivateInteractionUI;
        }
    }
}