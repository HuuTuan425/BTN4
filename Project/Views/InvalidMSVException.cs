using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class InvalidMSVException : Exception
    {
        public InvalidMSVException()
            : base("Mã sinh viên không hợp lệ.")
        {
        }

        public InvalidMSVException(string message)
            : base(message)
        {
        }
    }
}
