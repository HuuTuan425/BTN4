using System;
using System.Linq;
using System.Windows.Forms;
using Controllers;

namespace Project
{
    public partial class MonHoc : Form
    {
        private readonly MonHocController controller = new MonHocController();
        private readonly ListBox lstMonHocGoiY = new ListBox();
        private bool dangChonGoiY;

        public MonHoc()
        {
            InitializeComponent();
            ConfigureSearchSuggestions();
            RefreshGrid(controller.GetAll());
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
                RefreshGrid(controller.GetAll());
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
                RefreshGrid(controller.GetAll());
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
                RefreshGrid(controller.GetAll());
                ClearInputs();
                MessageBox.Show("Đã xóa môn học và đăng ký liên quan.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(error, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Search_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.TimGanDung(txtTimKiem.Text));
        }

        private void btnHienThiTatCa_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            RefreshGrid(controller.GetAll());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            RefreshGrid(controller.SapXepTheoTinChi());
        }

        private void Statistics_Click(object sender, EventArgs e)
        {
            var subjects = controller.TimDangKyNhieuNhat();
            MessageBox.Show(subjects.Count == 0 ? "Chưa có dữ liệu." : string.Join(Environment.NewLine, subjects.Select(x => x.MaMonHoc + " - " + x.TenMonHoc)), "Môn học đăng ký nhiều nhất");
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
