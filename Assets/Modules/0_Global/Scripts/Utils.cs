using System;
using System.Collections.Generic;

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

        public static float RandomFloat()
        {
            return RandomFloat(0f, 1f);
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

        public static bool IsEmpty<T>(this List<T> list)
        {
            return (list.Count == 0);
        }
    }
}
