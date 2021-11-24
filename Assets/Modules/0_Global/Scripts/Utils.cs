using System;
using System.Collections.Generic;

namespace Aloha
{
    /// <summary>
    /// Class that manage utils functions
    /// </summary>
    public static class Utils
    {
        private static System.Random random = new System.Random();

        /// <summary>
        /// This function return if 2 floats are equal with precision: <paramref name="epsilon"/>.
        /// <example> Example(s):
        /// <code>
        ///     bool a = IsEqualFloat(1.31f, 1.312f)
        /// </code>
        /// <code>
        ///     bool a = IsEqualFloat(1.312f, 1.3124f, 0.001f)
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="epsilon"></param>
        /// <returns>
        /// True if floats are Equals; otherwise, false.
        /// </returns>
        public static bool IsEqualFloat(float a, float b, float epsilon = 0.01f)
        {
            return Math.Abs(a - b) <= epsilon;
        }

        /// <summary>
        /// TODO 
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>
        /// A random int value between min and max.
        /// </returns>
        public static int RandomInt(int min, int max)
        {
            int val = random.Next(min, max);
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static float RandomFloat()
        {
            return RandomFloat(0f, 1f);
        }

        /// <summary>
        /// TODO 
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>
        /// A random float value between min and max.
        /// </returns>
        public static float RandomFloat(float min, float max)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        /// <summary>
        /// This function clamp a int value between a min and a max. 
        /// <example> Example(s):
        /// <code>
        ///     int a = (-14).Clamp(0, 20);
        /// </code>
        /// <code>
        ///     int a = 10;
        ///     int b = a.Clamp(0, 10);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>
        /// A int value that is between min and max.
        /// </returns>
        public static int Clamp(this int value, int min, int max)
        {
            if (value <= min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        /// <summary>
        /// This function clamp a float value between a min and a max. 
        /// <example> Example(s):
        /// <code>
        ///     int a = (-14f).Clamp(0, 20);
        /// </code>
        /// <code>
        ///     float a = 20.0;
        ///     float b = a.Clamp(0, 10);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>
        /// A float value that is between min and max.
        /// </returns>
        public static float Clamp(this float value, float min, float max)
        {
            if (value <= min)
            {
                return min;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        public static bool IsEmpty<T>(this List<T> list)
        {
            return (list.Count == 0);
        }
    }
}
