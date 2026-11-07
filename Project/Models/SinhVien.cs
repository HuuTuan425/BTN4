using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    ///   lớp mô tả thông tin Sinh Viên
    ///   
    /// a, b : là tên 
    /// c,d : là họ 
    /// </summary>
    public class SinhVien : IComparable<SinhVien>
    {
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string ChuyenNganh { get; set; }

        public SinhVien()
        {
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh,
                        string email, string soDienThoai, string chuyenNganh)
        {
            MaSinhVien = maSinhVien;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            Email = email;
            SoDienThoai = soDienThoai;
            ChuyenNganh = chuyenNganh;
        }

        public int CompareTo(SinhVien other)
        {
            if (other == null)
            {
                return 1;
            }

            string a = FullName.Ten(HoTen);
            string b = FullName.Ten(other.HoTen);
            int ketQua = a.CompareTo(b);

            if (ketQua == 0)
            {
                string c = FullName.Ho(HoTen);
                string d = FullName.Ho(other.HoTen);
                ketQua = c.CompareTo(d);
            }

            return ketQua;
        }
    }
}
