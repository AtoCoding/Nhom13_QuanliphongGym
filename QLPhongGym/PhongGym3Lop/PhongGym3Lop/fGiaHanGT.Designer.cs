
namespace PhongGym3Lop
{
    partial class fGiaHanGT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGiaHanGT));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGiaHanMaHV = new System.Windows.Forms.TextBox();
            this.cboGiaHanGoiTap = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gói Tập";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(13, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gói tập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã hội viên:";
            // 
            // txtGiaHanMaHV
            // 
            this.txtGiaHanMaHV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtGiaHanMaHV.Location = new System.Drawing.Point(147, 57);
            this.txtGiaHanMaHV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaHanMaHV.Multiline = true;
            this.txtGiaHanMaHV.Name = "txtGiaHanMaHV";
            this.txtGiaHanMaHV.Size = new System.Drawing.Size(265, 31);
            this.txtGiaHanMaHV.TabIndex = 3;
            // 
            // cboGiaHanGoiTap
            // 
            this.cboGiaHanGoiTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.cboGiaHanGoiTap.FormattingEnabled = true;
            this.cboGiaHanGoiTap.Items.AddRange(new object[] {
            "1 tháng(Thử)",
            "3 tháng",
            "6 tháng",
            "9 tháng",
            "12 tháng(VIP)"});
            this.cboGiaHanGoiTap.Location = new System.Drawing.Point(147, 103);
            this.cboGiaHanGoiTap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboGiaHanGoiTap.Name = "cboGiaHanGoiTap";
            this.cboGiaHanGoiTap.Size = new System.Drawing.Size(265, 32);
            this.cboGiaHanGoiTap.TabIndex = 4;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(325, 145);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(88, 38);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // fGiaHanGT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 198);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cboGiaHanGoiTap);
            this.Controls.Add(this.txtGiaHanMaHV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fGiaHanGT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fGiaHanGT";
            this.Load += new System.EventHandler(this.fGiaHanGT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGiaHanMaHV;
        private System.Windows.Forms.ComboBox cboGiaHanGoiTap;
        private System.Windows.Forms.Button btnLuu;
    }
}