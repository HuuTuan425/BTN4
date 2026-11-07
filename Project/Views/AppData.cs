using System.Collections.Generic;
using System.Data.SqlClient;
using Models;

namespace Controllers
{
    public static class AppData
    {
        // Kept for compatibility with the existing UI/model code.
        public static readonly List<SinhVien> SinhViens = new List<SinhVien>();
        public static readonly List<MonHoc> MonHocs = new List<MonHoc>();
        public static readonly List<BanDangKyMonHoc> DangKys = new List<BanDangKyMonHoc>();

        public static SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=Quan_Ly_Mon_Hoc;Integrated Security=True;TrustServerCertificate=True");
            connection.Open();
            return connection;
        }
    }
}
