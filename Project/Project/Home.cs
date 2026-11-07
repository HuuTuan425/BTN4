using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            lblCardSinhVienValue.Text = AppData.SinhViens.Count.ToString();
            lblCardMonHocValue.Text = AppData.MonHocs.Count.ToString();
            lblCardDangKyValue.Text = AppData.DangKys.Count.ToString();
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            UpdateStatistics();
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            using (SinhVien form = new SinhVien())
            {
                form.ShowDialog(this);
            }
        }

        private void btnMonHoc_Click(object sender, EventArgs e)
        {
            using (MonHoc form = new MonHoc())
            {
                form.ShowDialog(this);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (DangKyMonHoc form = new DangKyMonHoc())
            {
                form.ShowDialog(this);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pnlCardDangKy_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
