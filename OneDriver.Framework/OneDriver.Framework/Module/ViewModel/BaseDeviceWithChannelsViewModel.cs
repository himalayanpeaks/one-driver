using OneDriver.Framework.ModuleBuilder;
using OneDriver.Framework.Module;
using OneDriver.Framework.Module.Parameter;

namespace OneDriver.Framework.Module.ViewModel
{
    public abstract class BaseDeviceWithChannelsViewModel<TDeviceParams, TChannelParams> : BaseDeviceViewModel<TDeviceParams>
        where TDeviceParams : BaseDeviceParam
        where TChannelParams : BaseChannelParam
    {
        public readonly BaseDeviceWithChannels<TDeviceParams, TChannelParams> Device;

        protected BaseDeviceWithChannelsViewModel(BaseDeviceWithChannels<TDeviceParams, TChannelParams> device) : base(device)
        {
            Device = device;
        }

    }
}
