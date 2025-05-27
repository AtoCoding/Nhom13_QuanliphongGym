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
    public partial class fSuaTB : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected DataGridView MyDgv;
        public fSuaTB(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
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

                string strQuery = "Select * FROM dbo.ThietBi";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);

                string query = "UPDATE dbo.ThietBi SET ten=N'" + txtSuaTenTB.Text.Trim() + "',loai=@loai, soluong =N'" + txtSuaSoluongTB.Text.Trim() + "',hangsx=N'" + txtSuaHangTB.Text.Trim() + "',tinhtrang=@tinhtrang, soluonghu=N'" + txtSuaSLHu.Text.Trim() + "',ghichu= N'" + txtSuaGC.Text.Trim() + "' " + " WHERE id_tb='" + txtSuaMaTB.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@loai", cboSuaLoaiTB.Text);
                    cmd.Parameters.AddWithValue("@tinhtrang", cboSuaTinhTrangTB.Text);
                }

                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("SỬA THIẾT BỊ THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.ThietBi";
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

        private void fSuaTB_Load(object sender, EventArgs e)
        {
            txtSuaMaTB.Enabled = false;
            txtSuaMaTB.Text = fMain.SetMaTB;
            txtSuaTenTB.Text = fMain.SetTenTB;
            cboSuaLoaiTB.Text = fMain.SetLoaiTB;
            txtSuaSoluongTB.Text = fMain.SetSoLuongTB;
            txtSuaHangTB.Text = fMain.SetHangTB;
            cboSuaTinhTrangTB.Text = fMain.SetTinhTrangTB;
            txtSuaSLHu.Text = fMain.SetSoLuongHuTB;
            txtSuaGC.Text = fMain.SetGhiChu;
        }

        private void gunaGroupBox3_Click(object sender, EventArgs e)
        {

        }
    }
    
}
