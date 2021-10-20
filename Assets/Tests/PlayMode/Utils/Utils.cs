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
    }
}
