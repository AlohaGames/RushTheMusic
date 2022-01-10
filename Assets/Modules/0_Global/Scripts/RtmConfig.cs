using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class which contains RTM settings
    /// </summary>
    public class RtmConfig
    {
        public bool LeapMode; // leap : true, mouse : false
        public bool MouseHorizontalInversion; // true : inverted
        public bool MouseVerticalInversion; // true : inverted
        public bool AllowDynamicTexts; // true : Allowed
        public float MouseSensibility;
        public float GameVolume;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RtmConfig()
        {
            this.LeapMode = false;
            this.MouseHorizontalInversion = false;
            this.MouseVerticalInversion = false;
            this.AllowDynamicTexts = true;
            this.MouseSensibility = 1.0f;
            this.GameVolume = 1.0f;
        }
    }
}
