using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject interactionButton;

    IEnumerator interactionUpdate;

    Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void ActivateInteractionUI(IInteractable interactable)
    {
        StopInteractionUpdate();
        interactionUpdate = UpdateInteractionUI(interactable.GetTransform());
        StartCoroutine(interactionUpdate);
    }

    private void DeactivateInteractionUI(IInteractable ýnteractable)
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

    IEnumerator UpdateInteractionUI(Transform interactableTransform)
    {
        interactionButton.SetActive(true);

        var waitforsec = new WaitForSeconds(0.25f);
        while (true)
        {
            var screenPos = mainCam.WorldToScreenPoint(interactableTransform.position);
            interactionButton.transform.position = screenPos + new Vector3(0f, 250f, 0f);
            yield return waitforsec;
        }
    }

    public void OnInteractionButtonPressed()
    {

    }

    private void OnEnable()
    {
        InteractionHandler.OnInterectableDetected += ActivateInteractionUI;
        InteractionHandler.OnInterectableLost += DeactivateInteractionUI;
    }

    private void OnDisable()
    {
        InteractionHandler.OnInterectableDetected -= ActivateInteractionUI;
        InteractionHandler.OnInterectableLost -= DeactivateInteractionUI;
    }
}
