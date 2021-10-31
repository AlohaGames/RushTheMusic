using NUnit.Framework;

//TODO: explain your FUNCKING TEST (like youyou in 17-Add-Lancer-Prefab tests of lancer)

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
        /// TODO
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
        /// TODO
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
    }
}
