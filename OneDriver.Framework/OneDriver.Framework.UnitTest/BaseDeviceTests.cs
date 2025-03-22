using Moq;
using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module.Parameter;
using OneDriver.Framework.Tests;
using static OneDriver.Framework.Module.Definition;

namespace OneDriver.Framework.UnitTest
{
    public class BaseDeviceTests
    {
        private readonly Mock<IValidator> mockValidator;
        private readonly BaseDeviceParam parameters;
        private readonly MockDevice device;

        public BaseDeviceTests()
        {
            mockValidator = new Mock<IValidator>();
            mockValidator.Setup(v => v.Validate(It.IsAny<string>())).Returns(true);
            parameters = new BaseDeviceParam("TestDevice");
            device = new MockDevice(parameters, mockValidator.Object);
        }

        [Fact]
        public void Connect_ValidInitString_ReturnsNoError()
        {
            var result = device.Connect("COM23;19200");

            Assert.Equal(DeviceError.NoError, result);
            Assert.True(parameters.IsConnected);
        }

        [Fact]
        public void Connect_InvalidInitString_ReturnsInvalidInitStringError()
        {
            mockValidator.Setup(v => v.Validate(It.IsAny<string>())).Returns(false);

            var result = device.Connect("InvalidString");

            Assert.Equal(DeviceError.InvalidInitString, result);
            Assert.False(parameters.IsConnected);
        }

        [Fact]
        public void Connect_AlreadyConnected_ReturnsAlreadyConnectedError()
        {
            parameters.IsConnected = true;

            var result = device.Connect("COM23;19200");

            Assert.Equal(DeviceError.AlreadyConnected, result);
        }

        [Fact]
        public void Disconnect_NotConnected_ReturnsDisconnectionError()
        {
            parameters.IsConnected = false;

            var result = device.Disconnect();

            Assert.Equal(DeviceError.DisconnectionError, result);
        }

        [Fact]
        public void Disconnect_Connected_ReturnsNoError()
        {
            parameters.IsConnected = true;

            var result = device.Disconnect();

            Assert.Equal(DeviceError.NoError, result);
            Assert.True(parameters.IsConnected); // State does not auto-change, adjust according to implementation.
        }
    }
}
