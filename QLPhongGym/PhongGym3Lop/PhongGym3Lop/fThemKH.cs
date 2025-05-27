using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhongGym3Lop
{
    public partial class fThemKH : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected DataGridView MyDgv;
        public fThemKH(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }



                string strQuery = "Select * FROM dbo.KhachHang";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                string MaKH = string.Empty;
                int count = 0;
                count = ds.Tables[0].Rows.Count;
                if (count < 10)
                {
                    MaKH = "KH00" + (count+1);
                }
                else if (count < 100 && count > 10)
                {
                    MaKH = "KH0" + (count+1);
                }
                else
                {
                    MaKH = "KH" + (count+1);
                }
                string query = @"INSERT INTO dbo.KhachHang (id_kh, hoten, sdt, ngaysinh, diachi)
                 VALUES (@ID, @HoTen, @SDT, @NgaySinh, @DiaChi)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", MaKH);
                cmd.Parameters.AddWithValue("@HoTen", txtThemTenKH.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtThemSDTKH.Text.Trim());
                cmd.Parameters.AddWithValue("@NgaySinh", dtpThemNgaySinhKH.Value);
                cmd.Parameters.AddWithValue("@DiaChi", txtThemDiaChiKH.Text.Trim());


                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("ĐĂNG KÝ KHÁCH HÀNG THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.KhachHang";
                SqlDataAdapter da1 = new SqlDataAdapter(strQuery1, conn);
                DataSet ds1 = new DataSet();

                da1.Fill(ds1);
                MyDgv.DataSource = ds1.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void fThemKH_Load(object sender, EventArgs e)
        {

        }

        private void txtThemTenKH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
