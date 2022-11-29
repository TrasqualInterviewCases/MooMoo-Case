
namespace Main.GamePlay.InteractionSystem
{
    public interface IInteractableDetectionAware : IInteractable
    {
        public void GetDetected(InteractionHandler detector);
        public void GetUndetected();
    }
}