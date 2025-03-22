using OneDriver.Framework.Base;
using OneDriver.Framework.ModuleBuilder;

namespace OneDriver.Framework.Module.Parameter
{
    public class BaseChannel<TChannelParam> : PropertyHandlers, IConfigurable<TChannelParam>
            where TChannelParam : BaseChannelParam
    {
        public TChannelParam Parameters { get; set; }

        public BaseChannel(TChannelParam parameters)
        {
            Parameters = parameters;
        }
    }
}
