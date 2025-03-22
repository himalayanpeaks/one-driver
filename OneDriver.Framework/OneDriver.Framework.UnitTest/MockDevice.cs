using Xunit;
using Moq;
using OneDriver.Framework.Module;
using OneDriver.Framework.Module.Parameter;
using OneDriver.Framework.Libs.Validator;
using static OneDriver.Framework.Module.Definition;

namespace OneDriver.Framework.Tests
{
    public class MockDevice : BaseDevice<BaseDeviceParam>
    {
        public MockDevice(BaseDeviceParam parameters, IValidator validator)
            : base(parameters, validator)
        {
        }

        protected override int OpenConnection(string initString)
        {
            return initString == "COM23;19200" ? 0 : -1;
        }

        protected override int CloseConnection()
        {
            return 0;
        }
    }
}