using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for a basic tile
    /// </summary>
    public class BasicTile : MonoBehaviour
    {

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            transform.localScale = new Vector3(10, 0.1f, TilesManager.Instance.TileSize);
        }

        /// <summary>
        /// Is called after all Update functions have been called.
        /// </summary>
        void LateUpdate()
        {
            transform.position += new Vector3(0, 0, -1 * TilesManager.Instance.TileSpeed * Time.deltaTime);
        }
    }
}
