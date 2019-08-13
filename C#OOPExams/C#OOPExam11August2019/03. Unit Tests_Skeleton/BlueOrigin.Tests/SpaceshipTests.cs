namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SpaceshipTests
    {
        [Test]
        public void TestIfCtorWorksCorectly()
        {
            Spaceship spaceship = new Spaceship("Apolo", 10);

            string expectedName = "Apolo";
            string actualResult = spaceship.Name;

            Assert.AreEqual(expectedName, actualResult);
        }

        [Test]
        public void TestIfNameIsEmpy()
        {
            string expectedMsg = "Invalid spaceship name!\r\nParameter name: value";

            var exception = Assert.Throws<ArgumentNullException>(() => new Spaceship("", 10));

            Assert.AreEqual(expectedMsg, exception.Message);
        }
        [Test]
        public void TestIfNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, 10));

        }

        [Test]
        public void TestIfCapacityWorksCorectly()
        {
            Spaceship spaceship = new Spaceship("Apolo", 10);

            int expectedResult = 10;
            int actualResult = spaceship.Capacity;

            Assert.AreEqual(expectedResult, actualResult);

        }
        [Test]
        public void TestIfCapacityWorksCorectlyWhenIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Apolo", -1));
        }

        [Test]
        public void TestIfCountWorksCorrectly()
        {
            Spaceship spaceship = new Spaceship("Apolo", 10);
            Astronaut astronaut = new Astronaut("Georgi", 2.5);

            spaceship.Add(astronaut);

            int expectedCount = 1;
            int actualCount = spaceship.Count;

            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void TestIfAddWorksCorrectlyWhenCapacityIsFull()
        {
            Spaceship spaceship = new Spaceship("Apolo", 1);
            Astronaut astronaut = new Astronaut("Georgi", 2.5);
            Astronaut astronaut1 = new Astronaut("Ivan", 3.2);

            spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut1));
        }

        [Test]
        public void TestIfAddWorksCorrectlyWhenAstronautAlreadyExist()
        {
            Spaceship spaceship = new Spaceship("Apolo", 3);
            Astronaut astronaut = new Astronaut("Georgi", 2.5);
            Astronaut astronaut1 = new Astronaut("Georgi", 3.2);

            spaceship.Add(astronaut);

            var expectedMsg = "Astronaut Georgi is already in!";

            var exception = Assert.Throws<InvalidOperationException>(() => spaceship.Add(astronaut1));

            Assert.AreEqual(expectedMsg, exception.Message);
        }

        [Test]
        public void TestIfRemoveMetodWorksCorrectly()
        {
            Spaceship spaceship = new Spaceship("Apolo", 5);

            Astronaut astronaut = new Astronaut("Georgi", 2.5);
            Astronaut astronaut1 = new Astronaut("Ivan", 3.2);

            spaceship.Add(astronaut);
            spaceship.Add(astronaut1);

            spaceship.Remove(astronaut.Name);

            int expectedResult = 1;
            int actualResult = spaceship.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TestIfRemoveMetodWorksCorrectlyCheckIfOutputMessageAreRight()
        {
            Spaceship spaceship = new Spaceship("Apolo", 5);

            Astronaut astronaut = new Astronaut("Georgi", 2.5);
            Astronaut astronaut1 = new Astronaut("Ivan", 3.2);

            spaceship.Add(astronaut);
            spaceship.Add(astronaut1);

            Assert.AreEqual(true, spaceship.Remove(astronaut.Name));
        }

    }
}