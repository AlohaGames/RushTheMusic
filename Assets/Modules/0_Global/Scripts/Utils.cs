using System;
using UnityEngine;

namespace Aloha
{
    public static class Utils
    {

        private static System.Random random = new System.Random();

        public static bool EqualFloat(float a, float b, float epsilon = 0.01f)
        {
            return Math.Abs(a - b) <= epsilon;
        }

        public static int RandomInt(int min, int max)
        {
            int val = random.Next(min, max);
            return val;
        }

        public static float RandomFloat(float min, float max)
        {
            double val = (random.NextDouble() * (max - min) + min);
            return (float)val;
        }

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

        public static void ClearCurrentScene(bool immediate = false)
        {
            Transform[] objects = GameObject.FindObjectsOfType<Transform>();
            foreach (Transform obj in objects)
            {
                if (obj.parent == null)
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
    }
}
