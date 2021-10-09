using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Aloha
{
    public class SerializeDictionary<TKey, TValue>
    {
        [SerializeField]
        public List<TKey> dictionaryKey;

        [SerializeField]
        public List<TValue> dictionaryValue;

        public SerializeDictionary(List<TKey> keys, List<TValue> values)
        {
            Initialized(keys, values);
        }

        public SerializeDictionary()
        {
            Initialized(new List<TKey>(), new List<TValue>());
        }

        private void Initialized(List<TKey> keys, List<TValue> values)
        {
            this.dictionaryKey = keys;
            this.dictionaryValue = values;
        }


        public void Add(TKey key, TValue value)
        {
            this.dictionaryKey.Add(key);
            this.dictionaryValue.Add(value);
        }

        public TValue GetValue(TKey searchKey)
        {
            int index = this.dictionaryKey.FindIndex(key => key.Equals(searchKey));
            if (index < 0)
            {
                return default(TValue);
            }
            return this.dictionaryValue[index];
        }
    }
}
