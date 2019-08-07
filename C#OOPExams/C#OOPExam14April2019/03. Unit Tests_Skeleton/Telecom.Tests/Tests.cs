namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("Samsung", "A5");

        }

        [Test]
        public void TestIfMakePropertyWorksCorrectly()
        {
            string expectedMake = "Samsung";

            Assert.AreEqual(expectedMake, this.phone.Make);
        }

        [Test]
        public void TestIfMakePropertyWorksCorrectlyWhenMakeIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.phone = new Phone("", "A5"));
        }

        [Test]
        public void TestIfMakePropertyWorksCorrectlyWhenMakeIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.phone = new Phone(null, "A5"));
        }

        [Test]
        public void TestIfModelPropertyWorksCorrectly()
        {
            string expectedModel = "A5";

            Assert.AreEqual(expectedModel, this.phone.Model);
        }

        [TestCase("")]
        [TestCase(null)]
        [Test]
        public void TestIfModelPropertyThrowsCorrectExeption(string model)
        {
            Assert.Throws<ArgumentException>(() => this.phone = new Phone("Samsung", model));
        }

        [Test]
        public void TestIfAddingWorkingCorrectly()
        {
            this.phone.AddContact("Ivan", "0888353535");

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestIfAddingWorkingCorrectlyWhenNameAlreadyExist()
        {
            this.phone.AddContact("Ivan", "0888353535");
            this.phone.AddContact("Maria", "0888363636");

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Ivan", "0888373737"));
        }

        [Test]
        public void TestIfCallMetodWorkingCorrectly()
        {
            this.phone.AddContact("Ivan", "0888353535");
            this.phone.AddContact("Maria", "0888363636");

            string actualResult = this.phone.Call("Maria");

            string expectedResult = "Calling Maria - 0888363636...";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfCallMetodThrowsRightExceptionWhenNameDoesNotExist()
        {
            this.phone.AddContact("Ivan", "0888353535");
            this.phone.AddContact("Maria", "0888363636");

            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Petyr"));
        }
    }
}