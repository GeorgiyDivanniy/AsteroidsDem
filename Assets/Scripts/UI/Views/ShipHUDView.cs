using UnityEngine;
using UnityEngine.UI;
using ViewModels;

namespace Views
{
    public class ShipHUDView : MonoBehaviour, IHUDView
    {
        [SerializeField] private TMPro.TMP_Text positionText;
        [SerializeField] private TMPro.TMP_Text rotationText;
        [SerializeField] private TMPro.TMP_Text speedText;
        [SerializeField] private Slider chargesSlider; 
        [SerializeField] private Slider cooldownSlider; 

        public void SetPositionText(string text) => positionText.text = text;
        public void SetRotationText(string text) => rotationText.text = text;
        public void SetSpeedText(string text) => speedText.text = text;

        public void SetBeamCharges(int current, int max)
        {
            if (chargesSlider != null)
            {
                chargesSlider.maxValue = max;
                chargesSlider.value = current;
            }
        }

        public void SetBeamCooldownProgress(float progress)
        {
            if (cooldownSlider != null)
                cooldownSlider.value = progress;
        }
    }
}