using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public static bool IsEqualFloat(float a, float b, float epsilon = 0.01f)
        {
            return Math.Abs(a - b) <= epsilon;
        }
    }
}
