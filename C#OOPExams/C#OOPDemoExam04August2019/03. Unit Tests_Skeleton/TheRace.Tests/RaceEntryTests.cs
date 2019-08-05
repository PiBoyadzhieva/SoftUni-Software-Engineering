using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestIfAddMetodWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 90, 300);
            UnitRider rider = new UnitRider("Ivan", unitMotorcycle);

            string resultMsg = raceEntry.AddRider(rider);

            string expectedMsg = "Rider Ivan added in race.";

            Assert.AreEqual(resultMsg, expectedMsg);
        }
        [Test]
        public void ifCountWorksCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 90, 300);
            UnitRider rider = new UnitRider("Ivan", unitMotorcycle);

            raceEntry.AddRider(rider);

            Assert.AreEqual(raceEntry.Counter, 1);
        }
        [Test]
        public void TestIfAddMetodWorksCorrectlyWhenRiderIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();

            string expectedMsg = "Rider cannot be null.";

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(null));

            Assert.AreEqual(expectedMsg, exception.Message);
        }
        [Test]
        public void TestIfAddMetodWorksCorrectlyWhenRiderAlreadyExist()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Honda", 90, 300);
            UnitRider rider = new UnitRider("Ivan", unitMotorcycle);

            raceEntry.AddRider(rider);

           string expectedMsg = "Rider Ivan is already added.";

            var exception = Assert.Throws<InvalidOperationException>(() => raceEntry.AddRider(rider));

            Assert.AreEqual(expectedMsg, exception.Message);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnAverageHorsePower()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Honda", 90, 300);
            UnitRider rider1 = new UnitRider("Ivan", unitMotorcycle1);

            UnitMotorcycle unitMotorcycle2 = new UnitMotorcycle("Yamaha", 80, 260);
            UnitRider rider2 = new UnitRider("Pesho", unitMotorcycle2);

            UnitMotorcycle unitMotorcycle3 = new UnitMotorcycle("Kawasaki", 70, 280);
            UnitRider rider3 = new UnitRider("Gosho", unitMotorcycle3);

            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);
            raceEntry.AddRider(rider3);

            double expectedResult = 80;
            double actualResult = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldReturnAverageHorsePowerCorrectException()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Honda", 90, 300);
            UnitRider rider1 = new UnitRider("Ivan", unitMotorcycle1);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

    }
}