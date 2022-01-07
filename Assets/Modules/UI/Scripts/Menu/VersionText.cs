using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    public class VersionText : Text
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            this.text = Application.version;
        }
    }
}
