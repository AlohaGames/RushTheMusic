using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aloha
{
    public static class Utils
    {

        public static bool EqualFloat(float a, float b, float epsilon = 0.01f)
        {
            return Math.Abs(a - b) <= epsilon;
        }
    }
}
