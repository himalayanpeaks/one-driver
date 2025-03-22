using OneDriver.Framework.Base;
using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module.Parameter;
using OneDriver.Framework.ModuleBuilder;

namespace OneDriver.Framework.Module
{
    public abstract class BaseDeviceWithProcessData<TParams, TProcessData> : BaseDevice<TParams>, IProcessData<TProcessData>
        where TParams : BaseDeviceParam
        where TProcessData : BaseProcessData
    {
        public TProcessData ProcessData { get; set; }

        public BaseDeviceWithProcessData(TParams deviceParams, IValidator validator, 
            TProcessData processData) : base(deviceParams, validator)
        {
            ProcessData = processData;
        }
    }
}
