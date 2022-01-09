using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    public class SliderValueToText : MonoBehaviour
    {
        private Text textSliderValue;
        public Slider sliderUI;

        void Start()
        {
            textSliderValue = GetComponent<Text>();
            ShowSliderValue();
        }

        public void ShowSliderValue()
        {
            if (textSliderValue != null && sliderUI != null)
            {
                textSliderValue.text = sliderUI.value.ToString();
            }
        }
    }
}
