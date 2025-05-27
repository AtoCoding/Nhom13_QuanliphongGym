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
    public partial class Form1 : Form
    {
        public static string UserName = Properties.Settings.Default.UserName;
        public static string Password = Properties.Settings.Default.Password;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RememberMe == "true")
            {
                txtUser.Text = Properties.Settings.Default.UserName;
                txtPass.Text = Properties.Settings.Default.Password;
                chkRMBer.Checked = true;
            }
            else
            {
                txtUser.Text = "";
                txtPass.Text = "";
                chkRMBer.Checked = false;
            }

        }

        private void checkLogin()
        {
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUser.Text != null && txtUser.Text != "") { }
            else
            {
                MessageBox.Show("Chưa nhập tên tài khoản", "Thông báo");
                txtUser.Focus();
                return;
            }
            if (txtPass.Text != null && txtPass.Text != "") { }
            else
            {
                MessageBox.Show("Chưa nhập mật khẩu", "Thông báo");
                txtPass.Focus();
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True");
            con.Open();
            string str = "SELECT emp_username FROM employee WHERE matkhau='" + txtPass.Text + "'";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                this.Visible = false;
                fMain fM = new fMain();
                fM.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
            }

            if (chkRMBer.Checked == true)
            {

                UserName = this.txtUser.Text;
                Password = this.txtPass.Text;
                Properties.Settings.Default.UserName = UserName;
                Properties.Settings.Default.Password = Password;
                Properties.Settings.Default.RememberMe = "true";
                Properties.Settings.Default.Save();
            }
            else
            {
                UserName = this.txtUser.Text;
                Properties.Settings.Default.UserName = UserName;
                Password = "";
                Properties.Settings.Default.RememberMe = "false";
                Properties.Settings.Default.Save();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            fSignUp freg = new fSignUp();
            freg.ShowDialog();
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUser.Text != null && txtUser.Text != "") { }
                else
                {
                    MessageBox.Show("Chưa nhập tên tài khoản", "Thông báo");
                    txtUser.Focus();
                    return;
                }
                if (txtPass.Text != null && txtPass.Text != "") { }
                else
                {
                    MessageBox.Show("Chưa nhập mật khẩu", "Thông báo");
                    txtPass.Focus();
                    return;
                }
                SqlConnection con = new SqlConnection(@"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True");
                con.Open();
                string str = "SELECT emp_username FROM employee WHERE matkhau='" + txtPass.Text + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    this.Visible = false;
                    fMain fM = new fMain();
                    fM.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                }

                if (chkRMBer.Checked == true)
                {

                    UserName = this.txtUser.Text;
                    Password = this.txtPass.Text;
                    Properties.Settings.Default.UserName = UserName;
                    Properties.Settings.Default.Password = Password;
                    Properties.Settings.Default.RememberMe = "true";
                    Properties.Settings.Default.Save();
                }
                else
                {
                    UserName = this.txtUser.Text;
                    Properties.Settings.Default.UserName = UserName;
                    Password = "";
                    Properties.Settings.Default.RememberMe = "false";
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            checkLogin();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            checkLogin();
        }
    }
}
