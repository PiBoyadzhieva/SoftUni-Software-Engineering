using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Opel", "Astra", 6.2, 49.5);
        }

        [Test]
        public void TestIfPrivateCtorWorksCorrectly()
        {
            double expectedFuelAmount = 0;

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            string expectedMake = "Opel";
            string expectedModel = "Astra";
            double expectedFuelConsumption = 6.2;
            double expectedFuelCapacity = 49.5;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenMakeIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("", "Astra", 6.2, 49.5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenMakeIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car(null, "Astra", 6.2, 49.5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenModelIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Opel", "", 6.2, 49.5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenModelIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Opel", null, 6.2, 49.5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenFuelConsumptionIsZero()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Opel", "Astra", 0, 49.5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenFuelConsumptionIsNegative()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Opel", "Astra", -6.9, 49.5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenFuelCapacityIsNegative()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Opel", "Astra", 6.2, -5));
        }

        [Test]
        public void TestIfPropWorksCorrectlyWhenFuelCapacityIsZero()
        {
            Assert.Throws<ArgumentException>(() => this.car = new Car("Opel", "Astra", 6.2, 0));
        }

        [Test]
        public void TestIfRefuelMetodWorksCorrectly()
        {
            double expectedAmount = 20.5;

            this.car.Refuel(20.5);

            Assert.AreEqual(expectedAmount, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void TestIfRefuelMetodWorksCorrectlyWhenAmountIsZeroOrNegative(double fuelToRefuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuelToRefuel));
        }

        [TestCase(55)]
        [TestCase(49.5)]
        [Test]
        public void TestIfRefuelWhenFuelAmountIsMoreThanCapacity(double fuelToRefuel)
        {
            double expectedFuel = 49.5;

            this.car.Refuel(fuelToRefuel);

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestIfDriveMetodWorksCorrectly()
        {
            this.car = new Car("Opel", "Astra", 6, 50);

            this.car.Refuel(50);
            this.car.Drive(100);

            double expectedResult = 44;
            var actualResult = this.car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfDriveMetodWorksCorrectlyWwhenFuelNeededIsMoreThanFuelAmount()
        {
            this.car.Refuel(5);

            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }
    }
}