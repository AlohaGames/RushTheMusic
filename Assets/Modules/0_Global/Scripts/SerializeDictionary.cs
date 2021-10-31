using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <param name="TKey"></param>
    /// <param name="TValue"></param>
    public class SerializeDictionary<TKey, TValue>
    {
        public List<TKey> DictionaryKey;
        public List<TValue> DictionaryValue;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="values"></param>
        public SerializeDictionary(List<TKey> keys, List<TValue> values)
        {
            Initialized(keys, values);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        public SerializeDictionary()
        {
            Initialized(new List<TKey>(), new List<TValue>());
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="values"></param>
        private void Initialized(List<TKey> keys, List<TValue> values)
        {
            this.DictionaryKey = keys;
            this.DictionaryValue = values;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="addKey"></param>
        /// <param name="addValue"></param>
        public void Add(TKey addKey, TValue addValue)
        {
            int index = this.DictionaryKey.FindIndex(key => key.Equals(addKey));
            // If value already exists
            if (index >= 0)
            {
                this.DictionaryKey.RemoveAt(index);
                this.DictionaryValue.RemoveAt(index);
            }
            this.DictionaryKey.Add(addKey);
            this.DictionaryValue.Add(addValue);
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns>
        /// TODO
        /// </returns>
        public TValue GetValue(TKey searchKey)
        {
            int index = this.DictionaryKey.FindIndex(key => key.Equals(searchKey));
            if (index < 0)
            {
                return default(TValue);
            }
            return this.DictionaryValue[index];
        }
    }
}
