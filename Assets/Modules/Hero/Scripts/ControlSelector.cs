using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Allows to change between leap mode and keyboard mode
    /// </summary>
    public class ControlSelector : MonoBehaviour
    {
        private bool actualMode; // leap : true, mouse : false

        [SerializeField]
        protected GameObject leapController;

        [SerializeField]
        protected GameObject mouseController;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        private void Start()
        {
            this.actualMode = !GameManager.Instance.Config.LeapMode;
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            // if leap mode changes, update right hands to active
            if (GameManager.Instance.Config.LeapMode != this.actualMode)
            {
                this.actualMode = GameManager.Instance.Config.LeapMode;
                ActivateLeapHands(this.actualMode);
            }
        }

        /// <summary>
        /// If true, activate leap hands. Otherwise, activate mouse hands
        /// <example> Example(s):
        /// <code>
        ///     ActivateLeapHands()
        /// </code>
        /// </example>
        /// </summary>
        /// /// <param name="leapActivated"></param>
        void ActivateLeapHands(bool leapActivated)
        {
            leapController.SetActive(leapActivated);
            mouseController.SetActive(!leapActivated);
        }
    }
}
