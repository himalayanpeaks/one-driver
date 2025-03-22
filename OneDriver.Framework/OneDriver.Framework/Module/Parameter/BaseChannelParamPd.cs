using OneDriver.Framework.Base;
using OneDriver.Framework.ModuleBuilder;

namespace OneDriver.Framework.Module.Parameter
{
    public class BaseChannelParamPd<TChannelProcessData> : BaseChannelParam, IProcessData<TChannelProcessData>
        where TChannelProcessData : IParameter
    {
        public BaseChannelParamPd(string name, TChannelProcessData processData) : base(name)
        {
            ProcessData = processData;
        }

        public TChannelProcessData ProcessData { get; set; }

    }

}
