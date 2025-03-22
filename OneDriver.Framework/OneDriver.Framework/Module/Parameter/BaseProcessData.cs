using OneDriver.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OneDriver.Framework.Module.Parameter
{
    public class BaseProcessData : PropertyHandlers, IParameter
    {
        private DateTime timeStamp;

        public DateTime TimeStamp { get => GetProperty(ref timeStamp); set => SetProperty(ref timeStamp, value); }
    }
}
