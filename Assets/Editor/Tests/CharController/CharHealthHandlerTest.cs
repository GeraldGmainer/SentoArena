using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace CharControllerTest {
    public class CharHealthHandlerTest {
        private const float START_HEALTH = 100;

        private ICharController charController;
        private CharHealthHandler charHealthHandler;

        [SetUp]
        public void Init() {
            charController = GetCharControllerMock();
            charHealthHandler = new CharHealthHandler(charController, START_HEALTH);
            charHealthHandler.Start();
        }

        [Test]
        public void HealthIsSetOnStart() {
            Assert.AreEqual(START_HEALTH, charHealthHandler.Health);
        }

        [Test]
        public void ControllerHealthIsCalledOnStart() {
            charController.Received(1).OnHealthUpdate();
        }

        [Test]
        public void HealthIsCalculatedCorrectlyOnDamageReceive() {
            charHealthHandler.ReceiveDamage(new SpellDamage(45, Vector3.forward));

            Assert.AreEqual(55, charHealthHandler.Health);
        }

        [Test]
        public void ControllerHealthIsCalledOnDamageReceive() {
            charHealthHandler.ReceiveDamage(new SpellDamage(45, Vector3.forward));

            charController.Received(2).OnHealthUpdate();
        }

        [Test]
        public void ControllerDeathIsCalledOnDamageReceive() {
            SpellDamage spellDamage = new SpellDamage(100, Vector3.forward);
            charHealthHandler.ReceiveDamage(spellDamage);

            charController.Received(1).OnDeath(spellDamage);
        }

        [Test]
        public void HealthIsClampedToZero() {
            charHealthHandler.ReceiveDamage(new SpellDamage(110, Vector3.forward));

            Assert.AreEqual(0, charHealthHandler.Health);
        }

        private ICharController GetCharControllerMock() {
            return Substitute.For<ICharController>();
        }
    }
}
