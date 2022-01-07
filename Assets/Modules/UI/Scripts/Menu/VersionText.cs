using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Manage the text displaying the version
    /// </summary>
    public class VersionText : MonoBehaviour
    {
        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            this.gameObject.GetComponent<Text>().text = Application.version;
        }
    }
}
