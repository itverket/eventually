using System;
using Api.Controllers;
using NUnit.Framework;

namespace Api.UnitTest
{
    [TestFixture]
    public class FirstTests
    {
        [Test]
        public void ValuesRepo_Should_Return_Values()
        {
            var value = ValuesRepo.Values[1];
            Assert.IsNotNull(value);
        }
    }
}
