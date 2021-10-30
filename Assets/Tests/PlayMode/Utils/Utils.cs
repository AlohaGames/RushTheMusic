using NUnit.Framework;
using Aloha;

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
    }
}
