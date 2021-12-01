using UnityEngine;
using System.Collections;

namespace Aloha
{
    // TODO
    /// <summary>
    /// Manage the track selection UI
    /// </summary>
    public class UITrackSelection : MonoBehaviour
    {
        [SerializeField]
        private GameObject trackElementPrefab;

        public GameObject TrackSelectionUI;

        /// <summary>
        /// Get the list of tracks 
        /// <example> Example(s):
        /// <code>
        ///     GetTrackList()
        /// </code>
        /// </example>
        /// </summary>
        public void GetTrackList()
        {
            // TODO
        }

        /// <summary>
        /// Display track list UI
        /// <example> Example(s):
        /// <code>
        ///     GetTrackList()
        /// </code>
        /// </example>
        /// </summary>
        public void ShowTrackList()
        {
            int trackNumber = 3;
            
            if(trackNumber >= 1)
            {
                for(int i = 0; i < trackNumber - 1; i++)
                {
                    GameObject trackElement = Instantiate(trackElementPrefab);
                    trackElement.transform.SetParent(TrackSelectionUI.transform);
                }
            }
        }
    }
}