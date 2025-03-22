using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module.Parameter;
using System.Collections.ObjectModel;

namespace OneDriver.Framework.Module
{
    public abstract class BaseDeviceWithChannels<TDeviceParams, TChannelParams> : BaseDevice<TDeviceParams>
        where TDeviceParams : BaseDeviceParam
        where TChannelParams : BaseChannelParam
    {

        public BaseDeviceWithChannels(TDeviceParams parameters, IValidator validator, ObservableCollection<BaseChannel<TChannelParams>> elements) : base(parameters, validator)
        {
            Elements = elements;
        }

        public ObservableCollection<BaseChannel<TChannelParams>> Elements { get; set; }

    }
}
