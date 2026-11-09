using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Controllers;

namespace Project
{
    public partial class MonHoc : Form
    {
        private readonly MonHocController controller = new MonHocController();
        private readonly DangKyMonHocController dangKyController = new DangKyMonHocController();
        private readonly Label lblListStatus = new Label();
        private List<Models.MonHoc> danhSachGoc = new List<Models.MonHoc>();
        private readonly ListBox lstMonHocGoiY = new ListBox();
        private bool dangChonGoiY;

        public MonHoc()
        {
            InitializeComponent();
            ConfigureSearchSuggestions();
            ConfigureListStatus();
            ConfigureResponsiveLayout();
            Load += MonHoc_LayoutLoad;
            Resize += MonHoc_Resize;
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
        }

        private void ConfigureResponsiveLayout()
        {
            MinimumSize = new System.Drawing.Size(900, 600);

            pnlHeader.Dock = DockStyle.Top;
            pnlAdvanced.Dock = DockStyle.None;
            pnlInput.Dock = DockStyle.Left;
            pnlInput.Dock = DockStyle.None;
            pnlList.Dock = DockStyle.None;
            pnlList.Padding = new Padding(0, 0, 10, 15);
            pnlList.BorderStyle = BorderStyle.None;
            pnlAdvanced.BringToFront();
            pnlList.BringToFront();

            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.GridColor = System.Drawing.Color.Gray;
            lblListStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lstMonHocGoiY.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlList.Resize += MonHocList_Resize;

            lblTitle.AutoSize = false;
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            pnlHeader.Resize += MonHocHeader_Resize;
            LayoutResponsivePanels();
            LayoutGrid();
            LayoutHeaderTitle();
        }

        private void MonHoc_LayoutLoad(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(LayoutGrid));
        }

        private void MonHoc_Resize(object sender, EventArgs e)
        {
            LayoutResponsivePanels();
            LayoutGrid();
            LayoutHeaderTitle();
        }

        private void MonHocList_Resize(object sender, EventArgs e)
        {
            LayoutGrid();
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

        private void MonHocHeader_Resize(object sender, EventArgs e)
        {
            LayoutHeaderTitle();
        }

        private void LayoutGrid()
        {
            if (pnlList == null || dgv == null) return;

            dgv.Location = new System.Drawing.Point(3, 80);
            dgv.Size = new System.Drawing.Size(
                Math.Max(0, pnlList.ClientSize.Width - 13),
                Math.Max(0, pnlList.ClientSize.Height - dgv.Top - 20));

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
            lblListStatus.Location = new System.Drawing.Point(3, 54);
            lblListStatus.Size = new System.Drawing.Size(677, 22);
            lblListStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            pnlList.Controls.Add(lblListStatus);
            lblListStatus.BringToFront();

            dgv.Location = new System.Drawing.Point(3, 80);
            dgv.Size = new System.Drawing.Size(677, 365);
        }

        private void ConfigureSearchSuggestions()
        {
            lstMonHocGoiY.Location = new System.Drawing.Point(txtTimKiem.Left, txtTimKiem.Bottom);
            lstMonHocGoiY.Size = new System.Drawing.Size(txtTimKiem.Width, 150);
            lstMonHocGoiY.Font = txtTimKiem.Font;
            lstMonHocGoiY.Visible = false;
            lstMonHocGoiY.IntegralHeight = false;
            lstMonHocGoiY.FormattingEnabled = true;
            lstMonHocGoiY.Format += lstMonHocGoiY_Format;
            lstMonHocGoiY.MouseClick += lstMonHocGoiY_MouseClick;
            lstMonHocGoiY.KeyDown += lstMonHocGoiY_KeyDown;
            pnlList.Controls.Add(lstMonHocGoiY);
            lstMonHocGoiY.BringToFront();
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dangChonGoiY) return;

            string ten = txtTimKiem.Text.Trim();
            if (string.IsNullOrWhiteSpace(ten))
            {
                lstMonHocGoiY.Visible = false;
                return;
            }

            var monHoc = controller.TimTenBatDau(ten);
            lstMonHocGoiY.DataSource = monHoc;
            lstMonHocGoiY.Visible = monHoc.Count > 0;
            if (lstMonHocGoiY.Visible) lstMonHocGoiY.BringToFront();
        }

        private void lstMonHocGoiY_Format(object sender, ListControlConvertEventArgs e)
        {
            Models.MonHoc monHoc = e.ListItem as Models.MonHoc;
            if (monHoc != null) e.Value = monHoc.TenMonHoc + " - " + monHoc.MaMonHoc;
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
            txtTimKiem.Text = monHoc.TenMonHoc;
            txtTimKiem.SelectionStart = txtTimKiem.TextLength;
            dangChonGoiY = false;
            lstMonHocGoiY.Visible = false;
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshGrid(object data)
        {
            dgv.DataSource = null;
            dgv.DataSource = data;

            if (dgv.Columns.Count > 0)
            {
                dgv.Columns["MaMonHoc"].HeaderText = "Mã môn";
                dgv.Columns["TenMonHoc"].HeaderText = "Tên môn học";
                dgv.Columns["SoTinChi"].HeaderText = "Số tín chỉ";
                dgv.Columns["SoTietHoc"].HeaderText = "Số tiết học";
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            string error;
            if (controller.Them(txtTen.Text, (int)nudTinChi.Value, (int)nudSoTiet.Value, out error))
            {
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                ClearInputs();
                MessageBox.Show("Đã thêm môn học.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(txtMa.Text, out ma)) { MessageBox.Show("Chọn môn học cần sửa."); return; }
            string error;
            if (controller.SuaSoTiet(ma, txtTen.Text, (int)nudTinChi.Value, (int)nudSoTiet.Value, out error))
            {
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                MessageBox.Show("Đã sửa thông tin môn học.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể sửa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int ma;
            if (!int.TryParse(txtMa.Text, out ma)) { MessageBox.Show("Chọn môn học cần xóa."); return; }
            string error;
            if (controller.Xoa(ma, out error))
            {
                danhSachGoc = controller.GetAll();
                RefreshGrid(danhSachGoc);
                UpdateListStatus();
                ClearInputs();
                MessageBox.Show("Đã xóa môn học và đăng ký liên quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.TimGanDung(txtTimKiem.Text));
            lblListStatus.Text = string.Format("Đang hiển thị {0} môn học phù hợp.", dgv.Rows.Count);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            danhSachGoc = controller.GetAll();
            RefreshGrid(danhSachGoc);
            UpdateListStatus();
            dgv.ClearSelection();
            ClearInputs();
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.SapXepTheoTinChi());
            lblListStatus.Text = "Đang hiển thị môn học theo số tín chỉ giảm dần.";
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        }

        private void Statistics_Click(object sender, EventArgs e)
        {
            List<Models.MonHoc> subjects = controller.TimDangKyNhieuNhat();
            var registrations = dangKyController.GetAll();
            int maxRegistrations = registrations.Count == 0
                ? 0
                : registrations.GroupBy(x => x.MaMonHoc).Max(x => x.Count());

            RefreshGrid(subjects);
            lblListStatus.Text = subjects.Count == 0
                ? "Chưa có môn học được đăng ký."
                : string.Format("Đang hiển thị các môn học được đăng ký nhiều nhất ({0} lượt đăng ký)", maxRegistrations);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            SelectFirstSubject();
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            Models.MonHoc monHoc = dgv.SelectedRows[0].DataBoundItem as Models.MonHoc;
            if (monHoc == null) return;
            txtMa.Text = monHoc.MaMonHoc.ToString();
            txtTen.Text = monHoc.TenMonHoc;
            nudTinChi.Value = monHoc.SoTinChi;
            nudSoTiet.Value = monHoc.SoTietHoc;
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgv.HitTest(e.X, e.Y).RowIndex >= 0) return;

            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void ClearInputs()
        {
            txtMa.Clear();
            txtTen.Clear();
            nudTinChi.Value = 1;
            nudSoTiet.Value = 15;
        }

        private void UpdateListStatus()
        {
            lblListStatus.Text = string.Format("Tổng số môn học: {0}", danhSachGoc.Count);
            lblListStatus.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
        }

        private void SelectFirstSubject()
        {
            if (dgv.Rows.Count == 0) return;

            dgv.ClearSelection();
            dgv.CurrentCell = dgv.Rows[0].Cells[0];
            dgv.Rows[0].Selected = true;
        }

        private void lblListTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
