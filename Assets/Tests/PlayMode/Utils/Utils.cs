using NUnit.Framework;

namespace Aloha.Test
{
    public class UtilsTest
    {
        [Test]
        public void EqualFloatTest()
        {
            //True
            Assert.IsTrue(Utils.EqualFloat(3.2254346f, 3.22f));

            //False
            Assert.IsTrue(Utils.EqualFloat(3.219453f, 3.2254655f));

            //Epsilon True
            Assert.IsTrue(Utils.EqualFloat(3.213f, 3.213468484f, 0.001f));

            //Epsilon False
            Assert.IsTrue(Utils.EqualFloat(3.2139484548f, 3.21456226685f));
        }

        [Test]
        public void InRangeIntTest()
        {
            //True positive
            Assert.AreEqual(0, Utils.InRangeInt(-10, 10, 0));

            //True max positive
            Assert.AreEqual(10, Utils.InRangeInt(-10, 10, 10));

            //True min negative
            Assert.AreEqual(-10, Utils.InRangeInt(-10, 10, -10));

            //False above min negative
            Assert.AreEqual(-10, Utils.InRangeInt(-10, 10, -11));

            //False above max positive
            Assert.AreEqual(10, Utils.InRangeInt(-10, 10, 11));
        }

        [Test]
        public void InRangeFloatTest()
        {
            //True positive
            Assert.AreEqual(0f, Utils.InRangeFloat(-10f, 10f, 0f));

            //True max positive
            Assert.AreEqual(10f, Utils.InRangeFloat(-10f, 10f, 10f));

            //True min negative
            Assert.AreEqual(-10f, Utils.InRangeFloat(-10f, 10f, -10f));

            //False above min negative
            Assert.AreEqual(-10f, Utils.InRangeFloat(-10f, 10f, -11f));

            //False above max positive
            Assert.AreEqual(10f, Utils.InRangeFloat(-10f, 10f, 11f));
        }
    }

}
