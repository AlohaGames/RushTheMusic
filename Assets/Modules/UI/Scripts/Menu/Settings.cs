using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    public class Settings : MonoBehaviour
    {
        public Slider sensibilitySlider;

        public void UpdateVolume()
        {
            // TODO Update game volume in the right manager
        }

        public void UpdateMouseSensibility()
        {
            GameManager.Instance.MouseSensibility = sensibilitySlider.value;
        }

        public void SetLeapMode(bool value)
        {
            GameManager.Instance.SetLeapMode(value);
        }

        public void SetMouseHorizontalInversion(bool value)
        {
            GameManager.Instance.MouseHorizontalInversion = value;
        }

        public void SetMouseVerticalInversion(bool value)
        {
            GameManager.Instance.MouseVerticalInversion = value;
        }

        public void SetAllowDynamicTexts(bool value)
        {
            GameManager.Instance.AllowDynamicTexts = value;
        }
    }
}
