using OneDriver.Framework.Libs.Validator;
using OneDriver.Framework.Module.Parameter;
using OneDriver.Framework.ModuleBuilder;
using Serilog;
using static OneDriver.Framework.Module.Definition;

namespace OneDriver.Framework.Module
{
    public abstract class BaseDevice<TParams> : IConfigurable<TParams>, IDevice
        where TParams : BaseDeviceParam
    {
        public TParams Parameters { get; set; }

        protected readonly IValidator validator;

        public BaseDevice(TParams parameters, IValidator validator)
        {
            this.validator = validator;
            Parameters = parameters;
        }

        #region AbstractMethods
        protected abstract int OpenConnection(string initString);
        protected abstract int CloseConnection();
        #endregion

        public DeviceError Connect(string initString)
        {
            if (!validator.Validate(initString))
            {
                Log.Error("Invalid init string. Example of valid: " + validator.GetExample());
                return DeviceError.InvalidInitString;
            }
            if (Parameters.IsConnected)
            {
                Log.Error("Device is already connected");
                return DeviceError.AlreadyConnected;
            }
            if (OpenConnection(initString) != 0)
            {
                Log.Error("Error opening connection");
                return DeviceError.ConnectionError;
            }

            Parameters.IsConnected = true;
            return DeviceError.NoError;
        }

        public DeviceError Disconnect()
        {
            if (!Parameters.IsConnected)
            {
                Log.Error("Device is not connected");
                return DeviceError.DisconnectionError;
            }
            if (CloseConnection() != 0)
            {
                Log.Error("Error closing connection");
                return DeviceError.DisconnectionError;
            }
            return DeviceError.NoError;
        }
    }
}
