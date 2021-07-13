using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commons.Exceptions
{
    public class ValidateException : Exception
    {
        public ValidateException(string msg, object data = null) : base(msg)
        {
            var objectReturn = new
            {
                Msg = msg,
                FiledNotValid = data
            };
            this.Data.Add("1", objectReturn);

        }
    }
}
