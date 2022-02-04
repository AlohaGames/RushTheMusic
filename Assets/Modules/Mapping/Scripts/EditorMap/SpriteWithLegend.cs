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

        private Biome biome;

        private Action<Biome> cb;

        private void Awake()
        {

            image.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (cb != null)
            {
                cb(biome);
            }
        }

        public void SetBiome(Biome biome)
        {
            this.biome = biome;
            this.text.text = biome.Label;
            this.image.sprite = biome.SidePanelSprites[0];
        }

        public void SetOnClick(Action<Biome> cb)
        {
            this.cb = cb;
        }

        private void OnDestroy()
        {
            image.GetComponent<Button>().onClick.RemoveListener(OnClick);
        }
    }
}
