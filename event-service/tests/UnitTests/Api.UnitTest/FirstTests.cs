using System;
using NUnit.Framework;

namespace Api.UnitTest
{
    [TestFixture]
    public class FirstTests
    {
        [Test]
        public void Dummy_Unit_Test()
        {
            var value = "TEST";
            Assert.IsNotNull(value);
        }
    }
}
