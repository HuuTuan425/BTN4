using System;
using System.Linq;
using System.Windows.Forms;
using Controllers;

namespace Project
{
    public partial class SinhVien : Form
    {
        private readonly SinhVienController controller = new SinhVienController();
        public SinhVien()
        {
            InitializeComponent();
            RefreshGrid(controller.GetAll());
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSapXepTen_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.SapXepTheoTen());
        }

        private void btnSinhVienDangKyNhieuNhat_Click(object sender, EventArgs e)
        {
            ShowStudents(controller.TimDangKyNhieuNhat(), "Sinh viên đăng ký nhiều môn nhất");
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.GetAll());
        }

        private void RefreshGrid(object data)
        {
            dgvSinhVien.DataSource = null;
            dgvSinhVien.DataSource = data;
            if (dgvSinhVien.Columns.Count > 0)
            {
                dgvSinhVien.Columns["MaSinhVien"].HeaderText = "Mã sinh viên";
                dgvSinhVien.Columns["HoTen"].HeaderText = "Họ và tên";
                dgvSinhVien.Columns["NgaySinh"].HeaderText = "Ngày sinh";
                dgvSinhVien.Columns["Email"].HeaderText = "Email";
                dgvSinhVien.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                dgvSinhVien.Columns["ChuyenNganh"].HeaderText = "Chuyên ngành";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string error;
            if (controller.Them(txtMaSinhVien.Text, txtHoTen.Text, dtpNgaySinh.Value, txtEmail.Text, txtSoDienThoai.Text, txtChuyenNganh.Text, out error))
            {
                RefreshGrid(controller.GetAll());
                btnLamMoi_Click(sender, e);
                MessageBox.Show("Đã thêm sinh viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string error;
            if (controller.SuaTen(txtMaSinhVien.Text, txtHoTen.Text, out error))
            {
                RefreshGrid(controller.GetAll());
                MessageBox.Show("Đã sửa họ tên sinh viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string error;
            if (controller.Xoa(txtMaSinhVien.Text, out error))
            {
                RefreshGrid(controller.GetAll());
                btnLamMoi_Click(sender, e);
                MessageBox.Show("Đã xóa sinh viên và các bản đăng ký liên quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSinhVien.Clear(); txtHoTen.Clear(); txtEmail.Clear(); txtSoDienThoai.Clear(); txtChuyenNganh.Clear();
            dtpNgaySinh.Value = DateTime.Today; txtTimKiem.Clear(); txtMaSinhVien.Focus(); RefreshGrid(controller.GetAll());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.TimGanDung(txtTimKiem.Text));
        }

        private void ShowStudents(System.Collections.Generic.List<Models.SinhVien> students, string title)
        {
            if (students.Count == 0) { MessageBox.Show("Chưa có dữ liệu.", title, MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            MessageBox.Show(string.Join(Environment.NewLine, students.Select(x => x.MaSinhVien + " - " + x.HoTen)), title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lblListTitle_Click(object sender, EventArgs e) { }
        private void lblSoDienThoai_Click(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtSoDienThoai_TextChanged(object sender, EventArgs e) { }
    }
}
