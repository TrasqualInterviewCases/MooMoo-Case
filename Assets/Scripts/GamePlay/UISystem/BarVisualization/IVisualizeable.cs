using System;

namespace Main.GamePlay.UISystem
{
    public interface IVisualizeable
    {
        public Action<float, float> OnValueChanged { get; set; }
    }
}