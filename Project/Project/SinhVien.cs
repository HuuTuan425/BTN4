using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Controllers;

namespace Project
{
    public partial class SinhVien : Form
    {
        private readonly SinhVienController controller = new SinhVienController();
        private readonly DangKyMonHocController dangKyController = new DangKyMonHocController();
        private readonly Label lblListStatus = new Label();
        private List<Models.SinhVien> danhSachGoc = new List<Models.SinhVien>();
        private readonly ListBox lstSinhVienGoiY = new ListBox();
        private bool dangChonGoiY;

        public SinhVien()
        {
            InitializeComponent();
            ConfigureSearchSuggestions();
            ConfigureListStatus();
            ConfigureResponsiveLayout();
            Load += SinhVien_LayoutLoad;
            Resize += SinhVien_Resize;
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
        }

        private void ConfigureResponsiveLayout()
        {
            MinimumSize = new System.Drawing.Size(900, 600);

            pnlHeader.Dock = DockStyle.Top;
            pnlAdvanced.Dock = DockStyle.None;
            pnlInput.Dock = DockStyle.None;
            pnlList.Dock = DockStyle.None;
            pnlList.Padding = new Padding(0, 0, 10, 15);
            pnlList.BorderStyle = BorderStyle.None;
            pnlAdvanced.BringToFront();
            pnlList.BringToFront();

            dgvSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvSinhVien.BorderStyle = BorderStyle.FixedSingle;
            dgvSinhVien.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.GridColor = System.Drawing.Color.Gray;
            lblListStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstSinhVienGoiY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlList.Resize += SinhVienList_Resize;

            lblTitle.AutoSize = false;
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            pnlHeader.Resize += SinhVienHeader_Resize;
            LayoutResponsivePanels();
            LayoutGrid();
            LayoutHeaderTitle();
        }

        private void SinhVien_LayoutLoad(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(LayoutGrid));
        }

        private void SinhVien_Resize(object sender, EventArgs e)
        {
            LayoutResponsivePanels();
            LayoutGrid();
            LayoutHeaderTitle();
        }

        private void SinhVienList_Resize(object sender, EventArgs e)
        {
            LayoutGrid();
        }

        private void SinhVienHeader_Resize(object sender, EventArgs e)
        {
            LayoutHeaderTitle();
        }

        private void LayoutResponsivePanels()
        {
            if (pnlHeader == null || pnlInput == null || pnlList == null || pnlAdvanced == null) return;

            int headerHeight = pnlHeader.Height;
            int advancedHeight = pnlAdvanced.Height;
            int contentHeight = Math.Max(0, ClientSize.Height - headerHeight - advancedHeight);
            int inputWidth = pnlInput.Width;

            pnlAdvanced.Location = new System.Drawing.Point(0, ClientSize.Height - advancedHeight);
            pnlAdvanced.Size = new System.Drawing.Size(ClientSize.Width, advancedHeight);
            pnlInput.Location = new System.Drawing.Point(0, headerHeight);
            pnlInput.Size = new System.Drawing.Size(inputWidth, contentHeight);
            pnlList.Location = new System.Drawing.Point(inputWidth, headerHeight);
            pnlList.Size = new System.Drawing.Size(Math.Max(0, ClientSize.Width - inputWidth), contentHeight);
        }

        private void LayoutGrid()
        {
            if (pnlList == null || dgvSinhVien == null) return;

            dgvSinhVien.Location = new System.Drawing.Point(18, 80);
            dgvSinhVien.Size = new System.Drawing.Size(
                Math.Max(0, pnlList.ClientSize.Width - 31),
                Math.Max(0, pnlList.ClientSize.Height - dgvSinhVien.Top - 20));

            btnTimKiem.Location = new System.Drawing.Point(
                Math.Max(0, pnlList.ClientSize.Width - btnTimKiem.Width - 10),
                btnTimKiem.Top);
            txtTimKiem.Location = new System.Drawing.Point(
                Math.Max(0, btnTimKiem.Left - txtTimKiem.Width - 6),
                txtTimKiem.Top);
        }

        private void LayoutHeaderTitle()
        {
            if (pnlHeader == null || lblTitle == null) return;

            lblTitle.Location = new System.Drawing.Point(0, 0);
            lblTitle.Size = pnlHeader.ClientSize;
            lblTitle.BringToFront();
            btnBackHome.BringToFront();
            picLogo.BringToFront();
        }

        private void ConfigureListStatus()
        {
            lblListStatus.AutoSize = false;
            lblListStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblListStatus.Location = new System.Drawing.Point(18, 54);
            lblListStatus.Size = new System.Drawing.Size(740, 22);
            lblListStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pnlList.Controls.Add(lblListStatus);
            lblListStatus.BringToFront();

            dgvSinhVien.Location = new System.Drawing.Point(18, 80);
            dgvSinhVien.Size = new System.Drawing.Size(740, 397);
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
            List<Models.SinhVien> topStudents = controller.TimDangKyNhieuNhat();
            RefreshGrid(topStudents);

            int maxCourses = 0;
            var registrations = dangKyController.GetAll();
            if (registrations.Count > 0)
                maxCourses = registrations.GroupBy(x => x.MaSinhVien).Max(x => x.Count());

            lblListStatus.Text = topStudents.Count == 0
                ? "Chưa có sinh viên đăng ký môn học."
                : string.Format("Đang hiển thị các sinh viên đăng ký nhiều môn nhất ({0} môn)", maxCourses);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            SelectFirstStudent();
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
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
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
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
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                MessageBox.Show("Đã sửa họ tên sinh viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string error;
            if (controller.Xoa(txtMaSinhVien.Text, out error))
            {
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                btnLamMoi_Click(sender, e);
                MessageBox.Show("Đã xóa sinh viên và các bản đăng ký liên quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
            dgvSinhVien.ClearSelection();
            ClearInputs();
            txtMaSinhVien.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.TimGanDung(txtTimKiem.Text));
            lblListStatus.Text = string.Format("Đang hiển thị {0} sinh viên phù hợp.", dgvSinhVien.Rows.Count);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        }

        private void UpdateListStatus()
        {
            lblListStatus.Text = string.Format("Tổng số sinh viên: {0}", danhSachGoc.Count);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        }

        private void SelectFirstStudent()
        {
            if (dgvSinhVien.Rows.Count == 0) return;

            dgvSinhVien.ClearSelection();
            dgvSinhVien.CurrentCell = dgvSinhVien.Rows[0].Cells[0];
            dgvSinhVien.Rows[0].Selected = true;
        }

        private void ClearInputs()
        {
            txtMaSinhVien.Clear();
            txtHoTen.Clear();
            txtEmail.Clear();
            txtSoDienThoai.Clear();
            txtChuyenNganh.Clear();
            dtpNgaySinh.Value = DateTime.Today;
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

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
