using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException()
            : base("Email không hợp lệ.")
        {
        }

        public InvalidEmailException(string message)
            : base(message)
        {
        }
    }
}
