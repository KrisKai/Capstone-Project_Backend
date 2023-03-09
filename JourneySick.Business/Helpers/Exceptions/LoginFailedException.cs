using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base() { }
        public LoginFailedException(string message) : base(message) { }

        public LoginFailedException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
