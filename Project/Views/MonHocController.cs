using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class MonHocController
    {
        public List<MonHoc> GetAll() { return AppData.MonHocs.ToList(); }

        public bool Them(string tenMonHoc, int soTinChi, int soTietHoc, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(tenMonHoc)) { error = "Tên môn học không được để trống."; return false; }
            if (soTinChi <= 0 || soTietHoc <= 0) { error = "Số tín chỉ và số tiết học phải lớn hơn 0."; return false; }
            AppData.MonHocs.Add(new MonHoc(tenMonHoc.Trim(), soTinChi, soTietHoc));
            return true;
        }

        public bool SuaSoTiet(int maMonHoc, int soTietHoc, out string error)
        {
            error = string.Empty;
            MonHoc monHoc = TimTheoMa(maMonHoc);
            if (monHoc == null) { error = "Không tìm thấy môn học theo mã đã nhập."; return false; }
            if (soTietHoc <= 0) { error = "Số tiết học phải lớn hơn 0."; return false; }
            monHoc.SoTietHoc = soTietHoc;
            return true;
        }

        public bool Xoa(int maMonHoc, out string error)
        {
            error = string.Empty;
            MonHoc monHoc = TimTheoMa(maMonHoc);
            if (monHoc == null) { error = "Không tìm thấy môn học cần xóa."; return false; }
            AppData.MonHocs.Remove(monHoc);
            AppData.DangKys.RemoveAll(x => x.MonHoc == monHoc);
            return true;
        }

        public List<MonHoc> TimGanDung(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten)) return GetAll();
            return AppData.MonHocs.Where(x => x.TenMonHoc.IndexOf(ten.Trim(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<MonHoc> SapXepTheoTinChi()
        {
            return AppData.MonHocs.OrderByDescending(x => x.SoTinChi).ToList();
        }

        public MonHoc TimTheoMa(int maMonHoc)
        {
            return AppData.MonHocs.FirstOrDefault(x => x.MaMonHoc == maMonHoc);
        }

        public List<MonHoc> TimDangKyNhieuNhat()
        {
            if (AppData.MonHocs.Count == 0) return new List<MonHoc>();
            int max = AppData.MonHocs.Max(mh => AppData.DangKys.Count(dk => dk.MonHoc == mh));
            return AppData.MonHocs.Where(mh => AppData.DangKys.Count(dk => dk.MonHoc == mh) == max).ToList();
        }
    }
}
