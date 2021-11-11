using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{

    public abstract class SideEnvironment : MonoBehaviour
    {
        public float height;

        public abstract void Initialize();
    }
}
