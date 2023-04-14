using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException() : base() { }
        public ValidateException(string message) : base(message) { }

        public ValidateException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
