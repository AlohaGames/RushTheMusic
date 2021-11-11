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
        public void RandomIntTest()
        {
            //True
            int randomInt = Utils.RandomInt(0, 1);

            // Test if random number is between min and max
            Assert.GreaterOrEqual(randomInt, 0);
            Assert.LessOrEqual(randomInt, 1);

            int randomInt2 = Utils.RandomInt(0, 1);

            // Test if the second random number is between min and max
            Assert.GreaterOrEqual(randomInt2, 0);
            Assert.LessOrEqual(randomInt2, 1);

        }

        [Test]
        public void RandomFloatTest()
        {
            //True
            float randomFloat = Utils.RandomFloat(0, 1);

            // Test if random number is between min and max
            Assert.GreaterOrEqual(randomFloat, 0);
            Assert.LessOrEqual(randomFloat, 1);

            float randomFloat2 = Utils.RandomFloat(0, 1);

            // Test if the second random number is between min and max
            Assert.GreaterOrEqual(randomFloat2, 0);
            Assert.LessOrEqual(randomFloat2, 1);

        }

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
