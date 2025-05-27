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
    public partial class fThemHV : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        SqlConnection conn;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        string imgLocation = "";
        protected DataGridView MyDgv;
        public fThemHV(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
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

                //Hàm tăng tự động mã hội viên

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
                    MaHV = "HV0" + (count+1);
                }
                else
                {
                    MaHV = "HV" + (count + 1);
                }


                //Hàm radio giới tính

                string gender = string.Empty;
                if (rdoThemHVNam.Checked)
                {
                    gender = "Nam";
                }
                else if (rdoThemHVNu.Checked)
                {
                    gender = "Nữ";
                }

                //Hàm hết hạn
                DateTime dateValue = DateTime.Now; ;
                DateTime date = DateTime.Now;

                if (cboThemGoiTap.Text == "1 Tháng (Thử)")
                {
                    date = dateValue.AddMonths(1);

                }
                else if (cboThemGoiTap.Text == "3 Tháng")
                {
                    date = dateValue.AddMonths(3);

                }
                else if (cboThemGoiTap.Text == "6 Tháng")
                {
                    date = dateValue.AddMonths(6);

                }
                else if (cboThemGoiTap.Text == "9 Tháng")
                {
                    date = dateValue.AddMonths(9);

                }
                else if (cboThemGoiTap.Text == "12 Tháng (VIP)")
                {
                    date = dateValue.AddMonths(12);

                }

                //Chuyển ảnh

                byte[] imgHV = null;
                FileStream Stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Stream);
                imgHV = brs.ReadBytes((int)Stream.Length);

                //Them


                string query = "INSERT INTO dbo.HoiVien (id_hv,hoten,gioitinh, sdt, goitap, ngayhethan,hinhanh) VALUES (@ID ,N'" + txtThemTenHV.Text.Trim() + "',@Gender,N'" + txtThemSdt.Text.Trim() + "',@GoiTap, @NgayHetHan,@HinhAnh)";
                SqlCommand cmd = new SqlCommand(query, conn);
                {
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ID", MaHV);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@GoiTap", cboThemGoiTap.Text);
                    cmd.Parameters.AddWithValue("@NgayHetHan", date);
                    cmd.Parameters.AddWithValue("@HinhAnh", imgHV);
                }

                var result = cmd.ExecuteNonQuery();
                //GetData();  
                MessageBox.Show("ĐĂNG KÝ HỘI VIÊN THÀNH CÔNG!");
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

        private void picBoxThemHV_Click(object sender, EventArgs e)
        {
            OpenFileDialog uploadImgHV = new OpenFileDialog();
            uploadImgHV.Filter = "Image Files (*.png;*.jpg;*.jpeg;..gif;)|*.png;*.jpg;*.jpeg;.*.gif";
            if (uploadImgHV.ShowDialog() == DialogResult.OK)
            {
                imgLocation = uploadImgHV.FileName.ToString();
                picBoxThemHV.ImageLocation = imgLocation;
            }
        }

        private void fThemHV_Load(object sender, EventArgs e)
        {
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
