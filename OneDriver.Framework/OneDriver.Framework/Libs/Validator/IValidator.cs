using System.Text.RegularExpressions;

namespace OneDriver.Framework.Libs.Validator
{
    public interface IValidator
    {
        Regex ValidationRegex { get; }
        bool Validate(string inputString);
        string GetExample();
    }
}
