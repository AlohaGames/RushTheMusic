using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// This class test the utils class functions.
    /// </summary>
    public class UtilsTest
    {
        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void EqualFloatTest()
        {
            //True
            Assert.IsTrue(Utils.IsEqualFloat(3.2254346f, 3.22f));

            //False
            Assert.IsTrue(Utils.IsEqualFloat(3.219453f, 3.2254655f));

            //Epsilon True
            Assert.IsTrue(Utils.IsEqualFloat(3.213f, 3.213468484f, 0.001f));

            //Epsilon False
            Assert.IsTrue(Utils.IsEqualFloat(3.2139484548f, 3.21456226685f));
        }

        /// <summary>
        /// Test RandomInt function
        /// </summary>
        [Test]
        public void RandomIntTest()
        {
            //True
            int randomInt = Utils.RandomInt(0, 10);

            // Test if random number is between min and max
            Assert.GreaterOrEqual(randomInt, 0);
            Assert.LessOrEqual(randomInt, 10);

            int randomInt2 = Utils.RandomInt();

            // Test if the second random number is between min and max
            Assert.GreaterOrEqual(randomInt2, 0);
            Assert.LessOrEqual(randomInt2, 1);
        }

        /// <summary>
        /// Test RandomFloat function
        /// </summary>
        [Test]
        public void RandomFloatTest()
        {
            float randomFloat = Utils.RandomFloat(0, 10);

            // Test if random number is between min and max
            Assert.GreaterOrEqual(randomFloat, 0);
            Assert.LessOrEqual(randomFloat, 10);

            float randomFloat2 = Utils.RandomFloat();

            // Test if the second random number is between min and max
            Assert.GreaterOrEqual(randomFloat2, 0);
            Assert.LessOrEqual(randomFloat2, 1);
        }

        /// <summary>
        /// Test int.Clamp() function
        /// </summary>
        [Test]
        public void ClampIntTest()
        {
            //True positive
            Assert.AreEqual(0, 0.Clamp(-10, 10));

            //True max positive
            Assert.AreEqual(10, 10.Clamp(-10, 10));

            //True min negative
            Assert.AreEqual(-10, (-10).Clamp(-10, 10));

            //False above min negative
            Assert.AreEqual(-10, (-11).Clamp(-10, 10));

            //False above max positive
            Assert.AreEqual(10, 11.Clamp(-10, 10));
        }

        /// <summary>
        /// Test float.Clamp() function
        /// </summary>
        [Test]
        public void ClampFloatTest()
        {
            //True positive
            Assert.AreEqual(0f, 0f.Clamp(-10f, 10f));

            //True max positive
            Assert.AreEqual(10f, 10f.Clamp(-10f, 10f));

            //True min negative
            Assert.AreEqual(-10f, (-10f).Clamp(-10f, 10f));

            //False above min negative
            Assert.AreEqual(-10f, (-11f).Clamp(-10f, 10f));

            //False above max positive
            Assert.AreEqual(10f, 11f.Clamp(-10f, 10f));
        }

        /// <summary>
        /// Test if ClearCurrentScene work well
        /// </summary>
        [UnityTest]
        public IEnumerator ClearCurrentSceneTest()
        {
            GameObject go1 = new GameObject();
            GameObject go2 = new GameObject();
            GameObject go3 = new GameObject();
            GameObject go4 = new GameObject();
            GameObject go5 = new GameObject();

            go2.GetComponent<Transform>().SetParent(go1.GetComponent<Transform>());

            Assert.IsTrue(go1 != null);
            Assert.IsTrue(go2 != null);
            Assert.IsTrue(go3 != null);
            Assert.IsTrue(go4 != null);
            Assert.IsTrue(go5 != null);

            yield return null;

            Utils.ClearCurrentScene();

            yield return null;

            Assert.IsTrue(go1 == null);
            Assert.IsTrue(go2 == null);
            Assert.IsTrue(go3 == null);
            Assert.IsTrue(go4 == null);
            Assert.IsTrue(go5 == null);

            yield return null;

            go1 = new GameObject();
            go2 = new GameObject();
            go3 = new GameObject();
            go4 = new GameObject();
            go5 = new GameObject();

            go2.GetComponent<Transform>().SetParent(go1.GetComponent<Transform>());

            Assert.IsTrue(go1 != null);
            Assert.IsTrue(go2 != null);
            Assert.IsTrue(go3 != null);
            Assert.IsTrue(go4 != null);
            Assert.IsTrue(go5 != null);

            yield return null;

            Utils.ClearCurrentScene(true); // Immediate

            Assert.IsTrue(go1 == null);
            Assert.IsTrue(go2 == null);
            Assert.IsTrue(go3 == null);
            Assert.IsTrue(go4 == null);
            Assert.IsTrue(go5 == null);
        }
    }
}
