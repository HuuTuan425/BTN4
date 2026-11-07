using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Models;

namespace Controllers
{
    public class MonHocController
    {
        private static MonHoc Read(SqlDataReader r)
        {
            return new MonHoc { MaMonHoc = Convert.ToInt32(r["MaMonHoc"]), TenMonHoc = r["TenMonHoc"].ToString(), SoTinChi = Convert.ToInt32(r["SoTinChi"]), SoTietHoc = Convert.ToInt32(r["SoTietHoc"]) };
        }
        private static List<MonHoc> Query(string sql, params SqlParameter[] parameters)
        {
            var result = new List<MonHoc>(); using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand(sql, cn)) { cmd.Parameters.AddRange(parameters); using (var r = cmd.ExecuteReader()) while (r.Read()) result.Add(Read(r)); } return result;
        }
        public List<MonHoc> GetAll() { return Query("SELECT * FROM MonHoc ORDER BY MaMonHoc"); }
        public bool Them(string ten, int tinChi, int soTiet, out string error)
        {
            error = string.Empty; if (string.IsNullOrWhiteSpace(ten)) { error = "Tên môn học không được để trống."; return false; } if (tinChi <= 0 || soTiet <= 0) { error = "Số tín chỉ và số tiết học phải lớn hơn 0."; return false; }
            try { using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand("INSERT INTO MonHoc(TenMonHoc,SoTinChi,SoTietHoc) VALUES(@ten,@tc,@st)", cn)) { cmd.Parameters.AddWithValue("@ten", ten.Trim()); cmd.Parameters.AddWithValue("@tc", tinChi); cmd.Parameters.AddWithValue("@st", soTiet); cmd.ExecuteNonQuery(); return true; } }
            catch (Exception ex) { error = ex.Message; return false; }
        }
        public bool SuaSoTiet(int ma, string ten, int tinChi, int soTiet, out string error)
        {
            error = string.Empty; if (string.IsNullOrWhiteSpace(ten)) { error = "Tên môn học không được để trống."; return false; } if (tinChi <= 0 || soTiet <= 0) { error = "Số tín chỉ và số tiết học phải lớn hơn 0."; return false; }
            try { using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand("UPDATE MonHoc SET TenMonHoc=@ten, SoTinChi=@tc, SoTietHoc=@st WHERE MaMonHoc=@ma", cn)) { cmd.Parameters.AddWithValue("@ten", ten.Trim()); cmd.Parameters.AddWithValue("@tc", tinChi); cmd.Parameters.AddWithValue("@st", soTiet); cmd.Parameters.AddWithValue("@ma", ma); if (cmd.ExecuteNonQuery() == 0) { error = "Không tìm thấy môn học theo mã đã nhập."; return false; } return true; } } catch (Exception ex) { error = ex.Message; return false; }
        }
        public bool Xoa(int ma, out string error)
        {
            error = string.Empty; try { using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand("DELETE FROM MonHoc WHERE MaMonHoc=@ma", cn)) { cmd.Parameters.AddWithValue("@ma", ma); if (cmd.ExecuteNonQuery() == 0) { error = "Không tìm thấy môn học cần xóa."; return false; } return true; } } catch (Exception ex) { error = ex.Message; return false; }
        }
        public List<MonHoc> TimGanDung(string ten) { return string.IsNullOrWhiteSpace(ten) ? GetAll() : Query("SELECT * FROM MonHoc WHERE TenMonHoc LIKE @ten ORDER BY MaMonHoc", new SqlParameter("@ten", "%" + ten.Trim() + "%")); }
        public List<MonHoc> SapXepTheoTinChi() { return Query("SELECT * FROM MonHoc ORDER BY SoTinChi DESC"); }
        public MonHoc TimTheoMa(int ma) { return Query("SELECT * FROM MonHoc WHERE MaMonHoc=@ma", new SqlParameter("@ma", ma)).FirstOrDefault(); }
        public List<MonHoc> TimDangKyNhieuNhat() { return Query("SELECT m.* FROM MonHoc m LEFT JOIN DangKyMonHoc d ON d.MaMonHoc=m.MaMonHoc GROUP BY m.MaMonHoc,m.TenMonHoc,m.SoTinChi,m.SoTietHoc HAVING COUNT(d.MaDangKy)=(SELECT MAX(x.c) FROM (SELECT COUNT(*) c FROM DangKyMonHoc GROUP BY MaMonHoc) x)"); }
    }
}
