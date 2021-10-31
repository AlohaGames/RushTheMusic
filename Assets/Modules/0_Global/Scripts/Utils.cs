using System;

namespace Aloha
{
    public static class Utils
    {

        public static bool EqualFloat(float a, float b, float epsilon = 0.01f)
        {
            return Math.Abs(a - b) <= epsilon;
        }

        public static int InRange(this int value, int min, int max)
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

        public static float InRange(this float value, float min, float max)
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
