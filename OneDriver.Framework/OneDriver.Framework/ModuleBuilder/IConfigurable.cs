using OneDriver.Framework.Base;

namespace OneDriver.Framework.ModuleBuilder
{
    public interface IConfigurable<T> where T : IParameter
    {
        public T Parameters { get; set; }
    }
}
