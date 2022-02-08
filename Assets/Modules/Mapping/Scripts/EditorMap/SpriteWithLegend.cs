using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aloha.UI
{
    /// <summary>
    /// Sprite With Legend class
    /// </summary>
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

        /// <summary>
        /// OnClick Action
        /// </summary>
        private void OnClick()
        {
            if (cb != null)
            {
                cb(biome);
            }
        }

        /// <summary>
        /// Define shown biome
        /// </summary>
        /// <param name="biome">Biome to show</param>
        public void SetBiome(Biome biome)
        {
            this.biome = biome;
            this.text.text = biome.Label;
            this.image.sprite = biome.SidePanelSprites[0];
        }

        /// <summary>
        /// Define OnClick Callback
        /// </summary>
        /// <param name="cb">A Callback with Biome parameter</param>
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
