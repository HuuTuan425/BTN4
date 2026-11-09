namespace Project
{
    partial class Home
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSinhVien;
        private System.Windows.Forms.Button btnMonHoc;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel pnlCardSinhVien;
        private System.Windows.Forms.Panel pnlCardMonHoc;
        private System.Windows.Forms.Panel pnlCardDangKy;
        private System.Windows.Forms.Label lblCardSinhVien;
        private System.Windows.Forms.Label lblCardMonHoc;
        private System.Windows.Forms.Label lblCardDangKy;
        private System.Windows.Forms.Label lblCardSinhVienValue;
        private System.Windows.Forms.Label lblCardMonHocValue;
        private System.Windows.Forms.Label lblCardDangKyValue;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnMonHoc = new System.Windows.Forms.Button();
            this.btnSinhVien = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblLogo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlCardDangKy = new System.Windows.Forms.Panel();
            this.lblCardDangKyValue = new System.Windows.Forms.Label();
            this.lblCardDangKy = new System.Windows.Forms.Label();
            this.pnlCardMonHoc = new System.Windows.Forms.Panel();
            this.lblCardMonHocValue = new System.Windows.Forms.Label();
            this.lblCardMonHoc = new System.Windows.Forms.Label();
            this.pnlCardSinhVien = new System.Windows.Forms.Panel();
            this.lblCardSinhVienValue = new System.Windows.Forms.Label();
            this.lblCardSinhVien = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlCardDangKy.SuspendLayout();
            this.pnlCardMonHoc.SuspendLayout();
            this.pnlCardSinhVien.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.pnlMenu.Controls.Add(this.btnThoat);
            this.pnlMenu.Controls.Add(this.btnDangKy);
            this.pnlMenu.Controls.Add(this.btnMonHoc);
            this.pnlMenu.Controls.Add(this.btnSinhVien);
            this.pnlMenu.Controls.Add(this.picLogo);
            this.pnlMenu.Controls.Add(this.lblLogo);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(303, 650);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(15, 570);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(269, 48);
            this.btnThoat.TabIndex = 0;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(59)))), ((int)(((byte)(78)))));
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.White;
            this.btnDangKy.Location = new System.Drawing.Point(15, 359);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(269, 48);
            this.btnDangKy.TabIndex = 1;
            this.btnDangKy.Text = "Đăng ký môn học";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(59)))), ((int)(((byte)(78)))));
            this.btnMonHoc.FlatAppearance.BorderSize = 0;
            this.btnMonHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonHoc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonHoc.ForeColor = System.Drawing.Color.White;
            this.btnMonHoc.Location = new System.Drawing.Point(15, 299);
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.Size = new System.Drawing.Size(269, 48);
            this.btnMonHoc.TabIndex = 2;
            this.btnMonHoc.Text = "Môn học";
            this.btnMonHoc.UseVisualStyleBackColor = false;
            this.btnMonHoc.Click += new System.EventHandler(this.btnMonHoc_Click);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(59)))), ((int)(((byte)(78)))));
            this.btnSinhVien.FlatAppearance.BorderSize = 0;
            this.btnSinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinhVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinhVien.ForeColor = System.Drawing.Color.White;
            this.btnSinhVien.Location = new System.Drawing.Point(15, 239);
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.Size = new System.Drawing.Size(269, 48);
            this.btnSinhVien.TabIndex = 3;
            this.btnSinhVien.Text = "Sinh viên";
            this.btnSinhVien.UseVisualStyleBackColor = false;
            this.btnSinhVien.Click += new System.EventHandler(this.btnSinhVien_Click);
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(111, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(80, 80);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 110);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(303, 40);
            this.lblLogo.TabIndex = 4;
            this.lblLogo.Text = "QUẢN LÝ ĐÀO TẠO";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(303, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1061, 79);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.lblTitle.Location = new System.Drawing.Point(329, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(183, 47);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Trang chủ";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlContent.Controls.Add(this.pnlCardDangKy);
            this.pnlContent.Controls.Add(this.pnlCardMonHoc);
            this.pnlContent.Controls.Add(this.pnlCardSinhVien);
            this.pnlContent.Controls.Add(this.lblDescription);
            this.pnlContent.Controls.Add(this.lblWelcome);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(303, 79);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(35);
            this.pnlContent.Size = new System.Drawing.Size(1061, 571);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // pnlCardDangKy
            // 
            this.pnlCardDangKy.BackColor = System.Drawing.Color.White;
            this.pnlCardDangKy.Controls.Add(this.lblCardDangKyValue);
            this.pnlCardDangKy.Controls.Add(this.lblCardDangKy);
            this.pnlCardDangKy.Location = new System.Drawing.Point(732, 130);
            this.pnlCardDangKy.Name = "pnlCardDangKy";
            this.pnlCardDangKy.Size = new System.Drawing.Size(250, 140);
            this.pnlCardDangKy.TabIndex = 0;
            this.pnlCardDangKy.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCardDangKy_Paint);
            // 
            // lblCardDangKyValue
            // 
            this.lblCardDangKyValue.AutoSize = true;
            this.lblCardDangKyValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblCardDangKyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblCardDangKyValue.Location = new System.Drawing.Point(18, 55);
            this.lblCardDangKyValue.Name = "lblCardDangKyValue";
            this.lblCardDangKyValue.Size = new System.Drawing.Size(54, 62);
            this.lblCardDangKyValue.TabIndex = 0;
            this.lblCardDangKyValue.Text = "0";
            // 
            // lblCardDangKy
            // 
            this.lblCardDangKy.AutoSize = true;
            this.lblCardDangKy.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCardDangKy.ForeColor = System.Drawing.Color.DimGray;
            this.lblCardDangKy.Location = new System.Drawing.Point(20, 20);
            this.lblCardDangKy.Name = "lblCardDangKy";
            this.lblCardDangKy.Size = new System.Drawing.Size(142, 25);
            this.lblCardDangKy.TabIndex = 1;
            this.lblCardDangKy.Text = "LƯỢT ĐĂNG KÝ";
            // 
            // pnlCardMonHoc
            // 
            this.pnlCardMonHoc.BackColor = System.Drawing.Color.White;
            this.pnlCardMonHoc.Controls.Add(this.lblCardMonHocValue);
            this.pnlCardMonHoc.Controls.Add(this.lblCardMonHoc);
            this.pnlCardMonHoc.Location = new System.Drawing.Point(384, 130);
            this.pnlCardMonHoc.Name = "pnlCardMonHoc";
            this.pnlCardMonHoc.Size = new System.Drawing.Size(250, 140);
            this.pnlCardMonHoc.TabIndex = 1;
            // 
            // lblCardMonHocValue
            // 
            this.lblCardMonHocValue.AutoSize = true;
            this.lblCardMonHocValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblCardMonHocValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblCardMonHocValue.Location = new System.Drawing.Point(18, 55);
            this.lblCardMonHocValue.Name = "lblCardMonHocValue";
            this.lblCardMonHocValue.Size = new System.Drawing.Size(54, 62);
            this.lblCardMonHocValue.TabIndex = 0;
            this.lblCardMonHocValue.Text = "0";
            // 
            // lblCardMonHoc
            // 
            this.lblCardMonHoc.AutoSize = true;
            this.lblCardMonHoc.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCardMonHoc.ForeColor = System.Drawing.Color.DimGray;
            this.lblCardMonHoc.Location = new System.Drawing.Point(20, 20);
            this.lblCardMonHoc.Name = "lblCardMonHoc";
            this.lblCardMonHoc.Size = new System.Drawing.Size(157, 25);
            this.lblCardMonHoc.TabIndex = 1;
            this.lblCardMonHoc.Text = "TỔNG MÔN HỌC";
            // 
            // pnlCardSinhVien
            // 
            this.pnlCardSinhVien.BackColor = System.Drawing.Color.White;
            this.pnlCardSinhVien.Controls.Add(this.lblCardSinhVienValue);
            this.pnlCardSinhVien.Controls.Add(this.lblCardSinhVien);
            this.pnlCardSinhVien.Location = new System.Drawing.Point(42, 130);
            this.pnlCardSinhVien.Name = "pnlCardSinhVien";
            this.pnlCardSinhVien.Size = new System.Drawing.Size(250, 140);
            this.pnlCardSinhVien.TabIndex = 2;
            // 
            // lblCardSinhVienValue
            // 
            this.lblCardSinhVienValue.AutoSize = true;
            this.lblCardSinhVienValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblCardSinhVienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblCardSinhVienValue.Location = new System.Drawing.Point(18, 55);
            this.lblCardSinhVienValue.Name = "lblCardSinhVienValue";
            this.lblCardSinhVienValue.Size = new System.Drawing.Size(54, 62);
            this.lblCardSinhVienValue.TabIndex = 0;
            this.lblCardSinhVienValue.Text = "0";
            // 
            // lblCardSinhVien
            // 
            this.lblCardSinhVien.AutoSize = true;
            this.lblCardSinhVien.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCardSinhVien.ForeColor = System.Drawing.Color.DimGray;
            this.lblCardSinhVien.Location = new System.Drawing.Point(20, 20);
            this.lblCardSinhVien.Name = "lblCardSinhVien";
            this.lblCardSinhVien.Size = new System.Drawing.Size(156, 25);
            this.lblCardSinhVien.TabIndex = 1;
            this.lblCardSinhVien.Text = "TỔNG SINH VIÊN";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDescription.ForeColor = System.Drawing.Color.DimGray;
            this.lblDescription.Location = new System.Drawing.Point(38, 68);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(331, 23);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Chọn một chức năng bên trái để làm việc.";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.lblWelcome.Location = new System.Drawing.Point(35, 28);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(477, 40);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Chào mừng bạn đến với hệ thống";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 650);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlMenu);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.Home_Activated);
            this.Load += new System.EventHandler(this.Home_Load);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlCardDangKy.ResumeLayout(false);
            this.pnlCardDangKy.PerformLayout();
            this.pnlCardMonHoc.ResumeLayout(false);
            this.pnlCardMonHoc.PerformLayout();
            this.pnlCardSinhVien.ResumeLayout(false);
            this.pnlCardSinhVien.PerformLayout();
            this.ResumeLayout(false);

        }

        
    }
}

