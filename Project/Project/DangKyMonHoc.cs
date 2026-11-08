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
        private readonly SinhVienController sinhVienController = new SinhVienController();
        private readonly MonHocController monHocController = new MonHocController();
        private readonly ListBox lstSinhVienGoiY = new ListBox();
        private readonly ListBox lstMonHocGoiY = new ListBox();
        private bool dangChonGoiY;

        public DangKyMonHoc()
        {
            InitializeComponent();
            ConfigureStudentSuggestions();
            ConfigureSubjectSuggestions();
            RefreshGrid(controller.GetAll());
        }

        private void ConfigureSubjectSuggestions()
        {
            lstMonHocGoiY.Location = new System.Drawing.Point(txtMaMonHoc.Left, txtMaMonHoc.Bottom);
            lstMonHocGoiY.Size = new System.Drawing.Size(txtMaMonHoc.Width, 150);
            lstMonHocGoiY.Font = txtMaMonHoc.Font;
            lstMonHocGoiY.Visible = false;
            lstMonHocGoiY.IntegralHeight = false;
            lstMonHocGoiY.FormattingEnabled = true;
            lstMonHocGoiY.Format += lstMonHocGoiY_Format;
            lstMonHocGoiY.MouseClick += lstMonHocGoiY_MouseClick;
            lstMonHocGoiY.KeyDown += lstMonHocGoiY_KeyDown;
            pnlChon.Controls.Add(lstMonHocGoiY);
            lstMonHocGoiY.BringToFront();
        }

        private void ConfigureStudentSuggestions()
        {
            lstSinhVienGoiY.Location = new System.Drawing.Point(txtMaSinhVien.Left, txtMaSinhVien.Bottom);
            lstSinhVienGoiY.Size = new System.Drawing.Size(txtMaSinhVien.Width, 150);
            lstSinhVienGoiY.Font = txtMaSinhVien.Font;
            lstSinhVienGoiY.Visible = false;
            lstSinhVienGoiY.IntegralHeight = false;
            lstSinhVienGoiY.FormattingEnabled = true;
            lstSinhVienGoiY.Format += lstSinhVienGoiY_Format;
            lstSinhVienGoiY.MouseClick += lstSinhVienGoiY_MouseClick;
            lstSinhVienGoiY.KeyDown += lstSinhVienGoiY_KeyDown;
            pnlChon.Controls.Add(lstSinhVienGoiY);
            lstSinhVienGoiY.BringToFront();
            txtMaSinhVien.TextChanged += txtMaSinhVien_TextChanged;
        }

        private void txtMaSinhVien_TextChanged(object sender, EventArgs e)
        {
            if (dangChonGoiY) return;

            string ma = txtMaSinhVien.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma))
            {
                lstSinhVienGoiY.Visible = false;
                return;
            }

            var sinhVien = sinhVienController.TimTheoMaBatDau(ma);
            lstSinhVienGoiY.DataSource = sinhVien;
            lstSinhVienGoiY.Visible = sinhVien.Count > 0;
            if (lstSinhVienGoiY.Visible) lstSinhVienGoiY.BringToFront();
        }

        private void lstSinhVienGoiY_Format(object sender, ListControlConvertEventArgs e)
        {
            Models.SinhVien sinhVien = e.ListItem as Models.SinhVien;
            if (sinhVien != null) e.Value = sinhVien.MaSinhVien + " - " + sinhVien.HoTen;
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
            txtMaSinhVien.Text = sinhVien.MaSinhVien;
            txtMaSinhVien.SelectionStart = txtMaSinhVien.TextLength;
            dangChonGoiY = false;
            lstSinhVienGoiY.Visible = false;
            txtMaMonHoc.Focus();
        }

        private void CapNhatGoiYMonHoc()
        {
            if (dangChonGoiY) return;

            string ma = txtMaMonHoc.Text.Trim();
            if (string.IsNullOrWhiteSpace(ma) || !ma.All(char.IsDigit))
            {
                lstMonHocGoiY.Visible = false;
                return;
            }

            var monHoc = monHocController.TimTheoMaBatDau(ma);
            lstMonHocGoiY.DataSource = monHoc;
            lstMonHocGoiY.Visible = monHoc.Count > 0;
            if (lstMonHocGoiY.Visible) lstMonHocGoiY.BringToFront();
        }

        private void lstMonHocGoiY_Format(object sender, ListControlConvertEventArgs e)
        {
            Models.MonHoc monHoc = e.ListItem as Models.MonHoc;
            if (monHoc != null) e.Value = monHoc.MaMonHoc + " - " + monHoc.TenMonHoc;
        }

        private void lstMonHocGoiY_MouseClick(object sender, MouseEventArgs e)
        {
            ChonMonHocGoiY();
        }

        private void lstMonHocGoiY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChonMonHocGoiY();
                e.Handled = true;
            }
        }

        private void ChonMonHocGoiY()
        {
            Models.MonHoc monHoc = lstMonHocGoiY.SelectedItem as Models.MonHoc;
            if (monHoc == null) return;

            dangChonGoiY = true;
            txtMaMonHoc.Text = monHoc.MaMonHoc.ToString();
            txtMaMonHoc.SelectionStart = txtMaMonHoc.TextLength;
            dangChonGoiY = false;
            lstMonHocGoiY.Visible = false;
            txtMaMonHoc.Focus();
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimSinhVien_Click(object sender, EventArgs e)
        {
            var rows = controller.TimTheoMaSinhVien(txtMaSinhVienTim.Text);
            RefreshGrid(rows);
            if (rows.Count == 0) MessageBox.Show("Không tìm thấy đăng ký theo mã sinh viên đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTimMonHoc_Click(object sender, EventArgs e)
        {
            int ma;
            if (int.TryParse(txtMaMonHocTim.Text, out ma))
            {
                var rows = controller.TimTheoMaMonHoc(ma);
                RefreshGrid(rows);
                if (rows.Count == 0) MessageBox.Show("Không tìm thấy đăng ký theo mã môn học đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            if (string.IsNullOrWhiteSpace(maSinhVien))
            {
                MessageBox.Show("Chưa nhập mã sinh viên.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maMonHoc;
            if (!Regex.IsMatch(maSinhVien, "^[A-Za-z0-9]+$"))
            {
                MessageBox.Show("Mã sinh viên không hợp lệ.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maMonHocText = txtMaMonHoc.Text.Trim();
            if (string.IsNullOrWhiteSpace(maMonHocText))
            {
                MessageBox.Show("Chưa nhập mã môn học.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(maMonHocText, out maMonHoc))
            {
                MessageBox.Show("Mã môn học không hợp lệ.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            txtMaSinhVien.Clear(); txtMaMonHoc.Clear(); txtMaDangKy.Clear(); txtMaSinhVienTim.Clear(); txtMaMonHocTim.Clear(); ClearMonHocPreview(); RefreshGrid(controller.GetAll());
        }

        private void txtMaMonHoc_TextChanged(object sender, EventArgs e)
        {
            CapNhatGoiYMonHoc();
            int maMonHoc;
            if (!int.TryParse(txtMaMonHoc.Text.Trim(), out maMonHoc)) { ClearMonHocPreview(); return; }
            Models.MonHoc mh = new MonHocController().TimTheoMa(maMonHoc); if (mh == null) { ClearMonHocPreview(); return; }
            lblMaMonHocValue.Text = mh.MaMonHoc.ToString(); lblTinChiValue.Text = mh.SoTinChi.ToString(); lblSoTietValue.Text = mh.SoTietHoc.ToString();
        }

        private void ClearMonHocPreview()
        {
            // Keep the placeholder visible both at design time and before a valid subject is selected.
            lblMaMonHocValue.Text = "-";
            lblTinChiValue.Text = "-";
            lblSoTietValue.Text = "-";
        }

        private void dgvDangKy_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDangKy.SelectedRows.Count == 0) return;
            DangKyDisplay row = dgvDangKy.SelectedRows[0].DataBoundItem as DangKyDisplay;
            if (row == null) return;
            txtMaDangKy.Text = row.MaDangKy.ToString();
        }

        private void dgvDangKy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space) return;

            dgvDangKy.ClearSelection();
            dgvDangKy.CurrentCell = null;
            txtMaDangKy.Clear();
            e.SuppressKeyPress = true;
        }

        private void dgvDangKy_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvDangKy.HitTest(e.X, e.Y).RowIndex >= 0) return;

            dgvDangKy.ClearSelection();
            dgvDangKy.CurrentCell = null;
            txtMaDangKy.Clear();
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
