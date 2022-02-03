using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make exporion (gameObject) say a random Quote
    /// </summary>
    public class ExperionQuote: GONode
    {
        private Experion experion;

        /// <summary>
        /// ExperionQuote Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionQuote(Graph graph) : base(graph)
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public ExperionQuote() : base()
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Make the dark wizard ice laser Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            if (SoundEffectManager.Instance.Sounds.experion_quotes.Length != 0)
            {
                SoundEffectManager.Instance.Play(
                    SoundEffectManager.Instance.Sounds.experion_quotes[Utils.RandomInt(0, SoundEffectManager.Instance.Sounds.experion_quotes.Length)], 
                    this.gameObject
                );
            }

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
