using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{

    public abstract class SideEnvironment : MonoBehaviour
    {
        public float Height;

        public abstract void Initialize();
    }
}
