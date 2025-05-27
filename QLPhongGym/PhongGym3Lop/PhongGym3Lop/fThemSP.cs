using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhongGym3Lop
{
    public partial class fThemSP : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string imgLocation = "";
        protected DataGridView MyDgvSP;
        public fThemSP(DataGridView dgv)
        {
            InitializeComponent();
            txtTenSP.Enabled = true;
            txtMaSP.Enabled = true;
            MyDgvSP = dgv;
        }

        private void fThemSP_Load(object sender, EventArgs e)
        {
        }

        private void gunaGroupBox2_Click(object sender, EventArgs e)
        {

        }



        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();

                }

                //Hàm tăng tự động mã hội viên

                string strQuery = "Select * FROM dbo.SanPham";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);

                DateTime dateValue = DateTime.Now; ;
                DateTime date = DateTime.Now;


                //Chuyển ảnh

                byte[] imgHV = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                imgHV = brs.ReadBytes((int)Stream.Length);

                //Them


                string query = "INSERT INTO dbo.SanPham (id_sp, ten, loai, ngaynhap, soluong, dongia, trongluong, hangsx, tinhtrang, hinhanh) VALUES (@ID ,N'" + txtTenSP.Text.Trim() + "',@Loai , @NgayNhap,N'" + txtSoLuongSP.Text.Trim() + "','" + txtDonGiaSP.Text.Trim() + "','" + txtTrongLuongSP.Text.Trim() + "',N'" + txtHangSXSP.Text.Trim() + "',@Tinhtrang,@HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ID", txtMaSP.Text);
                    cmd.Parameters.AddWithValue("@Loai", cboLoaiSP.Text);
                    cmd.Parameters.AddWithValue("@NgayNhap", date);
                    cmd.Parameters.AddWithValue("@HinhAnh", imgHV);
                    cmd.Parameters.AddWithValue("@Tinhtrang", cboTinhTrangSP.Text);
                }

                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("THÊM SẢN PHẨM THÀNH CÔNG!");
                string strQuerySP = "Select * FROM dbo.SanPham";
                SqlDataAdapter daSP = new SqlDataAdapter(strQuerySP, conn);
                DataSet dsSP = new DataSet();

                daSP.Fill(dsSP);
                MyDgvSP.DataSource = dsSP.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void picBoxSP_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadImgSP = new OpenFileDialog();
            uploadImgSP.Filter = "Image Files (*.png;*.jpg;*.jpeg;..gif;)|*.png;*.jpg;*.jpeg;.*.gif";
            if (uploadImgSP.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = uploadImgSP.FileName.ToString();
                    picBoxSP.ImageLocation = imgLocation;
                }
        }

        private void sanPhamBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void sanPhamBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
        }
    }
}
