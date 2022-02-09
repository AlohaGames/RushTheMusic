using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Select Map Biome
    /// </summary>
    public class BiomeSelector : MonoBehaviour
    {

        [SerializeField]
        private Biome[] biomesList;

        [SerializeField]
        private SpriteWithLegend container;

        [SerializeField]
        private Text buttonText;

        [SerializeField]
        private GameObject contextWindow;

        [SerializeField]
        private GameObject content;

        void Awake()
        {
            foreach (Biome biome in biomesList)
            {
                SpriteWithLegend containerGO = Instantiate(container);
                containerGO.SetBiome(biome);
                containerGO.SetOnClick(SelectBiome);
                containerGO.transform.SetParent(content.transform);
                containerGO.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        /// <summary>
        /// Select Biome based on name
        /// </summary>
        /// <param name="biomeName">BiomeName parameter in Biome</param>
        public void SelectBiome(string biomeName)
        {
            foreach (Biome biome in biomesList)
            {
                if (biome.BiomeName == biomeName)
                {
                    SelectBiome(biome);
                    return;
                }
            }
            SelectBiome(biomesList[0]);
        }

        /// <summary>
        /// Select Biome based on Biome
        /// </summary>
        /// <param name="biome">Biome to select</param>
        private void SelectBiome(Biome biome)
        {
            Debug.Log("Selected biome : " + biome.Label);
            EditorManager.Instance.SetBiome(biome);
            buttonText.text = biome.Label;
            contextWindow.SetActive(false);
        }
    }
}
