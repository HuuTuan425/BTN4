using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using Models;

namespace Controllers
{
    public class SinhVienController
    {
        private static SinhVien Read(SqlDataReader r)
        {
            return new SinhVien
            {
                MaSinhVien = r["MaSinhVien"].ToString(),
                HoTen = r["HoTen"].ToString(),
                NgaySinh = Convert.ToDateTime(r["NgaySinh"]),
                Email = r["Email"] == DBNull.Value ? string.Empty : r["Email"].ToString(),
                SoDienThoai = r["SoDienThoai"] == DBNull.Value ? string.Empty : r["SoDienThoai"].ToString(),
                ChuyenNganh = r["ChuyenNganh"] == DBNull.Value ? string.Empty : r["ChuyenNganh"].ToString()
            };
        }

        public List<SinhVien> GetAll() { return Query("SELECT * FROM SinhVien ORDER BY MaSinhVien"); }

        private static List<SinhVien> Query(string sql, params SqlParameter[] parameters)
        {
            var result = new List<SinhVien>();
            using (var cn = AppData.OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parameters);
                using (var r = cmd.ExecuteReader()) while (r.Read()) result.Add(Read(r));
            }
            return result;
        }

        public bool Them(string ma, string ten, DateTime ngaySinh, string email, string phone, string chuyenNganh, out string error)
        {
            error = string.Empty;
            try
            {
                ValidateMaSinhVien(ma);
                ValidateHoTen(ten);
                ValidateEmail(email);
                ValidateSoDienThoai(phone);

                using (var cn = AppData.OpenConnection())
                using (var cmd = new SqlCommand("INSERT INTO SinhVien(MaSinhVien,HoTen,NgaySinh,Email,SoDienThoai,ChuyenNganh) VALUES(@ma,@ten,@ngay,@email,@phone,@cn)", cn))
                {
                    cmd.Parameters.AddWithValue("@ma", ma.Trim()); cmd.Parameters.AddWithValue("@ten", ten.Trim()); cmd.Parameters.AddWithValue("@ngay", ngaySinh);
                    cmd.Parameters.AddWithValue("@email", (object)(email ?? string.Empty)); cmd.Parameters.AddWithValue("@phone", (object)(phone ?? string.Empty)); cmd.Parameters.AddWithValue("@cn", (object)(chuyenNganh ?? string.Empty)); cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (InvalidMSVException ex) { error = ex.Message; return false; }
            catch (InvalidNameException ex) { error = ex.Message; return false; }
            catch (InvalidEmailException ex) { error = ex.Message; return false; }
            catch (InvalidPhoneException ex) { error = ex.Message; return false; }
            catch (SqlException ex) { error = ex.Number == 2627 ? "Mã sinh viên đã tồn tại." : ex.Message; return false; }
        }

        public bool SuaTen(string ma, string ten, out string error)
        {
            error = string.Empty;
            try
            {
                ValidateHoTen(ten);
                using (var cn = AppData.OpenConnection()) using (var cmd = new SqlCommand("UPDATE SinhVien SET HoTen=@ten WHERE MaSinhVien=@ma", cn)) { cmd.Parameters.AddWithValue("@ten", ten.Trim()); cmd.Parameters.AddWithValue("@ma", ma.Trim()); if (cmd.ExecuteNonQuery() == 0) { error = "Không tìm thấy sinh viên theo mã đã nhập."; return false; } return true; }
            }
            catch (InvalidNameException ex) { error = ex.Message; return false; }
            catch (Exception ex) { error = ex.Message; return false; }
        }

        private static void ValidateMaSinhVien(string ma)
        {
            if (string.IsNullOrWhiteSpace(ma) || !Regex.IsMatch(ma.Trim(), "^[A-Za-z0-9]+$"))
                throw new InvalidMSVException();
        }

        private static void ValidateHoTen(string ten)
        {
            if (string.IsNullOrWhiteSpace(ten))
                throw new InvalidNameException();
        }

        private static void ValidateEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && !Regex.IsMatch(email.Trim(), "^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$"))
                throw new InvalidEmailException();
        }

        private static void ValidateSoDienThoai(string phone)
        {
            if (!string.IsNullOrWhiteSpace(phone) && !Regex.IsMatch(phone.Trim(), "^0\\d{9,10}$"))
                throw new InvalidPhoneException();
        }

        public bool Xoa(string ma, out string error)
        {
            error = string.Empty;
            if (string.IsNullOrWhiteSpace(ma)) { error = "Mã sinh viên không được để trống."; return false; }
            try
            {
                using (var cn = AppData.OpenConnection())
                using (var transaction = cn.BeginTransaction())
                {
                    using (var cmd = new SqlCommand("DELETE FROM DangKyMonHoc WHERE MaSinhVien=@ma", cn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma.Trim());
                        cmd.ExecuteNonQuery();
                    }
                    using (var cmd = new SqlCommand("DELETE FROM SinhVien WHERE MaSinhVien=@ma", cn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ma", ma.Trim());
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            transaction.Rollback();
                            error = "Không tìm thấy sinh viên cần xóa.";
                            return false;
                        }
                    }
                    transaction.Commit();
                    return true;
                }
            }
            catch (SqlException ex) { error = ex.Message; return false; }
        }

        public List<SinhVien> TimGanDung(string ten) { return string.IsNullOrWhiteSpace(ten) ? GetAll() : Query("SELECT * FROM SinhVien WHERE HoTen LIKE @ten ORDER BY MaSinhVien", new SqlParameter("@ten", "%" + ten.Trim() + "%")); }
        public List<SinhVien> TimTenBatDau(string ten) { return string.IsNullOrWhiteSpace(ten) ? new List<SinhVien>() : Query("SELECT TOP 8 * FROM SinhVien WHERE HoTen LIKE @ten + '%' ORDER BY HoTen", new SqlParameter("@ten", ten.Trim())); }
        public List<SinhVien> TimTheoMaBatDau(string ma) { return string.IsNullOrWhiteSpace(ma) ? new List<SinhVien>() : Query("SELECT TOP 8 * FROM SinhVien WHERE MaSinhVien LIKE @ma + '%' ORDER BY MaSinhVien", new SqlParameter("@ma", ma.Trim())); }
        public List<SinhVien> SapXepTheoTen() { return Query("SELECT * FROM SinhVien ORDER BY RIGHT(HoTen, CHARINDEX(' ', REVERSE(HoTen)) - 1), HoTen"); }
        public SinhVien TimTheoMa(string ma) { return Query("SELECT * FROM SinhVien WHERE MaSinhVien=@ma", new SqlParameter("@ma", (ma ?? string.Empty).Trim())).FirstOrDefault(); }
        public List<SinhVien> TimDangKyNhieuNhat() { return Query("SELECT s.* FROM SinhVien s LEFT JOIN DangKyMonHoc d ON d.MaSinhVien=s.MaSinhVien GROUP BY s.MaSinhVien,s.HoTen,s.NgaySinh,s.Email,s.SoDienThoai,s.ChuyenNganh HAVING COUNT(d.MaDangKy)=(SELECT MAX(x.c) FROM (SELECT COUNT(*) c FROM DangKyMonHoc GROUP BY MaSinhVien) x)"); }
        public List<SinhVien> TimDangKySomNhat() { return Query("SELECT DISTINCT s.* FROM SinhVien s JOIN DangKyMonHoc d ON d.MaSinhVien=s.MaSinhVien WHERE d.ThoiGianDangKy=(SELECT MIN(ThoiGianDangKy) FROM DangKyMonHoc)"); }
        public List<SinhVien> TimDangKyMuonNhat() { return Query("SELECT DISTINCT s.* FROM SinhVien s JOIN DangKyMonHoc d ON d.MaSinhVien=s.MaSinhVien WHERE d.ThoiGianDangKy=(SELECT MAX(ThoiGianDangKy) FROM DangKyMonHoc)"); }
    }
}
