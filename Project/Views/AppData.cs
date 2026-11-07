using System.Collections.Generic;
using Models;

namespace Controllers
{
    public static class AppData
    {
        public static readonly List<SinhVien> SinhViens = new List<SinhVien>();
        public static readonly List<MonHoc> MonHocs = new List<MonHoc>();
        public static readonly List<BanDangKyMonHoc> DangKys = new List<BanDangKyMonHoc>();
    }
}
