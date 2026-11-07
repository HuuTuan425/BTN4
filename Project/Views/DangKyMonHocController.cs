using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class DangKyDisplay
    {
        public int MaDangKy { get; set; }
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public int MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public DateTime ThoiGianDangKy { get; set; }
    }

    public class DangKyMonHocController
    {
        public List<DangKyDisplay> GetAll()
        {
            return AppData.DangKys.Select(ToDisplay).ToList();
        }

        public bool Them(string maSinhVien, int maMonHoc, out string error)
        {
            error = string.Empty;
            SinhVien sinhVien = AppData.SinhViens.FirstOrDefault(x => x.MaSinhVien.Equals((maSinhVien ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase));
            MonHoc monHoc = AppData.MonHocs.FirstOrDefault(x => x.MaMonHoc == maMonHoc);
            if (sinhVien == null) { error = "Không tìm thấy sinh viên theo mã đã nhập."; return false; }
            if (monHoc == null) { error = "Không tìm thấy môn học theo mã đã nhập."; return false; }
            if (AppData.DangKys.Count(x => x.SinhVien == sinhVien) >= 8) { error = "Mỗi sinh viên chỉ được đăng ký tối đa 8 môn học."; return false; }
            if (AppData.DangKys.Any(x => x.SinhVien == sinhVien && x.MonHoc == monHoc)) { error = "Sinh viên đã đăng ký môn học này."; return false; }
            AppData.DangKys.Add(new BanDangKyMonHoc(sinhVien, monHoc));
            return true;
        }

        public bool Xoa(int maDangKy, out string error)
        {
            error = string.Empty;
            BanDangKyMonHoc dangKy = AppData.DangKys.FirstOrDefault(x => x.MaBanDangKy == maDangKy);
            if (dangKy == null) { error = "Không tìm thấy bản đăng ký cần xóa."; return false; }
            AppData.DangKys.Remove(dangKy);
            return true;
        }

        public List<DangKyDisplay> SapXepTheoThoiGian() { return AppData.DangKys.OrderBy(x => x.ThoiGianDangKy).Select(ToDisplay).ToList(); }
        public List<DangKyDisplay> SapXepTheoMaSinhVien() { return AppData.DangKys.OrderBy(x => x.SinhVien.MaSinhVien).Select(ToDisplay).ToList(); }
        public List<DangKyDisplay> SapXepTheoMaMonHoc() { return AppData.DangKys.OrderBy(x => x.MonHoc.MaMonHoc).Select(ToDisplay).ToList(); }
        public List<DangKyDisplay> TimTheoMaSinhVien(string ma) { return AppData.DangKys.Where(x => x.SinhVien.MaSinhVien.Equals((ma ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase)).Select(ToDisplay).ToList(); }
        public List<DangKyDisplay> TimTheoMaMonHoc(int ma) { return AppData.DangKys.Where(x => x.MonHoc.MaMonHoc == ma).Select(ToDisplay).ToList(); }
        public List<DangKyDisplay> TimSinhVienDangKySomNhat() { return AppData.DangKys.Count == 0 ? new List<DangKyDisplay>() : AppData.DangKys.Where(x => x.ThoiGianDangKy == AppData.DangKys.Min(y => y.ThoiGianDangKy)).Select(ToDisplay).ToList(); }
        public List<DangKyDisplay> TimSinhVienDangKyMuonNhat() { return AppData.DangKys.Count == 0 ? new List<DangKyDisplay>() : AppData.DangKys.Where(x => x.ThoiGianDangKy == AppData.DangKys.Max(y => y.ThoiGianDangKy)).Select(ToDisplay).ToList(); }

        private static DangKyDisplay ToDisplay(BanDangKyMonHoc x)
        {
            return new DangKyDisplay { MaDangKy = x.MaBanDangKy, MaSinhVien = x.SinhVien.MaSinhVien, HoTen = x.SinhVien.HoTen, MaMonHoc = x.MonHoc.MaMonHoc, TenMonHoc = x.MonHoc.TenMonHoc, ThoiGianDangKy = x.ThoiGianDangKy };
        }
    }
}
