using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorTest;
using NUnit.Framework;
using Calculator;

namespace CalculatorTest
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private StringCalculator sut;

        [SetUp]
        public void SetUp()
        {
            sut = new StringCalculator();
        }
        [Test]
        public void Add_Empty_String_ToCalculator()
        {
            var result = sut.AddNum("");
            Assert.AreEqual(0, result);

        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        public void Add_StringNumbers_ToCalculator(int expected, string num)
        {
            var result = sut.AddNum(num);
            Assert.AreEqual(expected, result);

        }

        [Test]
        [TestCase(3, "1,2")]
        [TestCase(6, "1,2,3")]

        public void unknown_amount_of_numbers(int expected, string num)
        {
            var result = sut.AddNum(num);
            Assert.AreEqual(expected, result);
        }
        [Test]
        [TestCase(6, "1\n2,3")]
        [TestCase(1, "1,\n")]
        public void new_lines_between_numbers(int expected, string num)
        {
            var result = sut.AddNum(num);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(3, "//;\n1;2")]
        public void Support_different_delimiters(int expected, string num)
        {
            var result = sut.AddNum(num);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("1,-2,3")]
        [TestCase("-3")]
        public void negative_number_Exception(string num)
        {
            //var result = sut.AddNum("-2");
            Assert.Throws<ArgumentException>(() =>
            {
                sut.AddNum(num);
            });
        }
    }
}
