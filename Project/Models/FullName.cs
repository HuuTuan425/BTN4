using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FullName
    {
        // lay ten tu fullName

        public static string Ten(string HoTen)
        {
            HoTen = HoTen.Trim();
            int index = HoTen.LastIndexOf(' ');
            return HoTen.Substring(index + 1);

        }
        // lay ho tu full name
        public static string Ho(string HoTen)
        {
            HoTen = HoTen.Trim();
            int index = HoTen.LastIndexOf(' ');
            if(index == -1)
            {
                return HoTen;

            }
            return HoTen.Substring(0, index);
        }
    }
}
