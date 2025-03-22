using static OneDriver.Framework.Module.Definition;

namespace OneDriver.Framework.Module
{
    public interface IDevice
    {
        DeviceError Connect(string initString);
        DeviceError Disconnect();

    }
}
