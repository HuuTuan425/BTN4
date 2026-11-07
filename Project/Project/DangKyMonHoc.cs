using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Project
{
    public partial class DangKyMonHoc : Form
    {
        private readonly DangKyMonHocController controller = new DangKyMonHocController();

        public DangKyMonHoc()
        {
            InitializeComponent();
            RefreshGrid(controller.GetAll());
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimSinhVien_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.TimTheoMaSinhVien(txtMaSinhVienTim.Text));
        }

        private void btnTimMonHoc_Click(object sender, EventArgs e)
        {
            int ma;
            if (int.TryParse(txtMaMonHocTim.Text, out ma)) RefreshGrid(controller.TimTheoMaMonHoc(ma));
            else MessageBox.Show("Mã môn học không hợp lệ.");
        }

        private void btnTheoThoiGian_Click(object sender, EventArgs e) { RefreshGrid(controller.SapXepTheoThoiGian()); }

        private void btnTheoMaSinhVien_Click(object sender, EventArgs e) { RefreshGrid(controller.SapXepTheoMaSinhVien()); }

        private void btnTheoMaMonHoc_Click(object sender, EventArgs e) { RefreshGrid(controller.SapXepTheoMaMonHoc()); }

        private void btnSinhVienSomNhat_Click(object sender, EventArgs e) { ShowRegistrations(controller.TimSinhVienDangKySomNhat(), "Sinh viên đăng ký sớm nhất"); }

        private void btnSinhVienMuonNhat_Click(object sender, EventArgs e) { ShowRegistrations(controller.TimSinhVienDangKyMuonNhat(), "Sinh viên đăng ký muộn nhất"); }

        private void RefreshGrid(object data)
        {
            dgvDangKy.DataSource = null;
            dgvDangKy.DataSource = data;
            if (dgvDangKy.Columns.Count > 0)
            {
                dgvDangKy.Columns["MaDangKy"].HeaderText = "Mã đăng ký";
                dgvDangKy.Columns["MaSinhVien"].HeaderText = "Mã SV";
                dgvDangKy.Columns["HoTen"].HeaderText = "Họ tên sinh viên";
                dgvDangKy.Columns["MaMonHoc"].HeaderText = "Mã môn";
                dgvDangKy.Columns["TenMonHoc"].HeaderText = "Tên môn";
                dgvDangKy.Columns["ThoiGianDangKy"].HeaderText = "Thời gian đăng ký";
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string maSinhVien = txtMaSinhVien.Text.Trim();
            int maMonHoc;
            if (!Regex.IsMatch(maSinhVien, "^[A-Za-z0-9]+$")) { MessageBox.Show("Mã sinh viên không hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!int.TryParse(txtMaMonHoc.Text.Trim(), out maMonHoc)) { MessageBox.Show("Mã môn học không hợp lệ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            string error; if (controller.Them(maSinhVien, maMonHoc, out error)) { RefreshGrid(controller.GetAll()); MessageBox.Show("Đã đăng ký môn học."); } else MessageBox.Show(error, "Không thể đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            int maDangKy;
            if (!int.TryParse(txtMaDangKy.Text.Trim(), out maDangKy)) { MessageBox.Show("Vui lòng chọn bản đăng ký cần hủy."); return; }
            string error; if (controller.Xoa(maDangKy, out error)) { RefreshGrid(controller.GetAll()); txtMaDangKy.Clear(); MessageBox.Show("Đã xóa bản đăng ký."); } else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSinhVien.Clear(); txtMaMonHoc.Clear(); txtMaDangKy.Clear(); txtMaSinhVienTim.Clear(); txtMaMonHocTim.Clear(); lblMaMonHocValue.Text = "-"; lblTinChiValue.Text = "-"; lblSoTietValue.Text = "-"; RefreshGrid(controller.GetAll());
        }

        private void txtMaMonHoc_TextChanged(object sender, EventArgs e)
        {
            int maMonHoc;
            if (!int.TryParse(txtMaMonHoc.Text.Trim(), out maMonHoc)) { lblMaMonHocValue.Text = "-"; lblTinChiValue.Text = "-"; lblSoTietValue.Text = "-"; return; }
            Models.MonHoc mh = AppData.MonHocs.FirstOrDefault(x => x.MaMonHoc == maMonHoc); if (mh == null) { lblMaMonHocValue.Text = "-"; lblTinChiValue.Text = "-"; lblSoTietValue.Text = "-"; return; }
            lblMaMonHocValue.Text = mh.MaMonHoc.ToString(); lblTinChiValue.Text = mh.SoTinChi.ToString(); lblSoTietValue.Text = mh.SoTietHoc.ToString();
        }

        private void dgvDangKy_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDangKy.SelectedRows.Count == 0) return;
            DangKyDisplay row = dgvDangKy.SelectedRows[0].DataBoundItem as DangKyDisplay;
            if (row == null) return;
            txtMaDangKy.Text = row.MaDangKy.ToString();
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.GetAll());
        }

        private void DangKyMonHoc_Load(object sender, EventArgs e)
        {
        }

        private void ShowRegistrations(System.Collections.Generic.List<DangKyDisplay> rows, string title)
        {
            if (rows.Count == 0) { MessageBox.Show("Chưa có dữ liệu.", title); return; }
            MessageBox.Show(string.Join(Environment.NewLine, rows.Select(x => x.MaSinhVien + " - " + x.HoTen + " - " + x.ThoiGianDangKy)), title);
        }

        private void lblMaSinhVienTim_Click(object sender, EventArgs e)
        {

        }
    }
}
