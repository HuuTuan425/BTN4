using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private const string Select = "SELECT d.MaDangKy,d.MaSinhVien,s.HoTen,d.MaMonHoc,m.TenMonHoc,d.ThoiGianDangKy FROM DangKyMonHoc d JOIN SinhVien s ON s.MaSinhVien=d.MaSinhVien JOIN MonHoc m ON m.MaMonHoc=d.MaMonHoc";
        private static DangKyDisplay Read(SqlDataReader r) { return new DangKyDisplay { MaDangKy = Convert.ToInt32(r["MaDangKy"]), MaSinhVien = r["MaSinhVien"].ToString(), HoTen = r["HoTen"].ToString(), MaMonHoc = Convert.ToInt32(r["MaMonHoc"]), TenMonHoc = r["TenMonHoc"].ToString(), ThoiGianDangKy = Convert.ToDateTime(r["ThoiGianDangKy"]) }; }
        private static List<DangKyDisplay> Query(string sql, params SqlParameter[] parameters)
        {
            var result = new List<DangKyDisplay>(); using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand(sql, cn)) { cmd.Parameters.AddRange(parameters); using (var r = cmd.ExecuteReader()) while (r.Read()) result.Add(Read(r)); } return result;
        }
        public List<DangKyDisplay> GetAll() { return Query(Select + " ORDER BY d.MaDangKy"); }
        public bool Them(string maSinhVien, int maMonHoc, out string error)
        {
            error = string.Empty; try { using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand("INSERT INTO DangKyMonHoc(MaSinhVien,MaMonHoc,ThoiGianDangKy) VALUES(@sv,@mh,GETDATE())", cn)) { cmd.Parameters.AddWithValue("@sv", maSinhVien.Trim()); cmd.Parameters.AddWithValue("@mh", maMonHoc); cmd.ExecuteNonQuery(); return true; } } catch (SqlException ex) { error = ex.Number == 2627 ? "Sinh viên đã đăng ký môn học này." : ex.Number == 547 ? "Không tìm thấy sinh viên hoặc môn học." : ex.Message; return false; } catch (Exception ex) { error = ex.Message; return false; }
        }
        public bool Xoa(int ma, out string error)
        {
            error = string.Empty; try { using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand("DELETE FROM DangKyMonHoc WHERE MaDangKy=@ma", cn)) { cmd.Parameters.AddWithValue("@ma", ma); if (cmd.ExecuteNonQuery() == 0) { error = "Không tìm thấy bản đăng ký cần xóa."; return false; } return true; } } catch (Exception ex) { error = ex.Message; return false; }
        }
        public List<DangKyDisplay> SapXepTheoThoiGian() { return Query(Select + " ORDER BY d.ThoiGianDangKy"); }
        public List<DangKyDisplay> SapXepTheoMaSinhVien() { return Query(Select + " ORDER BY d.MaSinhVien"); }
        public List<DangKyDisplay> SapXepTheoMaMonHoc() { return Query(Select + " ORDER BY d.MaMonHoc"); }
        public List<DangKyDisplay> TimTheoMaSinhVien(string ma) { return Query(Select + " WHERE d.MaSinhVien=@ma", new SqlParameter("@ma", (ma ?? string.Empty).Trim())); }
        public List<DangKyDisplay> TimTheoMaMonHoc(int ma) { return Query(Select + " WHERE d.MaMonHoc=@ma", new SqlParameter("@ma", ma)); }
        public List<DangKyDisplay> TimSinhVienDangKySomNhat() { return Query(Select + " WHERE d.ThoiGianDangKy=(SELECT MIN(ThoiGianDangKy) FROM DangKyMonHoc)"); }
        public List<DangKyDisplay> TimSinhVienDangKyMuonNhat() { return Query(Select + " WHERE d.ThoiGianDangKy=(SELECT MAX(ThoiGianDangKy) FROM DangKyMonHoc)"); }
    }
}
