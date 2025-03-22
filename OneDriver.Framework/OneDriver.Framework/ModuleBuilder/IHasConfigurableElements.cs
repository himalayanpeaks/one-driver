using OneDriver.Framework.Base;
using System.Collections.ObjectModel;

namespace OneDriver.Framework.ModuleBuilder
{
    public interface IHasConfigurableElements<TParameter>
        where TParameter : IParameter
    {
        ObservableCollection<TParameter> Elements { get; set; }
    }
}
