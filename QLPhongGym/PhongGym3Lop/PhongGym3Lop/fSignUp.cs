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
    public partial class fSignUp : Form
    {
        public fSignUp()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True");
            con.Open();
            string gender = string.Empty;
            if (rdoNam.Checked)
            {
                gender = "Nam";
            }
            else if (rdoNu.Checked)
            {
                gender = "Nữ";
            }
            try
            {
                string str = " INSERT INTO employee(emp_username,hoten,matkhau,gioitinh,sdt,diachi) VALUES('" + txtUsername.Text + "','" + txtFullname.Text + "','" + txtPassword.Text + "','" + gender + "','" + txtPhone.Text + "','" + txtAddress.Text + "'); ";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select (emp_username) from employee ;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("" + txtUsername.Text + " Là tài khoản của bạn.");
                    this.Hide();
                    fMain fm = new fMain();
                    fm.ShowDialog();
                }
                this.Close();
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void fSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
