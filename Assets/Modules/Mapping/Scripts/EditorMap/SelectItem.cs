using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Aloha.UI
{
    /// <summary>
    /// Select Chest Item Dropdown
    /// </summary>
    [RequireComponent(typeof(TMPro.TMP_Dropdown))]
    public class SelectItem : MonoBehaviour
    {
        public Sprite HealPotion;
        public Sprite SecondaryPotion;
        public Sprite ExperiencePotion;

        private TMP_Dropdown dropdown;

        private void Awake()
        {
            dropdown = GetComponent<TMP_Dropdown>();
            dropdown.ClearOptions();
            PopulateDropdown();
        }

        /// <summary>
        /// Populate Dropdown
        /// </summary>
        private void PopulateDropdown()
        {
            foreach (ItemType type in (ItemType[]) Enum.GetValues(typeof(ItemType)))
            {
                if (type == ItemType.manaPotion) continue;
                dropdown.AddOptions(new List<TMP_Dropdown.OptionData>() { GetOption(type) });
            }
        }

        /// <summary>
        /// Confirm Value
        /// </summary>
        public void SubmitValue()
        {
            EnemyMapping enemyMapping = EditorManager.Instance.SelectedTileUI.GetCurrentEnemy(EditorManager.Instance.GetLevelMapping());
            enemyMapping?.AddParameters("Item", dropdown.options[dropdown.value].text);
        }

        /// <summary>
        /// GetOption based on ItemType
        /// </summary>
        /// <param name="type">ItemType</param>
        /// <returns>OptionData (Sprite and description)</returns>
        private TMP_Dropdown.OptionData GetOption(ItemType type)
        {
            switch (type)
            {
                case ItemType.healPotion:
                    return new TMP_Dropdown.OptionData("Soin", HealPotion);
                case ItemType.ragePotion:
                    return new TMP_Dropdown.OptionData("Secondaire", SecondaryPotion);
                case ItemType.manaPotion:
                    return new TMP_Dropdown.OptionData("Secondaire", SecondaryPotion);
                case ItemType.experiencePotion:
                    return new TMP_Dropdown.OptionData("Expérience", ExperiencePotion);
                default:
                    return null;
            }
        }
    }
}
