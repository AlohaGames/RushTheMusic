using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the secondary bar
    /// </summary>
    public class SecondaryBar : HorizontalBar
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private Sprite[] icons_sprites;

        [SerializeField]
        private Color[] classColors;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        public new void Awake()
        {
            base.Awake();
            GlobalEvent.OnSecondaryUpdate.AddListener(UpdateBar);
        }

        /// <summary>
        /// Update UI of the bar
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="current"></param>
        /// <param name="max"></param>
        public override void UpdateBar(int current, int max)
        {
            // Change bar according to hero type
            Hero hero = GameManager.Instance.GetHero();
            if (hero != null)
            {
                if (hero is Warrior)
                {
                    icon.sprite = icons_sprites[(int) HeroType.Warrior];
                    bar.color = classColors[(int) HeroType.Warrior];
                } else if (hero is Wizard)
                {
                    icon.sprite = icons_sprites[(int) HeroType.Wizard];
                    bar.color = classColors[(int) HeroType.Wizard];
                }
            }

            base.UpdateBar(current, max);
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.OnSecondaryUpdate.RemoveListener(UpdateBar);
        }
    }
}
