using System;
using System.Linq;
using System.Windows.Forms;
using Controllers;

namespace Project
{
    public partial class SinhVien : Form
    {
        private readonly SinhVienController controller = new SinhVienController();
        private readonly ListBox lstSinhVienGoiY = new ListBox();
        private bool dangChonGoiY;

        public SinhVien()
        {
            InitializeComponent();
            ConfigureSearchSuggestions();
            RefreshGrid(controller.GetAll());
        }

        private void ConfigureSearchSuggestions()
        {
            lstSinhVienGoiY.Location = new System.Drawing.Point(txtTimKiem.Left, txtTimKiem.Bottom);
            lstSinhVienGoiY.Size = new System.Drawing.Size(txtTimKiem.Width, 150);
            lstSinhVienGoiY.Font = txtTimKiem.Font;
            lstSinhVienGoiY.Visible = false;
            lstSinhVienGoiY.IntegralHeight = false;
            lstSinhVienGoiY.FormattingEnabled = true;
            lstSinhVienGoiY.Format += lstSinhVienGoiY_Format;
            lstSinhVienGoiY.MouseClick += lstSinhVienGoiY_MouseClick;
            lstSinhVienGoiY.KeyDown += lstSinhVienGoiY_KeyDown;
            pnlList.Controls.Add(lstSinhVienGoiY);
            lstSinhVienGoiY.BringToFront();
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dangChonGoiY) return;

            string ten = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                lstSinhVienGoiY.Visible = false;
                return;
            }

            var sinhVien = controller.TimTenBatDau(ten);
            lstSinhVienGoiY.DataSource = sinhVien;
            lstSinhVienGoiY.Visible = sinhVien.Count > 0;
            if (lstSinhVienGoiY.Visible) lstSinhVienGoiY.BringToFront();
        }

        private void lstSinhVienGoiY_Format(object sender, ListControlConvertEventArgs e)
        {
            Models.SinhVien sinhVien = e.ListItem as Models.SinhVien;
            if (sinhVien != null) e.Value = sinhVien.HoTen + " - " + sinhVien.MaSinhVien;
        }

        private void lstSinhVienGoiY_MouseClick(object sender, MouseEventArgs e)
        {
            ChonSinhVienGoiY();
        }

        private void lstSinhVienGoiY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChonSinhVienGoiY();
                e.Handled = true;
            }
        }

        private void ChonSinhVienGoiY()
        {
            Models.SinhVien sinhVien = lstSinhVienGoiY.SelectedItem as Models.SinhVien;
            if (sinhVien == null) return;

            dangChonGoiY = true;
            txtTimKiem.Text = sinhVien.HoTen;
            txtTimKiem.SelectionStart = txtTimKiem.TextLength;
            dangChonGoiY = false;
            lstSinhVienGoiY.Visible = false;
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
            txtTimKiem.Clear();
            RefreshGrid(controller.GetAll());
            dgvSinhVien.ClearSelection();
            txtMaSinhVien.Clear(); txtHoTen.Clear(); txtEmail.Clear(); txtSoDienThoai.Clear(); txtChuyenNganh.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            txtMaSinhVien.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.TimGanDung(txtTimKiem.Text));
        }

        private void dgvSinhVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSinhVien.SelectedRows.Count == 0) return;
            Models.SinhVien sinhVien = dgvSinhVien.SelectedRows[0].DataBoundItem as Models.SinhVien;
            if (sinhVien == null) return;

            txtMaSinhVien.Text = sinhVien.MaSinhVien;
            txtHoTen.Text = sinhVien.HoTen;
            dtpNgaySinh.Value = sinhVien.NgaySinh;
            txtEmail.Text = sinhVien.Email;
            txtSoDienThoai.Text = sinhVien.SoDienThoai;
            txtChuyenNganh.Text = sinhVien.ChuyenNganh;
        }

        private void dgvSinhVien_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvSinhVien.HitTest(e.X, e.Y).RowIndex >= 0) return;

            dgvSinhVien.ClearSelection();
            dgvSinhVien.CurrentCell = null;
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

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SinhVien_Load(object sender, EventArgs e)
        {

        }
    }
}
