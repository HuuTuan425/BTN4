using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    ///  Lớp mô tả  thông tin của ban dang ký 
    /// </summary>
    public class BanDangKyMonHoc : IComparable<BanDangKyMonHoc>
    {
        private static int s_maBanDangKy = 10000;

        public int MaBanDangKy { get; set; }
        public SinhVien SinhVien { get; set; }
        public MonHoc MonHoc { get; set; }
        public DateTime ThoiGianDangKy { get; set; }

        public BanDangKyMonHoc()
        {
        }

        public BanDangKyMonHoc(SinhVien sinhVien, MonHoc monHoc)
        {
            MaBanDangKy = s_maBanDangKy++;
            SinhVien = sinhVien;
            MonHoc = monHoc;
            ThoiGianDangKy = DateTime.Now;    
        }
       

        public int CompareTo(BanDangKyMonHoc other)
        {
            if (other == null) {
                return 1;
             }
            return ThoiGianDangKy.CompareTo(other.ThoiGianDangKy);
        }
        public static int SoSanhTheoMaSV(BanDangKyMonHoc a, BanDangKyMonHoc b)
        {
            return a.SinhVien.MaSinhVien.CompareTo(b.SinhVien.MaSinhVien);
        }
        public static int SoSanhTheoMaMon(BanDangKyMonHoc a, BanDangKyMonHoc b)
        {
            return a.MonHoc.MaMonHoc.CompareTo(b.MonHoc.MaMonHoc);
        }
    }
}
