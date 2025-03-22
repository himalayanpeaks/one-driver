using OneDriver.Framework.Base;

namespace OneDriver.Framework.Module.Parameter
{
    public class BaseDeviceParam : PropertyHandlers, IParameter
    {
        private string name;

        public BaseDeviceParam(string name)
        {
            this.name = name;
        }

        private bool isConnected;

        public string Name { get => GetProperty(ref name); set => SetProperty(ref name, value); }
        public bool IsConnected { get => GetProperty(ref isConnected); set => SetProperty(ref isConnected, value); }
    }
}
