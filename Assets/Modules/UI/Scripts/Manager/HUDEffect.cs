using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the HUD effect
    /// </summary>
    public class HUDEffect : MonoBehaviour
    {
        private Coroutine currentEffect;
        public Sprite[] effectsList;
        public Image hud;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            GlobalEvent.HudEffect.AddListener(Fade);
        }

        /// <summary>
        /// Show the hud
        /// <example> Example(s):
        /// <code>
        ///     this.Show();
        /// </code>
        /// </example>
        /// </summary>
        private void Show()
        {
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Hide the hud
        /// <example> Example(s):
        /// <code>
        ///     this.Hide();
        /// </code>
        /// </example>
        /// </summary>
        private void Hide()
        {
            hud.sprite = null;
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Display a specific effect with opacity
        /// <example> Example(s):
        /// <code>
        ///     hudEffect.Appear(0.5f, HUDEffectType.blood);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="opacity">Opacity of the effect</param>
        /// <param name="effect">Type of the effect</param>
        public void Appear(float opacity, HUDEffectType effect)
        {
            this.Show();

            // Select the effect to show
            hud.sprite = effectsList[(int)effect];
            
            // Change opacity
            Color c = Color.white;
            c.a = opacity;
            hud.color = c;
        }

        /// <summary>
        /// Fade a specific effect with a maximum opacity
        /// <example> Example(s):
        /// <code>
        ///     HUDEffect.Fade(0.8f, 1, HUDEffectType.blood);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="maxOpacity">Max opacity of the effect</param>
        /// <param name="duration">Duration of the effect</param>
        /// <param name="effect">Type of the effect</param>
        public void Fade(float maxOpacity, float duration, HUDEffectType effect)
        {
            if (currentEffect == null)
            {
                this.Show();
                currentEffect = StartCoroutine(this.FadeCoroutine(maxOpacity, duration, effect));
            }
        }

        /// <summary>
        /// Fade a specific effect with a maximum opacity
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(HUDEffect.Fade(0.8f, 1, HUDEffectType.blood));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="maxOpacity">Max opacity of the effect</param>
        /// <param name="duration">Duration of the effect</param>
        /// <param name="effect">Type of the effect</param>
        private IEnumerator FadeCoroutine(float maxOpacity, float duration, HUDEffectType effect)
        {
            // Select the effect to show
            hud.sprite = effectsList[(int)effect];

            float time = 0;
            Color c = Color.white;

            while (time < duration)
            {
                // Calculate the new opacity
                time += Time.deltaTime;
                float opacity = Mathf.Sin(time / duration * Mathf.PI) * maxOpacity;

                // Set the new opacity
                c.a = opacity;
                hud.color = c;

                yield return null;
            }

            this.Hide();
            currentEffect = null;
            yield return null;
        }

        /// <summary>
        /// Is called when a Scene or game ends.
        /// </summary>
        void OnDestroy()
        {
            GlobalEvent.HudEffect.RemoveListener(Fade);
        }
        
    }

    /// <summary>
    /// Enumerate the list of hud effects
    /// </summary>
    public enum HUDEffectType
    {
        /// <summary>
        /// Blood effect when player take damages
        /// </summary>
        blood = 0,

        /// <summary>
        /// Healing effect when player take damages
        /// </summary>
        heal = 1,

        /// <summary>
        /// Rage effect when the warrior uses its effect
        /// </summary>
        rage = 2,
    }
}
