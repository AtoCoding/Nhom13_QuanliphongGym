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
    public partial class fSuaNV : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected DataGridView MyDgv;
        public fSuaNV(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void fSuaNV_Load(object sender, EventArgs e)
        {
            txtSuaMaNV.Enabled = false;
            txtSuaMaNV.Text = fMain.SetMaNV;
            txtSuaTenNV.Text = fMain.SetTenNV;
            txtSuaSdtNV.Text = fMain.SetSdtNV;
            txtSuaSoCCNV.Text = fMain.SetSoCCNV;
            if (fMain.SetGioiTinhNV == "Nam")
            {
                rdoSuaNVNam.Checked = true;
            }
            else if (fMain.SetGioiTinhNV == "Nữ")
            {
                rdoSuaNVNu.Checked = true;
            }
            cboSuaViTri.Text = fMain.SetViTri;
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

                //Hàm radio giới tính

                string gender = string.Empty;
                if (rdoSuaNVNam.Checked)
                {
                    gender = "Nam";
                }
                else if (rdoSuaNVNu.Checked)
                {
                    gender = "Nữ";
                }

                string vitri = string.Empty;
                if (cboSuaViTri.Text == "PT")
                {
                    vitri = "PT";
                }
                else if (cboSuaViTri.Text == "Lễ tân")
                {
                    vitri = "Lễ tân";
                }

                //Sua


                string query = "UPDATE dbo.NhanVien set hoten=N'" + txtSuaTenNV.Text + "', gioitinh= @Gender , sdt='" + txtSuaSdtNV.Text + "', socc='" + txtSuaSoCCNV.Text + "', vitri=@ViTri" + " WHERE id_nv='" + txtSuaMaNV.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    //cmd.Parameters.AddWithValue("@ID", MaHV);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@ViTri", vitri);
                }

                var result = cmd.ExecuteNonQuery();

                MessageBox.Show("SỬA NHÂN VIÊN THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.NhanVien";
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

        private void gunaGroupBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
