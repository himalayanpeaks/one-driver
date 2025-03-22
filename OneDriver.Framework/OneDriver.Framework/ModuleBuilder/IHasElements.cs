using OneDriver.Framework.Base;
using System.Collections.ObjectModel;

namespace OneDriver.Framework.ModuleBuilder
{
    internal interface IHasElements<T> where T : IParameter
    {
        public ObservableCollection<T> Elements { get; set; }
    }
}
