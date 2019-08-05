//using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            var persons = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(2, "Gosho"),
                new Person(3, "Ivan"),
                new Person(4, "Misho"),
                new Person(5, "Anton"),
            };

            this.database = new ExtendedDatabase(persons);
        }

        [Test]
        public void TestIfDatabaseConstructorWorksCorrectly()
        {
            int expectedCount = 5;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void TestIfDatabaseAddingWorkCorrectly()
        {
            Person person = new Person(6, "Marin");

            this.database.Add(person);
            int expectedCount = 6;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TesttIfDatabaseAddMethodWhenCapacityFull()
        {
            Person[] people = new Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Name:{i}");
            }

            this.database = new ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(17, "Number17"));
            });
        }

        [Test]
        public void TestIfDatabaseAddMethodWoksCorrectlyWhenAddingExistingName()
        {
            Person person = new Person(6, "Gosho");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);
            });
        }

        [Test]
        public void TestIfDatabaseAddMethodWoksCorrectlyWhenAddingExistingId()
        {
            Person person = new Person(5, "Marin");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(person);
            });
        }

        [Test]
        public void TestIfDatabaseRemoveMethodWorksCorrectly()
        {
            this.database.Remove();

            int expectedCount = 4;

            Assert.AreEqual(expectedCount, this.database.Count);
        }

        [Test]
        public void TestIfDatabaseRemoveMethodWorksCorrectlyWhenIsEmpty()
        {
            var database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestIfDatabaseFindByUsernameMethodWorksCorrectly()
        {
            string expectedResult = "Pesho";

            string actualResult = this.database.FindByUsername("Pesho").UserName;

            Assert.AreEqual(expectedResult, actualResult);

            // or with bool Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestIfDatabaseFindByUsernameMethodWorksCorrectlyWhenNameIsEmpty()
        {
            string username = "";

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(username));
        }

        [Test]
        public void TestIfDatabaseFindByUsernameMethodWorksCorrectlyWhenNameIsNull()
        {
            string username = null;

            Assert.Throws<ArgumentNullException>(() => this.database.FindByUsername(username));
        }

        [Test]
        public void TestIfDatabaseFindByUsernameMethodWorksCorrectlyWhenNameNotFount()
        {
            string username = "Marin";

            Assert.Throws<InvalidOperationException>(() => this.database.FindByUsername(username));
        }

        [Test]
        public void TestIfDatabaseFindByIdMethodWorksCorrectly()
        {
            string expectedResult = "Gosho";

            string actualResult = this.database.FindById(2).UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestIfDatabaseFindByIdMethodWorksCorerectlyWhenIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(-1);
            });
        }

        [Test]
        public void TestIfDatabaseFindByIdMethodWorksCorerectlyWhenIdNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(25);
            });
        }
    }
}