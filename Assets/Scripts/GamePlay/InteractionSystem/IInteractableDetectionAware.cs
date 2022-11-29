
namespace Main.GamePlay.InteractionSystem
{
    public interface IDetectionAware
    {
        public void GetDetected(InteractionHandler detector);
        public void GetUndetected();
    }
}