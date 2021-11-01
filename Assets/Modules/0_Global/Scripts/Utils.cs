using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
            return (float) val;
        }
    }
}
