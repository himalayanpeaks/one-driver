using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDriver.Framework.Base
{
    public delegate void PropertyReadRequestedEventHandler(object sender, PropertyReadRequestedEventArgs e);
    /// <summary>
    /// Event arguments to be passed whe property read is requested
    /// </summary>
    public sealed class PropertyReadRequestedEventArgs : EventArgs
    {
        public PropertyReadRequestedEventArgs(string propertyName) => PropertyName = propertyName;

        public string PropertyName { get; }
        public object Value { get; set; }

        public object GetValue()
        {
            return Value;
        }
    }
}
