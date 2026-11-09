using System;
using System.Collections.Generic;
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
        private readonly Label lblListStatus = new Label();
        private List<DangKyDisplay> danhSachGoc = new List<DangKyDisplay>();
        private readonly ListBox lstSinhVienGoiY = new ListBox();
        private readonly ListBox lstMonHocGoiY = new ListBox();
        private bool dangChonGoiY;

        public DangKyMonHoc()
        {
            InitializeComponent();
            ConfigureStudentSuggestions();
            ConfigureSubjectSuggestions();
            ConfigureListStatus();
            ConfigureResponsiveLayout();
            Resize += DangKyMonHoc_Resize;
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
        }

        private void ConfigureResponsiveLayout()
        {
            MinimumSize = new System.Drawing.Size(1000, 650);

            pnlHeader.Dock = DockStyle.Top;
            pnlAdvanced.Dock = DockStyle.None;
            pnlAdvanced.BringToFront();
            pnlAdvanced.WrapContents = false;
            pnlAdvanced.AutoScroll = true;
            pnlChon.Dock = DockStyle.Left;
            pnlList.Dock = DockStyle.None;
            pnlList.BringToFront();
            pnlList.Padding = new Padding(0, 0, 10, 0);

            dgvDangKy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDangKy.BorderStyle = BorderStyle.FixedSingle;
            dgvDangKy.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDangKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lblListStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnHuyDangKy.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            LayoutResponsivePanels();
        }

        private void DangKyMonHoc_Resize(object sender, EventArgs e)
        {
            LayoutResponsivePanels();
        }

        private void LayoutResponsivePanels()
        {
            if (pnlHeader == null || pnlChon == null || pnlList == null || pnlAdvanced == null) return;

            int headerHeight = pnlHeader.Height;
            int advancedHeight = pnlAdvanced.Height;
            int contentHeight = Math.Max(0, ClientSize.Height - headerHeight - advancedHeight);

            pnlAdvanced.Location = new System.Drawing.Point(0, ClientSize.Height - advancedHeight);
            pnlAdvanced.Size = new System.Drawing.Size(ClientSize.Width, advancedHeight);

            pnlChon.Location = new System.Drawing.Point(0, headerHeight);
            pnlChon.Size = new System.Drawing.Size(pnlChon.Width, contentHeight);

            pnlList.Location = new System.Drawing.Point(pnlChon.Width, headerHeight);
            pnlList.Size = new System.Drawing.Size(Math.Max(0, ClientSize.Width - pnlChon.Width), contentHeight);

            dgvDangKy.Location = new System.Drawing.Point(20, 70);
            dgvDangKy.Size = new System.Drawing.Size(Math.Max(0, pnlList.ClientSize.Width - 30), Math.Max(0, pnlList.ClientSize.Height - 90));
            btnHuyDangKy.Location = new System.Drawing.Point(Math.Max(0, pnlList.ClientSize.Width - btnHuyDangKy.Width - 15), btnHuyDangKy.Top);
        }

        private void ConfigureListStatus()
        {
            lblListStatus.AutoSize = false;
            lblListStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblListStatus.Location = new System.Drawing.Point(20, 42);
            lblListStatus.Size = new System.Drawing.Size(730, 22);
            lblListStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pnlList.Controls.Add(lblListStatus);
            lblListStatus.BringToFront();

            dgvDangKy.Location = new System.Drawing.Point(20, 70);
            dgvDangKy.Size = new System.Drawing.Size(730, 385);
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

        private void btnTheoThoiGian_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.SapXepTheoThoiGian());
            UpdateListStatus();
        }

        private void btnTheoMaSinhVien_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.SapXepTheoMaSinhVien());
            UpdateListStatus();
        }

        private void btnTheoMaMonHoc_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.SapXepTheoMaMonHoc());
            UpdateListStatus();
        }

        private void btnSinhVienSomNhat_Click(object sender, EventArgs e)
        {
            List<DangKyDisplay> rows = controller.TimSinhVienDangKySomNhat();
            RefreshGrid(rows);
            lblListStatus.Text = rows.Count == 0
                ? "Chưa có dữ liệu đăng ký."
                : "Đang hiển thị sinh viên đăng ký sớm nhất.";
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            SelectFirstRegistration();
        }

        private void btnSinhVienMuonNhat_Click(object sender, EventArgs e)
        {
            List<DangKyDisplay> rows = controller.TimSinhVienDangKyMuonNhat();
            RefreshGrid(rows);
            lblListStatus.Text = rows.Count == 0
                ? "Chưa có dữ liệu đăng ký."
                : "Đang hiển thị sinh viên đăng ký muộn nhất.";
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            SelectFirstRegistration();
        }

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

            string error;
            if (controller.Them(maSinhVien, maMonHoc, out error))
            {
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                MessageBox.Show("Đã đăng ký môn học.");
            }
            else MessageBox.Show(error, "Không thể đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            int maDangKy;
            if (!int.TryParse(txtMaDangKy.Text.Trim(), out maDangKy)) { MessageBox.Show("Vui lòng chọn bản đăng ký cần hủy."); return; }
            string error;
            if (controller.Xoa(maDangKy, out error))
            {
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                txtMaDangKy.Clear();
                MessageBox.Show("Đã xóa bản đăng ký.");
            }
            else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaSinhVien.Clear();
            txtMaMonHoc.Clear();
            txtMaDangKy.Clear();
            txtMaSinhVienTim.Clear();
            txtMaMonHocTim.Clear();
            ClearMonHocPreview();
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
            dgvDangKy.ClearSelection();
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
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
        }

        private void DangKyMonHoc_Load(object sender, EventArgs e)
        {
        }

        private void UpdateListStatus()
        {
            lblListStatus.Text = string.Format("Tổng số đăng ký: {0}", danhSachGoc.Count);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        }

        private void SelectFirstRegistration()
        {
            if (dgvDangKy.Rows.Count == 0) return;

            dgvDangKy.ClearSelection();
            dgvDangKy.CurrentCell = dgvDangKy.Rows[0].Cells[0];
            dgvDangKy.Rows[0].Selected = true;
        }

        private void lblMaSinhVienTim_Click(object sender, EventArgs e)
        {

        }

        private void dgvDangKy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
