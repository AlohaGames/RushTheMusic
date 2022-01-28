using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aloha.UI
{
    public class SpriteWithLegend : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private Image image;

        private Action<String> cb;

        private void Awake()
        {

            image.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (cb != null)
            {
                cb(this.text.text);
            }
        }


        public void SetText(string text)
        {
            this.text.text = text;
        }

        public void SetImage(Sprite sprite)
        {
            this.image.sprite = sprite;
        }

        public void SetOnClick(Action<String> cb)
        {
            this.cb = cb;
        }

        private void OnDestroy()
        {
            image.GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
