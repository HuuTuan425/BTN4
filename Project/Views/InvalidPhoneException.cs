using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class InvalidPhoneException : Exception
    {
        public InvalidPhoneException()
            : base("Số điện thoại không hợp lệ.")
        {
        }

        public InvalidPhoneException(string message)
            : base(message)
        {
        }
    }
}
