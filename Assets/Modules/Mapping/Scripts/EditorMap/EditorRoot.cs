using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.UI
{
    /// <summary>
    /// Reference all UI SubElement
    /// </summary>
    public class EditorRoot : Singleton<EditorRoot>
    {
        public MapContent Content;
        public CurrentTile CurrentTile;
        public InformationRoot Information;
    }
}
