using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidationEngine;

namespace ValidationEngineTests
{
    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            var sut = new Validator();

            Assert.IsTrue(sut.ValidateEmailAddress("mike@edument.se"));
            Assert.IsFalse(sut.ValidateEmailAddress("name@test"));
            Assert.IsTrue(sut.ValidateEmailAddress("Name2015@test.com"));
            Assert.IsTrue(sut.ValidateEmailAddress("name@test2015.com"));
        }

        [Test]
        public void MailHasADotBeforeAtReturnTrue()
        {
            var sut = new Validator();
            var r = sut.ValidateEmailAddress("test.test@com");
            Assert.IsFalse(r);
        }
        [Test]
        public void ThrowCustomException()
        {
            var sut = new Validator();
            //sut.ValidateEmailAddress("");
            Assert.Throws<InvalidContentsException>(() => { sut.ValidateEmailAddress(""); });
            //Assert.Fail("Expected exception not thrown");
        }
    }
}
