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
    public partial class fSuaKH : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected DataGridView MyDgv;
        public fSuaKH(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                //Sua


                string query = "UPDATE dbo.KhachHang set hoten=N'" + txtSuaTenKH.Text +"', ngaysinh= '"+ Convert.ToDateTime(dtpSuaNgaySinhKH.Value).ToString("yyyy-MM-dd") + "', sdt='" + txtSuaSDTKH.Text + "', diachi = '" + txtSuaDiaChiKH.Text + "' WHERE id_kh='" + txtSuaMaKH.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;  
                }

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("SỬA KHÁCH HÀNG THÀNH CÔNG!");
                string strQuerykh = "Select * FROM dbo.KhachHang";
                SqlDataAdapter dakh = new SqlDataAdapter(strQuerykh, conn);
                DataSet dskh = new DataSet();

                dakh.Fill(dskh);
                MyDgv.DataSource = dskh.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }

        private void fSuaKH_Leave(object sender, EventArgs e)
        {

        }

        private void fSuaKH_Load(object sender, EventArgs e)
        {
            txtSuaMaKH.Enabled = false;
            txtSuaMaKH.Text = fMain.SetMaKH;
            txtSuaTenKH.Text = fMain.SetTenKH;
            dtpSuaNgaySinhKH.Value = fMain.SetNgaySinh;
            txtSuaSDTKH.Text = fMain.SetSdtKH;
            txtSuaDiaChiKH.Text = fMain.SetDiaChiKH;
        }
    }
}
