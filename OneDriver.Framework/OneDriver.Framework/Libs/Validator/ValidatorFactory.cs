using OneDriver.Framework.Libs.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDriver.Framework.Libs.Validator
{
    public static class ValidatorFactory
    {
        public static IValidator CreateValidator(string validatorType)
        {
            switch (validatorType)
            {
                case "Comport":
                    return new ComportValidator();
                case "IPAddress":
                    return new IpAddressValidator();
                default:
                    throw new ArgumentException("Invalid validator type");
            }
        }
    }
}
