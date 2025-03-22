using OneDriver.Framework.Base;
using OneDriver.Framework.Libs;
using OneDriver.Framework.Module;
using OneDriver.Framework.Module.Parameter;
using System.Windows.Input;

public abstract class BaseDeviceViewModel<TParams> : IDeviceViewModel
    where TParams : BaseDeviceParam
{
    private readonly BaseDevice<TParams> _device;

    public string InitString { get; set; } = string.Empty;


    public TParams Parameters => _device.Parameters;

    public ICommand ConnectCommand { get; }
    public ICommand DisconnectCommand { get; }

    protected BaseDeviceViewModel(BaseDevice<TParams> device)
    {
        _device = device;

        ConnectCommand = new RelayCommand(
            execute: _ => Connect(),
            canExecute: _ => !_device.Parameters.IsConnected
        );

        DisconnectCommand = new RelayCommand(
            execute: _ => Disconnect(),
            canExecute: _ => _device.Parameters.IsConnected
        );
    }

    private void Connect() => _device.Connect(InitString);
    private void Disconnect() => _device.Disconnect();
}
