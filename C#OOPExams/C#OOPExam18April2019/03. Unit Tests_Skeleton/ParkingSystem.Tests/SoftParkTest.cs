namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestIfParkCarMetodWorksCorrectly()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");

            var actualResult = softPark.ParkCar("A3", car);

            var expectedResult = "Car:B2560 parked successfully!";

            Assert.AreEqual(expectedResult, actualResult);
            //Assert.That(actualResult, Is.EqualTo(expectedResult)); -> Anorher way
        }

        [Test]
        public void TestIfParkCarThrowsCorrectExceptionWhenParkingSpotDoesNotExist()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A6", car));
        }

        [Test]
        public void TestIfParkCarThrowsCorrectExceptionWhenParkingSpotDoesNotNull()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");
            softPark.ParkCar("A2", car);

            Assert.Throws<ArgumentException>(() => softPark.ParkCar("A2", new Car("Toyota", "C6565")));
        }

        [Test]
        public void TestIfParkCarThrowsCorrectExceptionWhenCarIsAlreadyExist()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");
            softPark.ParkCar("A2", car);

            Assert.Throws<InvalidOperationException>(() => softPark.ParkCar("B1", car));
        }

        [Test]
        public void TestIfRemoveMetodWorksCorrectly()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");

            softPark.ParkCar("A2", car);

            var actualResult = softPark.RemoveCar("A2", car);
            var expectedResult = $"Remove car:B2560 successfully!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfRemoveMetodThrowsCorrectExceptionWhenParkSpotDoesNotExist()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");

            softPark.ParkCar("A2", car);

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("B1", car));
        }

        [Test]
        public void TestIfRemoveMetodThrowsCorrectExceptionWhenCarForThatSpotNotExist()
        {
            SoftPark softPark = new SoftPark();
            Car car = new Car("Opel", "B2560");
            Car car2 = new Car("Toyota", "C6565");

            softPark.ParkCar("A2", car);
            softPark.ParkCar("B1", car2);

            Assert.Throws<ArgumentException>(() => softPark.RemoveCar("B1", car));
        }

        [Test]
        public void TestIfCtorShouldInitializeAllParkingSpot()
        {
            SoftPark softPark = new SoftPark();

            int expectedCount = 12;

            Assert.AreEqual(expectedCount, softPark.Parking.Count);
        }
    }
}