using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException() : base() { }
        public UserAlreadyExistException(string message) : base(message) { }

        public UserAlreadyExistException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
