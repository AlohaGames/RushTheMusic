using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBinding : Singleton<InputBinding>
{
    public KeyCode pause = KeyCode.Escape;
    public KeyCode quit = KeyCode.F12;
    public KeyCode attack = KeyCode.Mouse0;
    public KeyCode defense = KeyCode.Mouse1;
}
