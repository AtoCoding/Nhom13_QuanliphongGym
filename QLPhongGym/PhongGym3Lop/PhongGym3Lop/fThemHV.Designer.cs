
namespace PhongGym3Lop
{
    partial class fThemHV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemHV));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.cboThemGoiTap = new Guna.UI.WinForms.GunaComboBox();
            this.rdoThemHVNu = new Guna.UI.WinForms.GunaRadioButton();
            this.rdoThemHVNam = new Guna.UI.WinForms.GunaRadioButton();
            this.btnLuuHV = new Guna.UI.WinForms.GunaGradientButton();
            this.picBoxThemHV = new Guna.UI.WinForms.GunaPictureBox();
            this.txtThemSdt = new Guna.UI.WinForms.GunaTextBox();
            this.txtThemTenHV = new Guna.UI.WinForms.GunaTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hoiVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThemHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoiVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gunaGroupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 665);
            this.panel1.TabIndex = 0;
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox1.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BorderColor = System.Drawing.Color.Maroon;
            this.gunaGroupBox1.BorderSize = 1;
            this.gunaGroupBox1.Controls.Add(this.cboThemGoiTap);
            this.gunaGroupBox1.Controls.Add(this.rdoThemHVNu);
            this.gunaGroupBox1.Controls.Add(this.rdoThemHVNam);
            this.gunaGroupBox1.Controls.Add(this.btnLuuHV);
            this.gunaGroupBox1.Controls.Add(this.picBoxThemHV);
            this.gunaGroupBox1.Controls.Add(this.txtThemSdt);
            this.gunaGroupBox1.Controls.Add(this.txtThemTenHV);
            this.gunaGroupBox1.Controls.Add(this.label5);
            this.gunaGroupBox1.Controls.Add(this.label4);
            this.gunaGroupBox1.Controls.Add(this.label3);
            this.gunaGroupBox1.Controls.Add(this.label1);
            this.gunaGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox1.LineColor = System.Drawing.Color.IndianRed;
            this.gunaGroupBox1.LineTop = 45;
            this.gunaGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.gunaGroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(479, 665);
            this.gunaGroupBox1.TabIndex = 0;
            this.gunaGroupBox1.Text = "THÊM HỘI VIÊN";
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            this.gunaGroupBox1.Click += new System.EventHandler(this.gunaGroupBox1_Click);
            // 
            // cboThemGoiTap
            // 
            this.cboThemGoiTap.BackColor = System.Drawing.Color.Transparent;
            this.cboThemGoiTap.BaseColor = System.Drawing.Color.White;
            this.cboThemGoiTap.BorderColor = System.Drawing.Color.Silver;
            this.cboThemGoiTap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboThemGoiTap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboThemGoiTap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThemGoiTap.FocusedColor = System.Drawing.Color.Empty;
            this.cboThemGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThemGoiTap.ForeColor = System.Drawing.Color.Black;
            this.cboThemGoiTap.FormattingEnabled = true;
            this.cboThemGoiTap.ItemHeight = 25;
            this.cboThemGoiTap.Items.AddRange(new object[] {
            "1 Tháng (Thử)",
            "3 Tháng",
            "6 Tháng",
            "9 Tháng",
            "12 Tháng (VIP)"});
            this.cboThemGoiTap.Location = new System.Drawing.Point(212, 535);
            this.cboThemGoiTap.Margin = new System.Windows.Forms.Padding(4);
            this.cboThemGoiTap.Name = "cboThemGoiTap";
            this.cboThemGoiTap.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cboThemGoiTap.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cboThemGoiTap.Radius = 3;
            this.cboThemGoiTap.Size = new System.Drawing.Size(229, 31);
            this.cboThemGoiTap.TabIndex = 56;
            // 
            // rdoThemHVNu
            // 
            this.rdoThemHVNu.BaseColor = System.Drawing.SystemColors.Control;
            this.rdoThemHVNu.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdoThemHVNu.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.rdoThemHVNu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoThemHVNu.FillColor = System.Drawing.Color.White;
            this.rdoThemHVNu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.rdoThemHVNu.ForeColor = System.Drawing.Color.Black;
            this.rdoThemHVNu.Location = new System.Drawing.Point(317, 439);
            this.rdoThemHVNu.Margin = new System.Windows.Forms.Padding(4);
            this.rdoThemHVNu.Name = "rdoThemHVNu";
            this.rdoThemHVNu.Size = new System.Drawing.Size(57, 25);
            this.rdoThemHVNu.TabIndex = 55;
            this.rdoThemHVNu.Text = "Nữ";
            // 
            // rdoThemHVNam
            // 
            this.rdoThemHVNam.BaseColor = System.Drawing.SystemColors.Control;
            this.rdoThemHVNam.CheckedOffColor = System.Drawing.Color.Gray;
            this.rdoThemHVNam.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.rdoThemHVNam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoThemHVNam.FillColor = System.Drawing.Color.White;
            this.rdoThemHVNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.rdoThemHVNam.ForeColor = System.Drawing.Color.Black;
            this.rdoThemHVNam.Location = new System.Drawing.Point(221, 439);
            this.rdoThemHVNam.Margin = new System.Windows.Forms.Padding(4);
            this.rdoThemHVNam.Name = "rdoThemHVNam";
            this.rdoThemHVNam.Size = new System.Drawing.Size(73, 25);
            this.rdoThemHVNam.TabIndex = 54;
            this.rdoThemHVNam.Text = "Nam";
            // 
            // btnLuuHV
            // 
            this.btnLuuHV.AnimationHoverSpeed = 0.07F;
            this.btnLuuHV.AnimationSpeed = 0.03F;
            this.btnLuuHV.BackColor = System.Drawing.Color.Transparent;
            this.btnLuuHV.BaseColor1 = System.Drawing.Color.DimGray;
            this.btnLuuHV.BaseColor2 = System.Drawing.Color.DarkGray;
            this.btnLuuHV.BorderColor = System.Drawing.Color.Black;
            this.btnLuuHV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuHV.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLuuHV.FocusedColor = System.Drawing.Color.Empty;
            this.btnLuuHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuHV.ForeColor = System.Drawing.Color.White;
            this.btnLuuHV.Image = ((System.Drawing.Image)(resources.GetObject("btnLuuHV.Image")));
            this.btnLuuHV.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLuuHV.ImageSize = new System.Drawing.Size(25, 25);
            this.btnLuuHV.Location = new System.Drawing.Point(105, 596);
            this.btnLuuHV.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuuHV.Name = "btnLuuHV";
            this.btnLuuHV.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLuuHV.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.btnLuuHV.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLuuHV.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLuuHV.OnHoverImage = null;
            this.btnLuuHV.OnPressedColor = System.Drawing.Color.Black;
            this.btnLuuHV.Radius = 3;
            this.btnLuuHV.Size = new System.Drawing.Size(285, 52);
            this.btnLuuHV.TabIndex = 53;
            this.btnLuuHV.Text = "LƯU";
            this.btnLuuHV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLuuHV.Click += new System.EventHandler(this.btnLuuHV_Click);
            // 
            // picBoxThemHV
            // 
            this.picBoxThemHV.BackColor = System.Drawing.Color.Black;
            this.picBoxThemHV.BaseColor = System.Drawing.Color.Black;
            this.picBoxThemHV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxThemHV.Location = new System.Drawing.Point(105, 66);
            this.picBoxThemHV.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxThemHV.Name = "picBoxThemHV";
            this.picBoxThemHV.Size = new System.Drawing.Size(279, 289);
            this.picBoxThemHV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxThemHV.TabIndex = 52;
            this.picBoxThemHV.TabStop = false;
            this.picBoxThemHV.Click += new System.EventHandler(this.picBoxThemHV_Click);
            // 
            // txtThemSdt
            // 
            this.txtThemSdt.BackColor = System.Drawing.Color.Transparent;
            this.txtThemSdt.BaseColor = System.Drawing.Color.White;
            this.txtThemSdt.BorderColor = System.Drawing.Color.Silver;
            this.txtThemSdt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThemSdt.FocusedBaseColor = System.Drawing.Color.White;
            this.txtThemSdt.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtThemSdt.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtThemSdt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThemSdt.ForeColor = System.Drawing.Color.Black;
            this.txtThemSdt.Location = new System.Drawing.Point(212, 487);
            this.txtThemSdt.Margin = new System.Windows.Forms.Padding(4);
            this.txtThemSdt.Name = "txtThemSdt";
            this.txtThemSdt.PasswordChar = '\0';
            this.txtThemSdt.Radius = 3;
            this.txtThemSdt.SelectedText = "";
            this.txtThemSdt.Size = new System.Drawing.Size(231, 39);
            this.txtThemSdt.TabIndex = 49;
            // 
            // txtThemTenHV
            // 
            this.txtThemTenHV.BackColor = System.Drawing.Color.Transparent;
            this.txtThemTenHV.BaseColor = System.Drawing.Color.White;
            this.txtThemTenHV.BorderColor = System.Drawing.Color.Silver;
            this.txtThemTenHV.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtThemTenHV.FocusedBaseColor = System.Drawing.Color.White;
            this.txtThemTenHV.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtThemTenHV.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtThemTenHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThemTenHV.ForeColor = System.Drawing.Color.Black;
            this.txtThemTenHV.Location = new System.Drawing.Point(212, 386);
            this.txtThemTenHV.Margin = new System.Windows.Forms.Padding(4);
            this.txtThemTenHV.Name = "txtThemTenHV";
            this.txtThemTenHV.PasswordChar = '\0';
            this.txtThemTenHV.Radius = 3;
            this.txtThemTenHV.SelectedText = "";
            this.txtThemTenHV.Size = new System.Drawing.Size(231, 39);
            this.txtThemTenHV.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 537);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 24);
            this.label5.TabIndex = 45;
            this.label5.Text = "Gói tập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(37, 491);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 24);
            this.label4.TabIndex = 44;
            this.label4.Text = "Số điện thoại:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 438);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 24);
            this.label3.TabIndex = 43;
            this.label3.Text = "Giới tính:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 386);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 42;
            this.label1.Text = "Họ tên:";
            // 
            // hoiVienBindingSource
            // 
            this.hoiVienBindingSource.DataMember = "HoiVien";
            // 
            // fThemHV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 665);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fThemHV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm hội viên";
            this.Load += new System.EventHandler(this.fThemHV_Load);
            this.panel1.ResumeLayout(false);
            this.gunaGroupBox1.ResumeLayout(false);
            this.gunaGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxThemHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoiVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource hoiVienBindingSource;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI.WinForms.GunaComboBox cboThemGoiTap;
        private Guna.UI.WinForms.GunaRadioButton rdoThemHVNu;
        private Guna.UI.WinForms.GunaRadioButton rdoThemHVNam;
        private Guna.UI.WinForms.GunaGradientButton btnLuuHV;
        private Guna.UI.WinForms.GunaPictureBox picBoxThemHV;
        private Guna.UI.WinForms.GunaTextBox txtThemSdt;
        private Guna.UI.WinForms.GunaTextBox txtThemTenHV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}