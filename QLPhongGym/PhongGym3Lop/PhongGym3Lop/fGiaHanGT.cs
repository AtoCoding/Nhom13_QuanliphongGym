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
    public partial class fGiaHanGT : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        protected DataGridView MyDgv2;
        protected DataGridView dgvGT;
        public fGiaHanGT(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv2 = dgv;
        }

        private void fGiaHanGT_Load(object sender, EventArgs e)
        {
            txtGiaHanMaHV.Enabled = false;
            txtGiaHanMaHV.Text = fMain.SetMaHVGT;
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

                string strQuery = "Select * FROM dbo.HoiVien";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                string MaHV = string.Empty;
                int count = 0;
                count = ds.Tables[0].Rows.Count;
                if (count < 10)
                {
                    MaHV = "HV00" + (count + 1);
                }
                else if (count < 100 && count > 10)
                {
                    MaHV = "HV0" + (count);
                }
                else
                {
                    MaHV = "HV" + (count + 1);
                }

                DateTime timehientai = Convert.ToDateTime(fMain.SetNHHGT);
                DateTime dateGH = DateTime.Now;
                if (cboGiaHanGoiTap.Text == "1 tháng(Thử)")
                {
                    dateGH = timehientai.AddMonths(1);
                }
                else if (cboGiaHanGoiTap.Text == "3 tháng")
                {
                    dateGH = timehientai.AddMonths(3);
                }
                else if (cboGiaHanGoiTap.Text == "6 tháng")
                {
                    dateGH = timehientai.AddMonths(6);
                }
                else if (cboGiaHanGoiTap.Text == "9 tháng")
                {
                    dateGH = timehientai.AddMonths(9);
                }
                else if (cboGiaHanGoiTap.Text == "12 tháng(VIP)")
                {
                    dateGH = timehientai.AddMonths(12);
                }
                string query = "UPDATE dbo.HoiVien set goitap = @GoiTap, ngayhethan = @NgayHetHan WHERE id_hv='" + txtGiaHanMaHV.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@GoiTap", cboGiaHanGoiTap.Text);
                    cmd.Parameters.AddWithValue("@NgayHetHan", dateGH);
                }

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("GIA HẠN THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.HoiVien";
                SqlDataAdapter da1 = new SqlDataAdapter(strQuery1, conn);
                DataSet ds1 = new DataSet();

                da1.Fill(ds1);
                MyDgv2.DataSource = ds1.Tables[0];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
