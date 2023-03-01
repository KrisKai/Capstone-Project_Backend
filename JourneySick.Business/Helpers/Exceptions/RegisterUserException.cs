using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers.Exceptions
{
    public class RegisterUserException : Exception
    {
        public RegisterUserException() : base() { }
        public RegisterUserException(string message) : base(message) { }

        public RegisterUserException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
