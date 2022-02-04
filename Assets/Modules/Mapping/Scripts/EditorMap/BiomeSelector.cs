using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
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
                Debug.Log(biome.BiomeName);
                SpriteWithLegend containerGO = Instantiate(container);
                containerGO.SetBiome(biome);
                containerGO.SetOnClick(SelectBiome);
                containerGO.transform.SetParent(content.transform);
                containerGO.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }

        void SelectBiome(Biome biome)
        {
            Debug.Log("Selected biome : " + biome.Label);
            EditorManager.Instance.SetBiome(biome);
            buttonText.text = biome.Label;
            contextWindow.SetActive(false);
        }
    }
}
