using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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
            Close();
        }
    }
}
