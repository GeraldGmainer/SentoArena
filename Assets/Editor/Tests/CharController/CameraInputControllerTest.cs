using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace InputTest {
    public class CameraInputControllerTest {
        private const float MOUSE_SENSITIVITY = 8;

        private IPlayerInputController playerInputController;
        private CameraInputController cameraInputController;

        [SetUp]
        public void Init() {
            playerInputController = GetPlayerInputControllerMock();

            cameraInputController = new CameraInputController();
            cameraInputController.SetInputController(playerInputController);
            cameraInputController.SetMouseSensitivity(MOUSE_SENSITIVITY);

            playerInputController.IsMouseYEnabled.Returns(true);
            playerInputController.IsCameraScrollEnabled.Returns(true);
        }

        [Test]
        public void DefaultCameraPositionIsLoadedCorrectly() {
            cameraInputController.Update();

            Assert.AreEqual(PlayerCamera.START_MOUSE_Y, cameraInputController.MouseYSmooth);
            Assert.AreEqual(PlayerCamera.START_SCROLL, cameraInputController.MouseScrollDesired);
            Assert.AreEqual(PlayerCamera.START_SCROLL, cameraInputController.MouseScrollSmooth);
        }

        [Test]
        public void MouseScrollDesiredIsClampedToMin() {
            playerInputController.MouseScroll.Returns(1000);
            cameraInputController.Update();

            Assert.AreEqual(PlayerCamera.MIN_SCROLL_DISTANCE, cameraInputController.MouseScrollDesired);
        }

        [Test]
        public void MouseScrollDesiredIsClampedToMax() {
            playerInputController.MouseScroll.Returns(-1000);
            cameraInputController.Update();

            Assert.AreEqual(PlayerCamera.MAX_SCROLL_DISTANCE, cameraInputController.MouseScrollDesired);
        }

        [Test]
        public void MouseScrollDesiredIsCalculatedCorrectly() {
            playerInputController.MouseScroll.Returns(-1);
            cameraInputController.Update();

            Assert.AreEqual(PlayerCamera.START_SCROLL + PlayerCamera.SCROLL_SENSITIVITY, cameraInputController.MouseScrollDesired);
        }

        [Test]
        public void MouseScrollDesiredIsNotChangedWhenDisabled() {
            playerInputController.IsCameraScrollEnabled.Returns(false);
            playerInputController.MouseScroll.Returns(100);
            cameraInputController.Update();

            Assert.AreEqual(PlayerCamera.START_SCROLL, cameraInputController.MouseScrollDesired);
        }

        private IPlayerInputController GetPlayerInputControllerMock() {
            return Substitute.For<IPlayerInputController>();
        }
    }
}
