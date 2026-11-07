namespace Project
{
    partial class MonHoc
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlAdvanced;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInputTitle;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblTinChi;
        private System.Windows.Forms.Label lblSoTiet;
        private System.Windows.Forms.Button btnBackHome;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.NumericUpDown nudTinChi;
        private System.Windows.Forms.NumericUpDown nudSoTiet;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnSapXep;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DataGridView dgv;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBackHome = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.lblInputTitle = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblTinChi = new System.Windows.Forms.Label();
            this.lblSoTiet = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.nudTinChi = new System.Windows.Forms.NumericUpDown();
            this.nudSoTiet = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlList = new System.Windows.Forms.Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlAdvanced = new System.Windows.Forms.Panel();
            this.btnSapXep = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTinChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTiet)).BeginInit();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnBackHome);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1100, 83);
            this.pnlHeader.TabIndex = 2;
            // 
            // btnBackHome
            // 
            this.btnBackHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBackHome.FlatAppearance.BorderSize = 0;
            this.btnBackHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackHome.ForeColor = System.Drawing.Color.White;
            this.btnBackHome.Location = new System.Drawing.Point(21, 12);
            this.btnBackHome.Name = "btnBackHome";
            this.btnBackHome.Size = new System.Drawing.Size(67, 55);
            this.btnBackHome.TabIndex = 3;
            this.btnBackHome.Text = "⬅";
            this.btnBackHome.UseVisualStyleBackColor = false;
            this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(45)))), ((int)(((byte)(61)))));
            this.lblTitle.Location = new System.Drawing.Point(428, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản lý môn học";
            // 
            // pnlInput
            // 
            this.pnlInput.BackColor = System.Drawing.Color.White;
            this.pnlInput.Controls.Add(this.lblInputTitle);
            this.pnlInput.Controls.Add(this.lblMa);
            this.pnlInput.Controls.Add(this.lblTen);
            this.pnlInput.Controls.Add(this.lblTinChi);
            this.pnlInput.Controls.Add(this.lblSoTiet);
            this.pnlInput.Controls.Add(this.txtMa);
            this.pnlInput.Controls.Add(this.txtTen);
            this.pnlInput.Controls.Add(this.nudTinChi);
            this.pnlInput.Controls.Add(this.nudSoTiet);
            this.pnlInput.Controls.Add(this.btnThem);
            this.pnlInput.Controls.Add(this.btnSua);
            this.pnlInput.Controls.Add(this.btnXoa);
            this.pnlInput.Location = new System.Drawing.Point(21, 108);
            this.pnlInput.Name = "pnlInput";
            this.pnlInput.Size = new System.Drawing.Size(333, 482);
            this.pnlInput.TabIndex = 1;
            // 
            // lblInputTitle
            // 
            this.lblInputTitle.AutoSize = true;
            this.lblInputTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblInputTitle.Location = new System.Drawing.Point(20, 18);
            this.lblInputTitle.Name = "lblInputTitle";
            this.lblInputTitle.Size = new System.Drawing.Size(208, 30);
            this.lblInputTitle.TabIndex = 0;
            this.lblInputTitle.Text = "Thông tin môn học";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa.Location = new System.Drawing.Point(20, 75);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(107, 22);
            this.lblMa.TabIndex = 1;
            this.lblMa.Text = "Mã môn học";
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.Location = new System.Drawing.Point(20, 135);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(115, 22);
            this.lblTen.TabIndex = 2;
            this.lblTen.Text = "Tên môn học";
            // 
            // lblTinChi
            // 
            this.lblTinChi.AutoSize = true;
            this.lblTinChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinChi.Location = new System.Drawing.Point(20, 195);
            this.lblTinChi.Name = "lblTinChi";
            this.lblTinChi.Size = new System.Drawing.Size(84, 22);
            this.lblTinChi.TabIndex = 3;
            this.lblTinChi.Text = "Số tín chỉ";
            // 
            // lblSoTiet
            // 
            this.lblSoTiet.AutoSize = true;
            this.lblSoTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoTiet.Location = new System.Drawing.Point(20, 255);
            this.lblSoTiet.Name = "lblSoTiet";
            this.lblSoTiet.Size = new System.Drawing.Size(95, 22);
            this.lblSoTiet.TabIndex = 4;
            this.lblSoTiet.Text = "Số tiết học";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(141, 77);
            this.txtMa.Name = "txtMa";
            this.txtMa.ReadOnly = true;
            this.txtMa.Size = new System.Drawing.Size(175, 22);
            this.txtMa.TabIndex = 5;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(141, 135);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(175, 22);
            this.txtTen.TabIndex = 6;
            // 
            // nudTinChi
            // 
            this.nudTinChi.Location = new System.Drawing.Point(141, 195);
            this.nudTinChi.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudTinChi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTinChi.Name = "nudTinChi";
            this.nudTinChi.Size = new System.Drawing.Size(175, 22);
            this.nudTinChi.TabIndex = 7;
            this.nudTinChi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudSoTiet
            // 
            this.nudSoTiet.Location = new System.Drawing.Point(141, 255);
            this.nudSoTiet.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudSoTiet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoTiet.Name = "nudSoTiet";
            this.nudSoTiet.Size = new System.Drawing.Size(175, 22);
            this.nudSoTiet.TabIndex = 8;
            this.nudSoTiet.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 330);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(85, 35);
            this.btnThem.TabIndex = 9;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.Add_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.ForeColor = System.Drawing.Color.White;
            this.btnSua.Location = new System.Drawing.Point(124, 330);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 35);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa tiết";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.Edit_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(231, 330);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 35);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.Delete_Click);
            // 
            // pnlList
            // 
            this.pnlList.BackColor = System.Drawing.Color.White;
            this.pnlList.Controls.Add(this.lblListTitle);
            this.pnlList.Controls.Add(this.txtTimKiem);
            this.pnlList.Controls.Add(this.btnTimKiem);
            this.pnlList.Controls.Add(this.dgv);
            this.pnlList.Location = new System.Drawing.Point(370, 108);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(700, 482);
            this.pnlList.TabIndex = 0;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.Location = new System.Drawing.Point(20, 18);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(214, 30);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách môn học";
            this.lblListTitle.Click += new System.EventHandler(this.lblListTitle_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(328, 24);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 22);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(595, 18);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 30);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.Search_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Location = new System.Drawing.Point(20, 65);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(660, 385);
            this.dgv.TabIndex = 3;
            this.dgv.SelectionChanged += new System.EventHandler(this.Dgv_SelectionChanged);
            // 
            // pnlAdvanced
            // 
            this.pnlAdvanced.BackColor = System.Drawing.Color.White;
            this.pnlAdvanced.Controls.Add(this.btnSapXep);
            this.pnlAdvanced.Controls.Add(this.btnThongKe);
            this.pnlAdvanced.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAdvanced.Location = new System.Drawing.Point(0, 605);
            this.pnlAdvanced.Name = "pnlAdvanced";
            this.pnlAdvanced.Size = new System.Drawing.Size(1100, 45);
            this.pnlAdvanced.TabIndex = 3;
            // 
            // btnSapXep
            // 
            this.btnSapXep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSapXep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSapXep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSapXep.ForeColor = System.Drawing.Color.White;
            this.btnSapXep.Location = new System.Drawing.Point(12, 3);
            this.btnSapXep.Name = "btnSapXep";
            this.btnSapXep.Size = new System.Drawing.Size(170, 39);
            this.btnSapXep.TabIndex = 0;
            this.btnSapXep.Text = "Sắp xếp tín chỉ giảm";
            this.btnSapXep.UseVisualStyleBackColor = false;
            this.btnSapXep.Click += new System.EventHandler(this.Sort_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(200, 3);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(190, 39);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Môn đăng ký nhiều nhất";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.Statistics_Click);
            // 
            // MonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlAdvanced);
            this.Name = "MonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý môn học";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInput.ResumeLayout(false);
            this.pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTinChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTiet)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}