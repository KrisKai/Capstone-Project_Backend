using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.Helpers.Exceptions
{
    public class InsertException:Exception
    {
        public InsertException() : base() { }
        public InsertException(string message) : base(message) { }

        public InsertException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
