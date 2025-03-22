using OneDriver.Framework.Base;

namespace OneDriver.Framework.ModuleBuilder
{
    public interface IProcessData<T> where T : IParameter
    {
        public T ProcessData { get; set; }
    }
}
