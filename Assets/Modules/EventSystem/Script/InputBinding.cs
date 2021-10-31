using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO
/// </summary>
public class InputBinding : Singleton<InputBinding>
{
    public KeyCode Pause = KeyCode.Escape;
    public KeyCode Quit = KeyCode.F12;
    public KeyCode Attack = KeyCode.Mouse0;
    public KeyCode Defense = KeyCode.Mouse1;
}
