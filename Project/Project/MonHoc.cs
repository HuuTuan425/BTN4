using System;
using System.Linq;
using System.Windows.Forms;
using Controllers;

namespace Project
{
    public partial class MonHoc : Form
    {
        private readonly MonHocController controller = new MonHocController();

        public MonHoc()
        {
            InitializeComponent();
            RefreshGrid(controller.GetAll());
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
            if (controller.SuaSoTiet(ma, (int)nudSoTiet.Value, out error))
            {
                RefreshGrid(controller.GetAll());
                MessageBox.Show("Đã sửa số tiết học.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
