using System;
using System.Text.RegularExpressions;

namespace OneDriver.Framework.Libs.Validator
{
    public class IpAddressValidator : IValidator
    {
        // Regex to validate IP address with optional port
        private static readonly Regex _validationRegex = new Regex(
            @"^((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)(:\d{1,5})?$",
            RegexOptions.Compiled
        );

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
            return "192.168.1.1:8080 or 192.168.1.1";
        }
    }
}