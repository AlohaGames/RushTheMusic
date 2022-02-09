using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Aloha.UI
{
    /// <summary>
    /// Information Root UI
    /// </summary>
    public class InformationRoot : MonoBehaviour
    {
        public EditorRoot EditorRoot;
        public Button LoadMusic;
        public InputField PathToMusic;

        public InputField MapName;
        public InputField Description;

        public Text Duration;

        public Text NbTiles;
        public Button Export;
        public Button Import;
    }
}
