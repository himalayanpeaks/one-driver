using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OneDriver.Framework.Module
{
    public interface IDeviceViewModel
    {
        string InitString { get; set; }
        ICommand ConnectCommand { get; }
        ICommand DisconnectCommand { get; }
    }
}
