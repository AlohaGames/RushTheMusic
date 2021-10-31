using System;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public static class Utils
    {
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
        /// TODO
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
        /// TODO
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
        /// TODO
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
    }
}
