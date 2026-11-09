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
            ConfigureResponsiveLayout();
            UpdateStatistics();
        }

        private void ConfigureResponsiveLayout()
        {
            MinimumSize = new Size(900, 600);

            pnlHeader.Dock = DockStyle.Top;
            pnlMenu.Dock = DockStyle.Left;
            pnlContent.Dock = DockStyle.Fill;

            btnThoat.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            btnSinhVien.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            btnMonHoc.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            btnDangKy.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            pnlCardSinhVien.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlCardMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlCardDangKy.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            pnlHeader.Resize += HomeHeader_Resize;
            HomeHeader_Resize(null, EventArgs.Empty);
        }

        private void HomeHeader_Resize(object sender, EventArgs e)
        {
            if (lblTitle == null || pnlHeader == null) return;

            lblTitle.BringToFront();
        }

        private void UpdateStatistics()
        {
            lblCardSinhVienValue.Text = new SinhVienController().GetAll().Count.ToString();
            lblCardMonHocValue.Text = new MonHocController().GetAll().Count.ToString();
            lblCardDangKyValue.Text = new DangKyMonHocController().GetAll().Count.ToString();
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

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
