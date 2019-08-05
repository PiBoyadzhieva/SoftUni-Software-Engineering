using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void LoseHealth()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.That(dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void DeadDummy()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(2));
        }

        [Test]
        public void GiveExperience()
        {
            Dummy dummy = new Dummy(0, 10);

            int exp = dummy.GiveExperience();

            Assert.That(exp, Is.EqualTo(10));
        }

        [Test]
        public void CantGiveExperience()
        {
            Dummy dummy = new Dummy(2, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
