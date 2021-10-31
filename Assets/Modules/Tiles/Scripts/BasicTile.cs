using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class BasicTile : MonoBehaviour
    {

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        void Start()
        {
            transform.localScale = new Vector3(10, 0.1f, TilesManager.Instance.TileSize);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        void LateUpdate()
        {
            transform.position += new Vector3(0, 0, -1 * TilesManager.Instance.TileSpeed * Time.deltaTime);
        }
    }
}
