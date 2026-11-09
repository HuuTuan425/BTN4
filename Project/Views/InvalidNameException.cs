using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException()
            : base("Họ tên không hợp lệ.")
        {
        }

        public InvalidNameException(string message)
            : base(message)
        {
        }
    }
}
