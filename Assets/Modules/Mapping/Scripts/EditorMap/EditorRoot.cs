using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.UI
{
    public class EditorRoot : Singleton<EditorRoot>
    {
        public MapContent Content;
        public CurrentTile CurrentTile;
        public InformationRoot Information;
    }
}
