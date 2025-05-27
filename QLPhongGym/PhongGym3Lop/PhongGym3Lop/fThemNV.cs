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
    public partial class fThemNV : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string imgLocation = "";
        protected DataGridView MyDgv;
        public fThemNV(DataGridView dgvNV)
        {
            InitializeComponent();
            MyDgv = dgvNV;
        }

        private void picThemNV_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadImgHV = new OpenFileDialog();
            uploadImgHV.Filter = "Image Files (*.png;*.jpg;*.jpeg;..gif;)|*.png;*.jpg;*.jpeg;.*.gif";
            if (uploadImgHV.ShowDialog() == DialogResult.OK)
            {
                imgLocation = uploadImgHV.FileName.ToString();
                picThemNV.ImageLocation = imgLocation;
            }
        }

        private void btnLuuNV_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                //Hàm tăng tự động mã hội viên

                string strQuery = "Select * FROM dbo.NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                string MaNV = string.Empty;
                int count = 0;
                count = ds.Tables[0].Rows.Count;
                if (count < 10)
                {
                    MaNV = "NV00" + (count+1);
                }
                else if (count < 100 && count > 10)
                {
                    MaNV = "NV0" + (count+1);
                }
                else
                {
                    MaNV = "NV" + (count+1);
                }


                //Hàm radio giới tính

                string gender = string.Empty;
                if (rboThemNVNam.Checked)
                {
                    gender = "Nam";
                }
                else if (rboThemNVNam.Checked)
                {
                    gender = "Nữ";
                }

                string vitri = string.Empty;
                if (cboThemVTNV.Text == "PT")
                {
                    vitri = "PT";
                }
                else if (cboThemVTNV.Text == "Lễ tân")
                {
                    vitri = "Lễ tân";
                }
                //Chuyển ảnh

                byte[] imgHV = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                imgHV = brs.ReadBytes((int)Stream.Length);

                //Them


                string query = "INSERT INTO dbo.NhanVien (id_nv,hoten,gioitinh, sdt, socc, vitri,hinhanh) VALUES (@ID , N'" + txtThemTenNV.Text.Trim() + "',@Gender,'" + txtThemSdtNV.Text.Trim() + "','" + txtThemSoCCNV.Text.Trim() + "', @ViTri,@HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ID", MaNV);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ViTri", vitri);
                    cmd.Parameters.AddWithValue("@HinhAnh", imgHV);
                }

                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("ĐĂNG KÝ NHÂN VIÊN THÀNH CÔNG!");
                string strQueryNV = "Select * FROM dbo.NhanVien";
                SqlDataAdapter daNV = new SqlDataAdapter(strQueryNV, conn);
                DataSet dsNV = new DataSet();

                daNV.Fill(dsNV);
                MyDgv.DataSource = dsNV.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void gunaGroupBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
