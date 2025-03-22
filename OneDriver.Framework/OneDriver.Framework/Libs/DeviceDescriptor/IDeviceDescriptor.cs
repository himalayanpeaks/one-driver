using ParameterTool.NSwagClass.Generator.Interface;

namespace OneDriver.Framework.Libs.DeviceDescriptor
{
    public interface IDeviceDescriptor
    {
        public List<ParameterDetailsResponse> ReadData(string server, string hashId, int protocolId);
        public List<ParameterDetailsResponse> ReadData(string server, int deviceId, int protocolId);
    }
}
