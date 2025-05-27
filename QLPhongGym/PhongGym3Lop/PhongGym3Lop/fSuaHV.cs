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
    
    public partial class fSuaHV : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected DataGridView MyDgv;
        public fSuaHV(DataGridView dtg)
        {
            InitializeComponent();
            MyDgv = dtg;
        }

        private void fSuaHV_Load(object sender, EventArgs e)
        {
            txtMaHV.Enabled = false;
            txtMaHV.Text = fMain.SetMaHV;
            txtSuaTenHV.Text = fMain.SetTenHV;
            txtSuaSdt.Text = fMain.SetSdtHV;
            if (fMain.SetGioiTinhHV == "Nam")
            {
                rdoSuaHVNam.Checked = true;
            }
            else if (fMain.SetGioiTinhHV == "Nữ")
            {
                rdoSuaHVNu.Checked = true;
            }
            cboSuaGoiTap.Text = fMain.SetGoiTap;
        }

        private void btnLuuHV_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                //Hàm radio giới tính

                string gender = string.Empty;
                if (rdoSuaHVNam.Checked)
                {
                    gender = "Nam";
                }
                else if (rdoSuaHVNu.Checked)
                {
                    gender = "Nữ";
                }

                //Hàm hết hạn

                DateTime dateValue = DateTime.Now; ;
                DateTime date = DateTime.Now;


                if (cboSuaGoiTap.Text == "1 tháng( Thử)")
                {
                    date = dateValue.AddMonths(1);
                }
                else if (cboSuaGoiTap.Text == "3 tháng")
                {
                    date = dateValue.AddMonths(3);
                }
                else if (cboSuaGoiTap.Text == "6 tháng")
                {
                    date = dateValue.AddMonths(6);
                }
                else if (cboSuaGoiTap.Text == "9 tháng")
                {
                    date = dateValue.AddMonths(9);
                }
                else if (cboSuaGoiTap.Text == "12 tháng( VIP)")
                {
                    date = dateValue.AddMonths(12);
                }



                //Sua


                string query = "UPDATE dbo.HoiVien set hoten=N'" + txtSuaTenHV.Text + "', gioitinh= @Gender , sdt='" + txtSuaSdt.Text + "', goitap=@GoiTap, ngayhethan= @NgayHetHan" + " WHERE id_hv='" + txtMaHV.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    //cmd.Parameters.AddWithValue("@ID", MaHV);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@GoiTap", cboSuaGoiTap.Text);
                    cmd.Parameters.AddWithValue("@NgayHetHan", date);
                }

                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("SỬA HỘI VIÊN THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.HoiVien";
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

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
