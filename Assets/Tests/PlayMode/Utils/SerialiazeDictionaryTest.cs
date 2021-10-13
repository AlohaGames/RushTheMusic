using NUnit.Framework;
using System.Collections.Generic;
using Aloha;


namespace Aloha.Test
{
    public class SerialiazeDictionaryTest
    {

        public SerializeDictionary<int, string> GetHelloWorldDictionary()
        {
            List<int> keys = new List<int>();
            keys.Add(3);
            keys.Add(5);

            List<string> values = new List<string>();
            values.Add("Hello");
            values.Add("World");

            SerializeDictionary<int, string> sd = new SerializeDictionary<int, string>(keys, values);
            Assert.AreEqual(2, sd.dictionaryKey.Count);
            Assert.AreEqual(2, sd.dictionaryValue.Count);
            return sd;
        }

        [Test]
        public void SerialiazeDictionaryTestConstructor()
        {
            SerializeDictionary<int, string> sd0 = new SerializeDictionary<int, string>();
            Assert.AreEqual(0, sd0.dictionaryKey.Count);
            Assert.AreEqual(0, sd0.dictionaryValue.Count);

            SerializeDictionary<int, string> sd1 = GetHelloWorldDictionary();
            Assert.AreEqual(2, sd1.dictionaryKey.Count);
            Assert.AreEqual(2, sd1.dictionaryValue.Count);
        }

        [Test]
        public void SerialiazeDictionaryTestGetValue()
        {
            SerializeDictionary<int, string> sd = GetHelloWorldDictionary();
            Assert.AreEqual("Hello", sd.GetValue(3));
            Assert.AreEqual("World", sd.GetValue(5));
        }

        [Test]
        public void SerialiazeDictionaryTestAdd()
        {
            SerializeDictionary<int, string> sd = GetHelloWorldDictionary();
            sd.Add(13, "Dodo");
            Assert.AreEqual("Dodo", sd.GetValue(13));

            sd.Add(13, "Titi");
            Assert.AreEqual("Titi", sd.GetValue(13));
        }
    }
}
