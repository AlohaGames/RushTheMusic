using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for a basic tile
    /// </summary>
    public class BasicTile : MonoBehaviour
    {
        /// <summary>
        /// Is called after all Update functions have been called.
        /// </summary>
        void LateUpdate()
        {
            transform.position += new Vector3(0, 0, -1 * TilesManager.Instance.TileSpeed * Time.deltaTime);
        }
    }
}
