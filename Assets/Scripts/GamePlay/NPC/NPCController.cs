using Main.GamePlay.InteractionSystem;
using Main.Managers;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Main.GamePlay.NPC
{
    public class NPCController : MonoBehaviour, IInteractableDetectionAware
    {
        [SerializeField] TMP_Text talkText;
        [SerializeField] private string detectedText;
        [SerializeField] private string interactedText;
        [SerializeField] private string winText;

        [field: SerializeField] public string InteractionInfoText { get; set; }

        private Animator anim;

        private Transform detectorTransform;

        private IEnumerator talkTextCo;

        private void Awake()
        {
            anim = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            if (detectorTransform != null)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(detectorTransform.position - transform.position), Time.deltaTime * 5f);
            }
        }

        public void GetDetected(InteractionHandler detector)
        {
            detectorTransform = detector.transform;
            SetTalkText(detectedText, 1f);
        }

        public Transform GetTransform() => transform;

        public void GetUndetected()
        {
            detectorTransform = null;
        }

        public void Interact(InteractionHandler interactor)
        {
            SetTalkText(interactedText, 3f);
            anim.SetTrigger("shrug");
        }

        public bool IsActive()
        {
            return true;
        }

        private void SetTalkText(string content, float duration)
        {
            talkText.SetText(content);
            talkText.gameObject.SetActive(true);

            ResetTalkTextCo();
            talkTextCo = TalkTextDisappearCo(duration);
            StartCoroutine(talkTextCo);
        }

        private void ResetTalkTextCo()
        {
            if (talkTextCo != null)
            {
                StopCoroutine(talkTextCo);
            }
        }

        private IEnumerator TalkTextDisappearCo(float duration)
        {
            yield return new WaitForSeconds(duration);
            talkText.gameObject.SetActive(false);
        }

        private void OnWin()
        {
            SetTalkText(winText, 5f);
            anim.SetTrigger("clap");
        }

        private void OnEnable()
        {
            GameManager.OnGameWin += OnWin;
        }

        private void OnDisable()
        {
            GameManager.OnGameWin -= OnWin;
        }
    }
}