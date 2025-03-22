using System;
using System.Text.RegularExpressions;

namespace OneDriver.Framework.Libs.Validator
{
    public class ComportValidator : IValidator
    {
        private static readonly Regex _validationRegex = new Regex(@"^(COM\d+){1};?(\d+)?$", RegexOptions.Compiled);
        public Regex ValidationRegex => _validationRegex;

        public bool Validate(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }

            return _validationRegex.IsMatch(inputString);
        }
        public string GetExample()
        {
            return "COM23;19200";
        }
    }
}
