using System;
using System.Collections.Generic;
using UnityEngine;

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
        /// Generate a random int value
        /// <example> Example(s):
        /// <code>
        ///     int a = Utils.RandomInt();
        /// </code>
        /// <code>
        ///     int b = Utils.RandomInt(0, 10);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="min">min value (default is 0)</param>
        /// <param name="max">max value (default is 1)</param>
        /// <returns>
        /// A random int value between min and max.
        /// </returns>
        public static int RandomInt(int min = 0, int max = 1)
        {
            int val = random.Next(min, max);
            return val;
        }

        /// <summary>
        /// Generate a random float value
        /// <example> Example(s):
        /// <code>
        ///     int a = Utils.RandomFloat();
        /// </code>
        /// <code>
        ///     int b = Utils.RandomFloat(0f, 10f);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="min">min value (default is 0)</param>
        /// <param name="max">max value (default is 1)</param>
        /// <returns>
        /// A random float value between min and max.
        /// </returns>
        public static float RandomFloat(float min = 0f, float max = 1f)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

        /// <summary>
        /// This function clamp a int value between a min and a max. 
        /// <example> Example(s):
        /// <code>
        ///     int a = -14;
        ///     a = a.Clamp(0, 20); // now a = 0
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

        /// <summary>
        /// Will clear all GameObject of current Scene
        /// Only for Unit Test
        /// <example> Example(s):
        /// <code>
        ///     [Test]
        ///     public void TestThis()
        ///     {
        ///         // DoSomething
        ///         ClearCurrentScene(true);
        ///     }
        /// </code>
        /// <code>
        ///     [UnityTest]
        ///     public IEnumerator TestThis()
        ///     {
        ///         // DoSomething
        ///         ClearCurrentScene();
        ///     }
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="immediate"> Do we need to use DestroyImmediate() (for [Test])</param>
        public static void ClearCurrentScene(bool immediate = false)
        {
            Transform[] objects = GameObject.FindObjectsOfType<Transform>();
            foreach (Transform obj in objects)
            {
                if (obj != null && obj.parent == null)
                {
                    if (immediate)
                    {
                        GameObject.DestroyImmediate(obj.gameObject);
                    }
                    else
                    {
                        GameObject.Destroy(obj.gameObject);
                    }
                }
            }
        }

        public static bool IsEmpty<T>(this List<T> list)
        {
            return (list.Count == 0);
        }
    }
}
