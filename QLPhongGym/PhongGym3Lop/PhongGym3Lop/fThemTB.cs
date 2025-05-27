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
    public partial class fThemTB : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string imgLocation = "";
        protected DataGridView MyDgv;
        public fThemTB(DataGridView dtg)
        {
            InitializeComponent();
            MyDgv = dtg;
        }

        private void btnLuuTB_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string strQuery = "Select * FROM dbo.ThietBi";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);

                //Chuyển ảnh
                byte[] imgTB = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                imgTB = brs.ReadBytes((int)Stream.Length);

                string query = "INSERT INTO dbo.ThietBi (id_tb,ten,loai, soluong,hangsx,tinhtrang, soluonghu,ghichu, hinhanh) VALUES " +
                    "(N'" + txtThemMaTB.Text.Trim() + "' ,N'" + txtThemTenTB.Text.Trim() + "',@loai,N'" + txtThemSoLuongTB.Text.Trim() + "',N'" + txtThemHangTB.Text.Trim() + "',@tinhtrang,N'" + txtThemSoLuongHuTB.Text.Trim() + "',N'" + txtThemGhiChuTB.Text.Trim() + "',@hinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@loai", cboThemLoaiTB.Text);
                    cmd.Parameters.AddWithValue("@tinhtrang", cboThemTinhTrangTB.Text);
                    cmd.Parameters.AddWithValue("@hinhAnh", imgTB);
                }

                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("THÊM THIẾT BỊ THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.ThietBi";
                SqlDataAdapter da1 = new SqlDataAdapter(strQuery1, conn);
                DataSet ds1 = new DataSet();

                da1.Fill(ds1);
                MyDgv.DataSource = ds1.Tables[0];

                //Them

                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void picThemTB_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadImgTB = new OpenFileDialog();
            uploadImgTB.Filter = "Image Files (*.png;*.jpg;*.jpeg;..gif;)|*.png;*.jpg;*.jpeg;.*.gif";
            if (uploadImgTB.ShowDialog() == DialogResult.OK)
            {
                imgLocation = uploadImgTB.FileName.ToString();
                picThemTB.ImageLocation = imgLocation;
            }
        }

        private void gunaGroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
