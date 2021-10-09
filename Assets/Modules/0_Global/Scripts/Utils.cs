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
        // Add range of data to a source dictionary
        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>(
this IDictionary<TKey, TValue> source,
List<TKey> keys, List<TValue> values)
        {
            if (keys.Count != values.Count)
            {
                throw new Exception("Keys and values does not have the same Count");
            }
            for (int i = 0; i < keys.Count; i++)
            {
                source.Add(keys[i], values[i]);
            }
            return source;
        }
    }
}
