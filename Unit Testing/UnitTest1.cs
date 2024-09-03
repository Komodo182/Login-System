using Login_System;

namespace Unit_Testing
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestValidationNotEmpty()
        {
            Assert.True(Utils.Validate("anything"));
        }
        [Test]
        public void TestValidationEmpty()
        {
            Assert.False(Utils.Validate(""));
        }
        [Test]
        public void Mario()
        {
            Assert.That(Utils.login("matt,shush"), Is.EqualTo(0));
        }
    }
}