using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Singleton that manage the input binding
    /// </summary>
    public class InputBinding : Singleton<InputBinding>
    {
        public KeyCode Pause = KeyCode.Escape;
        public KeyCode Quit = KeyCode.F12;
        public KeyCode UseItem = KeyCode.Space;
        public KeyCode Attack = KeyCode.Mouse0;
        public KeyCode Defense = KeyCode.Mouse1;
    }
}
