using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace CharControllerTest {
    public class PlayerInputWeaponChangerTest {
        private ICharController charController;
        private ICharSpellController spellController;
        private IPlayerInputController inputController;
        private PlayerInputWeaponChanger inputWeaponChanger;

        [SetUp]
        public void Init() {
            charController = GetCharControllerMock();
            spellController = GetSpellControllerMock();
            inputController = GetInputControllerMock();

            inputWeaponChanger = new PlayerInputWeaponChanger();
            inputWeaponChanger.SetCharController(charController);
            inputWeaponChanger.SetCharSpellController(spellController);
            inputWeaponChanger.SetPlayerInputController(inputController);
        }

        [Test]
        public void NothingHappensWhenNoKeyIsPressed() {
            inputWeaponChanger.Update();

            charController.Received(0).ChangeWeapon(Arg.Any<Weapon>());
            spellController.Received(0).RequestWeaponChange(Arg.Any<WeaponChangeCallback>());
        }

        [Test]
        public void ChangingToSaiWorksCorrectly() {
            charController.currentWeapon.Returns(Weapon.SCYTHE);
            inputController.GetKeyDown(Keybinding.CHANGE_WEAPON, InputType.SPELL).Returns(true);

            inputWeaponChanger.Update();

            charController.Received(1).ChangeWeapon(Weapon.SAI);
            spellController.Received(0).RequestWeaponChange(Arg.Any<WeaponChangeCallback>());
        }

        [Test]
        public void ChangingToScytheWorksCorrectly() {
            charController.currentWeapon.Returns(Weapon.SAI);
            inputController.GetKeyDown(Keybinding.CHANGE_WEAPON, InputType.SPELL).Returns(true);

            inputWeaponChanger.Update();

            charController.Received(1).ChangeWeapon(Weapon.SCYTHE);
            spellController.Received(0).RequestWeaponChange(Arg.Any<WeaponChangeCallback>());
        }

        [Test]
        public void WeaponChangeInSpellControllerIsRequested() {
            inputController.GetKeyDown(Keybinding.CHANGE_WEAPON, InputType.SPELL).Returns(true);
            spellController.IsCasting.Returns(true);

            inputWeaponChanger.Update();

            charController.Received(0).ChangeWeapon(Arg.Any<Weapon>());
            spellController.Received(1).RequestWeaponChange(Arg.Any<WeaponChangeCallback>());
        }

        private ICharController GetCharControllerMock() {
            return Substitute.For<ICharController>();
        }

        private ICharSpellController GetSpellControllerMock() {
            return Substitute.For<ICharSpellController>();
        }

        private IPlayerInputController GetInputControllerMock() {
            return Substitute.For<IPlayerInputController>();
        }
    }
}
