using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class SinhVienController
    {
        public List<SinhVien> GetAll()
        {
            return AppData.SinhViens.ToList();
        }

        public bool Them(string maSinhVien, string hoTen, DateTime ngaySinh, string email, string soDienThoai, string chuyenNganh, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(maSinhVien) || string.IsNullOrWhiteSpace(hoTen)) { error = "Mã sinh viên và họ tên không được để trống."; return false; }
            if (AppData.SinhViens.Any(x => x.MaSinhVien.Equals(maSinhVien.Trim(), StringComparison.OrdinalIgnoreCase))) { error = "Mã sinh viên đã tồn tại."; return false; }
            AppData.SinhViens.Add(new SinhVien(maSinhVien.Trim(), hoTen.Trim(), ngaySinh, email.Trim(), soDienThoai.Trim(), chuyenNganh.Trim()));
            return true;
        }

        public bool SuaTen(string maSinhVien, string hoTen, out string error)
        {
            error = string.Empty;
            SinhVien sinhVien = TimTheoMa(maSinhVien);
            if (sinhVien == null) { error = "Không tìm thấy sinh viên theo mã đã nhập."; return false; }
            if (string.IsNullOrWhiteSpace(hoTen)) { error = "Họ tên không được để trống."; return false; }
            sinhVien.HoTen = hoTen.Trim();
            return true;
        }

        public bool Xoa(string maSinhVien, out string error)
        {
            error = string.Empty;
            SinhVien sinhVien = TimTheoMa(maSinhVien);
            if (sinhVien == null) { error = "Không tìm thấy sinh viên cần xóa."; return false; }
            AppData.SinhViens.Remove(sinhVien);
            AppData.DangKys.RemoveAll(x => x.SinhVien == sinhVien);
            return true;
        }

        public List<SinhVien> TimGanDung(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten)) return GetAll();
            return AppData.SinhViens.Where(x => x.HoTen.IndexOf(ten.Trim(), StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public List<SinhVien> SapXepTheoTen()
        {
            return AppData.SinhViens.OrderBy(x => Models.FullName.Ten(x.HoTen)).ThenBy(x => Models.FullName.Ho(x.HoTen)).ToList();
        }

        public SinhVien TimTheoMa(string maSinhVien)
        {
            return AppData.SinhViens.FirstOrDefault(x => x.MaSinhVien.Equals((maSinhVien ?? string.Empty).Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public List<SinhVien> TimDangKyNhieuNhat()
        {
            if (AppData.SinhViens.Count == 0) return new List<SinhVien>();
            int max = AppData.SinhViens.Max(sv => AppData.DangKys.Count(dk => dk.SinhVien == sv));
            return AppData.SinhViens.Where(sv => AppData.DangKys.Count(dk => dk.SinhVien == sv) == max).ToList();
        }

        public List<SinhVien> TimDangKySomNhat()
        {
            if (AppData.DangKys.Count == 0) return new List<SinhVien>();
            DateTime thoiGianSomNhat = AppData.DangKys.Min(x => x.ThoiGianDangKy);
            return AppData.DangKys
                .Where(x => x.ThoiGianDangKy == thoiGianSomNhat)
                .Select(x => x.SinhVien)
                .Distinct()
                .ToList();
        }

        public List<SinhVien> TimDangKyMuonNhat()
        {
            if (AppData.DangKys.Count == 0) return new List<SinhVien>();
            DateTime thoiGianMuonNhat = AppData.DangKys.Max(x => x.ThoiGianDangKy);
            return AppData.DangKys
                .Where(x => x.ThoiGianDangKy == thoiGianMuonNhat)
                .Select(x => x.SinhVien)
                .Distinct()
                .ToList();
        }
    }
}
