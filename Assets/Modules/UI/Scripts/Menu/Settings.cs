using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    public class Settings : MonoBehaviour
    {
        public Slider volumeSlider;
        public Slider sensibilitySlider;

        /// <summary>
        /// Update music volume in audio manager
        /// <example> Example(s):
        /// <code>
        ///     settings.UpdateVolume();
        /// </code>
        /// </example>
        /// </summary>
        public void UpdateVolume()
        {
            AudioManager.Instance.UpdateVolume(volumeSlider.value / 100);
        }

        /// <summary>
        /// Update mouse sensibility
        /// <example> Example(s):
        /// <code>
        ///     settings.UpdateMouseSensibility();
        /// </code>
        /// </example>
        /// </summary>
        public void UpdateMouseSensibility()
        {
            GameManager.Instance.MouseSensibility = sensibilitySlider.value;
        }

        /// <summary>
        /// Set if the player uses leap motion or not
        /// <example> Example(s):
        /// <code>
        ///     settings.SetLeapMode(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value">true : leap is activated</param>
        public void SetLeapMode(bool value)
        {
            GameManager.Instance.SetLeapMode(value);
        }

        /// <summary>
        /// Set if the horizontal controls are inverted
        /// <example> Example(s):
        /// <code>
        ///     settings.SetMouseHorizontalInversion(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value">true : horizontal controls are inverted</param>
        public void SetMouseHorizontalInversion(bool value)
        {
            GameManager.Instance.MouseHorizontalInversion = value;
        }

        /// <summary>
        /// Set if the vertical controls are inverted
        /// <example> Example(s):
        /// <code>
        ///     settings.SetMouseVerticalInversion(false);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value">true : vertical controls are inverted</param>
        public void SetMouseVerticalInversion(bool value)
        {
            GameManager.Instance.MouseVerticalInversion = value;
        }

        /// <summary>
        /// Set if dynamic texts will appear or not
        /// <example> Example(s):
        /// <code>
        ///     settings.SetAllowDynamicTexts(true);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value">true : dynmic texts will appear</param>
        public void SetAllowDynamicTexts(bool value)
        {
            GameManager.Instance.AllowDynamicTexts = value;
        }
    }
}
