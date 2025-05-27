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
    public partial class fSuaSP : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected DataGridView MyDgv;
        public fSuaSP(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }

        private void fSuaSP_Load(object sender, EventArgs e)
        {
            txtSuaMaSP.Enabled = false;
            txtSuaMaSP.Text = fMain.SetMaSP;
            txtSuaTenSP.Text = fMain.SetTenSP;
            cboSuaLoaiSP.Text = fMain.SetLoaiSP;
            txtSuaTrongLuongSP.Text = fMain.SetTrongLuongSP;
            txtSuaHangSP.Text = fMain.SetHangSP;
            cboSuaTinhTrangSP.Text = fMain.SetTinhTrangSP;
            cboSuaTinhTrangSP.Text = fMain.SetTinhTrangSP;
            dtgSuaSP.Text = fMain.SetNgayNhapSP;
            txtSuaDonGiaSP.Text = fMain.SetDonGiaSP;
            txtSuaSoluongSP.Text = fMain.SetSoLuongSP;
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

                string strQuery = "Select * FROM dbo.SanPham";
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();

                da.Fill(ds);

                string query = "UPDATE dbo.SanPham SET ten=@ten, loai=@loai, ngaynhap=@ngaynhap, soluong=@soluong, dongia=@dongia, trongluong=@trongluong, hangsx=@hangsx, tinhtrang=@tinhtrang WHERE id_sp=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ten", txtSuaTenSP.Text.Trim());
                cmd.Parameters.AddWithValue("@loai", cboSuaLoaiSP.Text);
                cmd.Parameters.AddWithValue("@ngaynhap", dtgSuaSP.Value);
                cmd.Parameters.AddWithValue("@soluong", txtSuaSoluongSP.Text.Trim());
                cmd.Parameters.AddWithValue("@dongia", txtSuaDonGiaSP.Text.Trim());
                cmd.Parameters.AddWithValue("@trongluong", txtSuaTrongLuongSP.Text.Trim());
                cmd.Parameters.AddWithValue("@hangsx", txtSuaHangSP.Text.Trim());
                cmd.Parameters.AddWithValue("@tinhtrang", cboSuaTinhTrangSP.Text);
                cmd.Parameters.AddWithValue("@id", txtSuaMaSP.Text.Trim());


                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("SỬA SẢN PHẨM THÀNH CÔNG!");
                string strQuery1 = "Select * FROM dbo.SanPham";
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

        private void gunaGroupBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
