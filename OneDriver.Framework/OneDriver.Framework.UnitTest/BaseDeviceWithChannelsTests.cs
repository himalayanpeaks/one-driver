using Moq;
using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module;
using OneDriver.Framework.Module.Parameter;
using System.Collections.ObjectModel;
using static OneDriver.Framework.Module.Definition;

namespace OneDriver.Framework.UnitTest
{
    public class BaseDeviceWithChannelsTests
    {
        private readonly Mock<IValidator> _validatorMock;
        private readonly TestDeviceWithChannels _device;
        private readonly DeviceParamMock _deviceParams;
        private readonly ObservableCollection<BaseChannel<ChannelParamMock>> _channels;

        public BaseDeviceWithChannelsTests()
        {
            _validatorMock = new Mock<IValidator>();
            _validatorMock.Setup(v => v.Validate(It.IsAny<string>())).Returns(true);

            _deviceParams = new DeviceParamMock("TestDevice");

            _channels = new ObservableCollection<BaseChannel<ChannelParamMock>>
            {
                new BaseChannel<ChannelParamMock>(new ChannelParamMock("Channel1")),
                new BaseChannel<ChannelParamMock>(new ChannelParamMock("Channel2"))
            };

            _device = new TestDeviceWithChannels(_deviceParams, _validatorMock.Object, _channels);
        }

        [Fact]
        public void Connect_ShouldSetIsConnected_WhenValidatorPasses()
        {
            var result = _device.Connect("ValidInitString");

            Assert.Equal(DeviceError.NoError, result);
            Assert.True(_device.Parameters.IsConnected);
        }

        [Fact]
        public void Disconnect_ShouldUnsetIsConnected()
        {
            _device.Parameters.IsConnected = true;
            var result = _device.Disconnect();

            Assert.Equal(DeviceError.NoError, result);
            Assert.False(_device.Parameters.IsConnected);
        }

        [Fact]
        public void Elements_ShouldBeInitializedCorrectly()
        {
            Assert.Equal(2, _device.Elements.Count);
            Assert.Equal("Channel1", _device.Elements[0].Parameters.Name);
            Assert.Equal("Channel2", _device.Elements[1].Parameters.Name);
        }

        [Fact]
        public void AddChannel_ShouldIncreaseChannelCount()
        {
            _device.Elements.Add(item: new OneDriver.Framework.Module.Parameter.BaseChannel<ChannelParamMock>(new ChannelParamMock("Channel3")));

            Assert.Equal(3, _device.Elements.Count);
            Assert.Equal("Channel3", _device.Elements[2].Parameters.Name);
        }

        [Fact]
        public void RemoveChannel_ShouldDecreaseChannelCount()
        {
            _device.Elements.RemoveAt(0);

            Assert.Single(_device.Elements);
            Assert.Equal("Channel2", _device.Elements[0].Parameters.Name);
        }

        private class TestDeviceWithChannels : BaseDeviceWithChannels<DeviceParamMock, ChannelParamMock>
        {
            public TestDeviceWithChannels(DeviceParamMock parameters, IValidator validator, ObservableCollection<BaseChannel<ChannelParamMock>> elements)
                : base(parameters, validator, elements) { }

            protected override int OpenConnection(string initString)
            {
                return 0;
            }

            protected override int CloseConnection()
            {
                Parameters.IsConnected = false;
                return 0;
            }
        }

        private class DeviceParamMock : BaseDeviceParam
        {
            public DeviceParamMock(string name) : base(name) { }
        }

        private class ChannelParamMock : BaseChannelParam
        {
            public ChannelParamMock(string name) : base(name) { }
        }
    }
}
