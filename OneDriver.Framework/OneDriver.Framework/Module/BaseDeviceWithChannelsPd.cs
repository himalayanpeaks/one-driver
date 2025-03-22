using OneDriver.Framework.Base;
using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module.Parameter;
using System.Collections.ObjectModel;

namespace OneDriver.Framework.Module
{
    public abstract class BaseDeviceWithChannelsPd<TDeviceParams, TChannelParams, TChannelProcessData> : BaseDevice<TDeviceParams>
        where TDeviceParams : BaseDeviceParam
        where TChannelParams : BaseChannelParam
        where TChannelProcessData : BaseProcessData

    {
        public BaseDeviceWithChannelsPd(TDeviceParams parameters, IValidator validator, ObservableCollection<BaseChannelWithProcessData<TChannelParams, TChannelProcessData>> elements) : base(parameters, validator)
        {
            Elements = elements;
        }

        public ObservableCollection<BaseChannelWithProcessData<TChannelParams, TChannelProcessData>> Elements { get; set; }
    }
}
