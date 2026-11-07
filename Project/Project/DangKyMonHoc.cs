using System;
using System.Linq;
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
            LoadCombos();
            RefreshGrid(controller.GetAll());
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadCombos()
        {
            cboSinhVien.DataSource = null; cboSinhVien.DataSource = AppData.SinhViens.ToList(); cboSinhVien.DisplayMember = "HoTen"; cboSinhVien.ValueMember = "MaSinhVien"; cboSinhVien.SelectedIndex = -1;
            cboMonHoc.DataSource = null; cboMonHoc.DataSource = AppData.MonHocs.ToList(); cboMonHoc.DisplayMember = "TenMonHoc"; cboMonHoc.ValueMember = "MaMonHoc"; cboMonHoc.SelectedIndex = -1;
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

        private void RefreshGrid(object data) { dgvDangKy.DataSource = null; dgvDangKy.DataSource = data; }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (cboSinhVien.SelectedIndex < 0 || cboMonHoc.SelectedIndex < 0) { MessageBox.Show("Vui lòng chọn sinh viên và môn học.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            Models.SinhVien sv = cboSinhVien.SelectedItem as Models.SinhVien; Models.MonHoc mh = cboMonHoc.SelectedItem as Models.MonHoc;
            string error; if (controller.Them(sv.MaSinhVien, mh.MaMonHoc, out error)) { RefreshGrid(controller.GetAll()); MessageBox.Show("Đã đăng ký môn học."); } else MessageBox.Show(error, "Không thể đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            if (dgvDangKy.SelectedRows.Count == 0) { MessageBox.Show("Vui lòng chọn bản đăng ký cần hủy."); return; }
            DangKyDisplay row = dgvDangKy.SelectedRows[0].DataBoundItem as DangKyDisplay; if (row == null) return;
            string error; if (controller.Xoa(row.MaDangKy, out error)) { RefreshGrid(controller.GetAll()); MessageBox.Show("Đã xóa bản đăng ký."); } else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadCombos(); txtMaSinhVienTim.Clear(); txtMaMonHocTim.Clear(); lblMaMonHocValue.Text = "-"; lblTinChiValue.Text = "-"; lblSoTietValue.Text = "-"; RefreshGrid(controller.GetAll());
        }

        private void cboMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Models.MonHoc mh = cboMonHoc.SelectedItem as Models.MonHoc; if (mh == null) { lblMaMonHocValue.Text = "-"; lblTinChiValue.Text = "-"; lblSoTietValue.Text = "-"; return; }
            lblMaMonHocValue.Text = mh.MaMonHoc.ToString(); lblTinChiValue.Text = mh.SoTinChi.ToString(); lblSoTietValue.Text = mh.SoTietHoc.ToString();
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
