using System.ComponentModel;
using OneDriver.Framework.Libs.Validator;

namespace OneDriver.Framework.Module
{
    public enum ConnectionError
    {
        [Description("No error occurred.")]
        NoError,

        [Description("Access to the resource was denied.")]
        AccessDenied,

        [Description("The connection is already open.")]
        AlreadyOpened,

        [Description("The provided name for the connection is invalid.")]
        InvalidName,

        [Description("A communication error occurred.")]
        CommunicationError,

        [Description("An error occurred while trying to disconnect.")]
        ErrorInDisconnecting,

        [Description("Unauthorized access.")]
        UnauthorizedAccess,

        [Description("An I/O error occurred.")]
        IOError,

        [Description("Invalid operation.")]
        InvalidOperation,

        [Description("An unknown error occurred.")]
        UnknownError
    }

    public interface IConnectionWithInitString
    {
        ConnectionError Open(string initString, IValidator validator);
        ConnectionError Close();
    }
    public interface IByteReader
    {
        byte[] Read();
    }

    public interface IByteWriter
    {
        void Write(byte[] data);
    }

    public interface IStringReader
    {
        Definition.DeviceError Read(out string readData);
    }

    public interface IStringWriter
    {
        Definition.DeviceError Write(string data);
    }
}
