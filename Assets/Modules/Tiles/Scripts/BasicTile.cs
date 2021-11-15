using UnityEngine;

namespace Aloha
{
    public class BasicTile : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            transform.localScale = new Vector3(10, 0.1f, TilesManager.Instance.tileSize);
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position += new Vector3(0, 0, -1 * TilesManager.Instance.tileSpeed * Time.deltaTime);
        }
    }
}