using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBinding : Singleton<InputBinding>
{
    public KeyCode pause = KeyCode.Space;
    public KeyCode quit = KeyCode.Escape;
    public KeyCode attack = KeyCode.Mouse0;
    public KeyCode defense = KeyCode.Mouse1;
}
