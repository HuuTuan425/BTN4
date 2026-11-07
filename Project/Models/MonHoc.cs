using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models

{
    /// <summary>
    ///  Lớp mô tả thông tin Mon hoc
    /// </summary>
    public class MonHoc
    {
        private static int s_maMonHoc = 11001;
        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public int SoTietHoc { get; set; }
        public MonHoc()
        {

        }
        public MonHoc(string tenMonHoc, int soTinChi, int soTietHoc)
        {
            MaMonHoc = s_maMonHoc++;
            TenMonHoc = tenMonHoc;
            SoTinChi = soTinChi;
            SoTietHoc = soTietHoc;
        }
        public static void upadateMamon(int m)
        {
            s_maMonHoc = m;
        }
        public int CompareTo(MonHoc other)
        {
            if (other == null) return 1;
            return other.SoTinChi.CompareTo(SoTinChi);
        }

    }
}
