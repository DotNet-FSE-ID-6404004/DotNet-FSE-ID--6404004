using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [TearDown]
        public void Teardown()
        {
            calc = null;
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(10, 5, 15)]
        public void Add_GivenTwoNumbers_ReturnsSum(int a, int b, int expected)
        {
            var result = calc.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test, Ignore("Skipping this test")]
        public void SkippedTest()
        {
            Assert.Fail("This test is skipped.");
        }
    }
}
