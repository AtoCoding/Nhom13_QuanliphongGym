using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhongGym3Lop
{
    public partial class fMain : Form
    {
        SqlDataAdapter da;
        DataSet ds;
        public fMain()
        {
            InitializeComponent();
            SetControl();
            GetData();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }



        SqlConnection con = new SqlConnection(@"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True");
        private void opencon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void closecon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Close();
            }
        }

        //dùng update, insert, delete
        private Boolean Exe(string cmd)
        {
            opencon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch
            {
                check = false;
            }
            closecon();
            return check;
        }

        //xem dl trong SQL
        private DataTable Red(string cmd)
        {
            opencon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter da = new SqlDataAdapter(sc);
                da.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            closecon();
            return dt;
        }

        private void SetControl()
        {
            txtMaHV.ReadOnly = true;
            txtTenHV.ReadOnly = true;
            rdoNam.Enabled = false;
            rdoNu.Enabled = false;
            txtSdt.ReadOnly = true;
            txtNgayHetHan.ReadOnly = true;
            txtGoiTap.ReadOnly = true;
            picBoxHV.Enabled = true;
        }

        public void GetData()
        {
            DataTable dt = Red("SELECT * FROM HoiVien");
            if (dt != null)
            {
                dtgHV.DataSource = dt;
            }

            DataTable dtt = Red("SELECT * FROM HoiVien");
            if (dtt != null)
            {
                dtgGoiTap.DataSource = dt;
            }
        }

        //Lấy DL từ datasource
        private void fMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'phongGymMoiDataSet2.HoiVien' table. You can move, or remove it, as needed.
            this.hoiVienTableAdapter1.Fill(this.phongGymMoiDataSet2.HoiVien);
            // TODO: This line of code loads data into the 'phongGymMoiDataSet1.View_HoaDon' table. You can move, or remove it, as needed.
            this.view_HoaDonTableAdapter.Fill(this.phongGymMoiDataSet1.View_HoaDon);
            // TODO: This line of code loads data into the 'phongGymMoiDataSet.KhachHang' table. You can move, or remove it, as needed.
            this.khachHangTableAdapter.Fill(this.phongGymMoiDataSet.KhachHang);
            // TODO: This line of code loads data into the 'phongGymMoiDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.phongGymMoiDataSet.NhanVien);
            // TODO: This line of code loads data into the 'phongGymMoiDataSet.ThietBi' table. You can move, or remove it, as needed.
            this.thietBiTableAdapter.Fill(this.phongGymMoiDataSet.ThietBi);
            // TODO: This line of code loads data into the 'phongGymMoiDataSet.SanPham' table. You can move, or remove it, as needed.
            this.sanPhamTableAdapter.Fill(this.phongGymMoiDataSet.SanPham);
            // TODO: This line of code loads data into the 'phongGymMoiDataSet.HoiVien' table. You can move, or remove it, as needed.
            this.hoiVienTableAdapter.Fill(this.phongGymMoiDataSet.HoiVien);
        }

        private void TIMKIEMHV(string TUKHOA)
        {
            DataTable dt = Red("Select * from dbo.HoiVien where hoten like N'%" + TUKHOA + "%' or id_hv like N'%" + TUKHOA + "%'");
            if (dt != null)
            {
                dtgHV.DataSource = dt;
            }
        }

        private bool isCollapsed;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                menu.Height += 15;
                if (menu.Size == menu.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                menu.Height -= 15;
                if (menu.Size == menu.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                menu2.Height += 15;
                if (menu2.Size == menu2.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                menu2.Height -= 15;
                if (menu2.Size == menu2.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                menu3.Height += 15;
                if (menu3.Size == menu3.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                menu3.Height -= 15;
                if (menu3.Size == menu3.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void gunaImageButton4_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnmenu3_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TIMKIEMHV(txtSearch.Text);
            }
        }

        private void txtTimKiemKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TIMKIEMKH(txtTimKiemKH.Text);
            }
        }

        private void TIMKIEMSP(string TUKHOA)
        {
            DataTable dt = Red("Select * from dbo.SanPham where ten like N'%" + TUKHOA + "%' or id_sp like N'%" + TUKHOA + "%'");
            if (dt != null)
            {
                dtgSanPham.DataSource = dt;
            }
        }

        private void TIMKIEMNV(string TUKHOA)
        {
            DataTable dt = Red("Select * from dbo.NhanVien where hoten like N'%" + TUKHOA + "%' or id_nv like N'%" + TUKHOA + "%'");
            if (dt != null)
            {
                dtgNV.DataSource = dt;
            }
        }

        private void txtTimKiemNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TIMKIEMNV(txtTimKiemNV.Text);
            }
        }

        private void txtTimKiemSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TIMKIEMSP(txtTimKiemSP.Text);
            }
        }

        private void TIMKIEMTB(string TUKHOA)
        {
            DataTable dt = Red("Select * from dbo.ThietBi where ten like N'%" + TUKHOA + "%' or id_tb like N'%" + TUKHOA + "%'");
            if (dt != null)
            {
                dtgTB.DataSource = dt;
            }
        }

        private void txtTmKiemTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TIMKIEMTB(txtTimKiemTB.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True");
            string query = "delete dbo.HoiVien " + " where id_hv    ='" + txtMaHV.Text.Trim() + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }

            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
            GetData();
        }

        //chuyen kiểu byte thành img
        public Image BytesToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void dtgHV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHV.Text = dtgHV.CurrentRow.Cells[0].Value.ToString();
            txtTenHV.Text = dtgHV.CurrentRow.Cells[1].Value.ToString();


            if (dtgHV.CurrentRow.Cells[2].Value.ToString() == "Nam")
            {
                rdoNam.Checked = true;
                rdoNu.Checked = false;
            }
            else
            {
                rdoNu.Checked = true;
                rdoNam.Checked = false;
            }
            txtSdt.Text = dtgHV.CurrentRow.Cells[3].Value.ToString();
            txtNgayHetHan.Text = dtgHV.CurrentRow.Cells[4].Value.ToString();
            txtGoiTap.Text = dtgHV.CurrentRow.Cells[5].Value.ToString();

            try
            {
                Exe("select * from dbo.HoiVien");
                byte[] img = (byte[])dtgHV.CurrentRow.Cells[6].Value;
                picBoxHV.Image = BytesToImage(img);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThemHV fThemHv = new fThemHV(this.dtgHV);
            fThemHv.ShowDialog();

        }

        //set biến trung gian để sử dụng giá trị 2 form
        public static string SetMaHV = "";
        public static string SetTenHV = "";
        public static string SetGioiTinhHV = "";
        public static string SetSdtHV = "";
        public static string SetGoiTap = "";

        private void btnSua_Click(object sender, EventArgs e)
        {
            SetMaHV = txtMaHV.Text;
            SetTenHV = txtTenHV.Text;
            SetSdtHV = txtSdt.Text;
            SetGoiTap = txtGoiTap.Text;
            if (rdoNam.Checked == true)
            {
                SetGioiTinhHV = "Nam";
            }
            else if (rdoNu.Checked == true)
            {
                SetGioiTinhHV = "Nữ";
            }
            fSuaHV fSua = new fSuaHV(this.dtgHV);
            fSua.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            fThemSP fThemSP = new fThemSP(this.dtgSanPham);
            fThemSP.ShowDialog();
        }

        public static string SetMaSP = "";
        public static string SetTenSP = "";
        public static string SetLoaiSP = "";
        public static string SetSoLuongSP = "";
        public static string SetHangSP = "";
        public static string SetNgayNhapSP = "";
        public static string SetDonGiaSP = "";
        public static string SetTinhTrangSP = "";
        public static string SetTrongLuongSP = "";

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            SetMaSP = txtMaSP.Text;
            SetTenSP = txtTenSP.Text;
            SetLoaiSP = txtLoaiSP.Text;
            SetSoLuongSP = txtSoLuongSP.Text;
            SetHangSP = txtHangSXSP.Text;
            SetTinhTrangSP = txtTinhTrangSP.Text;
            SetTrongLuongSP = txtTrongLuongSP.Text;
            SetNgayNhapSP = txtNgayNhapSP.Text;
            SetDonGiaSP = txtDonGiaSP.Text;

            fSuaSP fSuaSP = new fSuaSP(this.dtgSanPham);
            fSuaSP.ShowDialog();
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string query = "delete dbo.SanPham " + " where id_sp ='" + txtMaSP.Text.Trim() + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }

            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
            DataTable dt = Red("SELECT * FROM SanPham");
            if (dt != null)
            {
                dtgSanPham.DataSource = dt;
            }
        }

        private void dtgSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dtgSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dtgSanPham.CurrentRow.Cells[1].Value.ToString();
            txtLoaiSP.Text = dtgSanPham.CurrentRow.Cells[2].Value.ToString();
            txtNgayNhapSP.Text = dtgSanPham.CurrentRow.Cells[3].Value.ToString();
            txtSoLuongSP.Text = dtgSanPham.CurrentRow.Cells[4].Value.ToString();
            txtDonGiaSP.Text = dtgSanPham.CurrentRow.Cells[5].Value.ToString();
            txtTrongLuongSP.Text = dtgSanPham.CurrentRow.Cells[6].Value.ToString();
            txtHangSXSP.Text = dtgSanPham.CurrentRow.Cells[7].Value.ToString();
            txtTinhTrangSP.Text = dtgSanPham.CurrentRow.Cells[8].Value.ToString();

            try
            {
                DataTable dt = Red("Select * from SanPham");
                byte[] img = (byte[])dtgSanPham.CurrentRow.Cells[9].Value;
                picSP.Image = BytesToImage(img);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gunaGradientButton5_Click(object sender, EventArgs e)
        {
            fThemTB fthemtb = new fThemTB(this.dtgTB);
            fthemtb.ShowDialog();
        }

        private void dtgTB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTB.Text = dtgTB.CurrentRow.Cells[0].Value.ToString();
            txtTenTB.Text = dtgTB.CurrentRow.Cells[1].Value.ToString();
            txtLoaiTB.Text = dtgTB.CurrentRow.Cells[2].Value.ToString();
            txtSoLuongTB.Text = dtgTB.CurrentRow.Cells[3].Value.ToString();
            txtHangTB.Text = dtgTB.CurrentRow.Cells[4].Value.ToString();
            txtTinhTrangTB.Text = dtgTB.CurrentRow.Cells[5].Value.ToString();
            txtSoLuongHuTB.Text = dtgTB.CurrentRow.Cells[6].Value.ToString();
            txtGhiChuTB.Text = dtgTB.CurrentRow.Cells[7].Value.ToString();
            try
            {
                Exe("select * from dbo.ThietBi");
                byte[] img = (byte[])dtgTB.CurrentRow.Cells[8].Value;
                picTB.Image = BytesToImage(img);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }


        private void gunaGradientButton12_Click(object sender, EventArgs e)
        {
            fBaoCao fb = new fBaoCao(this.dtgSanPham);
            fb.ShowDialog();
        }

        private void btnXemDT_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtp3.Value.Date;
            DateTime toDate = dtp2.Value.Date.AddDays(1);

            if (fromDate > toDate)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi");
                return;
            }

            string connectionString = "Data Source=TRONGDOAN\\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True"; // <-- Sửa ở đây

            string sql = "SELECT * FROM View_HoaDon WHERE ngayin BETWEEN @fromDate AND @toDate";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate);
                    cmd.Parameters.AddWithValue("@toDate", toDate);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dtgDoanhThu.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu trong khoảng thời gian đã chọn.", "Thông báo");
                        dtgDoanhThu.DataSource = null;
                    }
                }
            }
        }




        private void gunaDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.Text = dtgKH.CurrentRow.Cells[0].Value.ToString();
            txtTenKH.Text = dtgKH.CurrentRow.Cells[1].Value.ToString();
            dtpNgaySinhKH.Value = Convert.ToDateTime(dtgKH.CurrentRow.Cells[4].Value.ToString());
            txtSDTKH.Text = dtgKH.CurrentRow.Cells[3].Value.ToString();
            txtDiaChiKH.Text = dtgKH.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            fThemNV fThem = new fThemNV(this.dtgNV);
            fThem.ShowDialog();
        }

        //******NV******
        public static string SetMaNV = "";
        public static string SetTenNV = "";
        public static string SetGioiTinhNV = "";
        public static string SetSdtNV = "";
        public static string SetSoCCNV = "";
        public static string SetViTri = "";

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            SetMaNV = txtMaNV.Text;
            SetTenNV = txtTenNV.Text;
            SetSdtNV = txtSdtNV.Text;
            SetViTri = txtViTriNV.Text;
            SetSoCCNV = txtSoCCNV.Text;
            if (rdoNamNV.Checked == true)
            {
                SetGioiTinhNV = "Nam";
            }
            else if (rdoNuNV.Checked == true)
            {
                SetGioiTinhNV = "Nữ";
            }
            fSuaNV fSuanv = new fSuaNV(this.dtgNV);
            fSuanv.ShowDialog();
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            string query = "delete dbo.NhanVien " + " where id_nv ='" + txtMaNV.Text.Trim() + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }

            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
            DataTable dt = Red("SELECT * FROM NhanVien");
            if (dt != null)
            {
                dtgNV.DataSource = dt;
            }
        }

        private void dtgNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dtgNV.CurrentRow.Cells[0].Value.ToString();
            txtTenNV.Text = dtgNV.CurrentRow.Cells[1].Value.ToString();
            if (dtgNV.CurrentRow.Cells[2].Value.ToString() == "Nam")
            {
                rdoNamNV.Checked = true;
                rdoNuNV.Checked = false;
            }
            else
            {
                rdoNamNV.Checked = false;
                rdoNuNV.Checked = true;
            }
            txtSdtNV.Text = dtgNV.CurrentRow.Cells[3].Value.ToString();
            txtSoCCNV.Text = dtgNV.CurrentRow.Cells[5].Value.ToString();
            txtViTriNV.Text = dtgNV.CurrentRow.Cells[6].Value.ToString();

            try
            {
                Exe("select * from dbo.NhanVien");
                byte[] img = (byte[])dtgNV.CurrentRow.Cells[7].Value;
                picNV.Image = BytesToImage(img);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void TIMKIEMKH(string TUKHOA)
        {
            DataTable dt = Red("Select * from dbo.KhachHang where hoten like N'%" + TUKHOA + "%' or id_kh like N'%" + TUKHOA + "%'");
            if (dt != null)
            {
                dtgKH.DataSource = dt;
            }
        }

        private void gunaGradientButton10_Click(object sender, EventArgs e)
        {
            fThemKH fThemKH = new fThemKH(this.dtgKH);
            fThemKH.ShowDialog();
        }

        //******SỬA KH ******
        public static DateTime SetNgaySinh;
        public static string SetMaKH = "";
        public static string SetTenKH = "";
        public static string SetDiaChiKH = "";
        public static string SetSdtKH = "";

        private void gunaGradientButton9_Click(object sender, EventArgs e)
        {
            SetMaKH = txtMaKH.Text;
            SetTenKH = txtTenKH.Text;
            SetSdtKH = txtSDTKH.Text;
            SetDiaChiKH = txtDiaChiKH.Text;
            SetNgaySinh = dtpNgaySinhKH.Value;
            fSuaKH fSuaKH = new fSuaKH(this.dtgKH);
            fSuaKH.ShowDialog();
        }

        private void gunaGradientButton8_Click(object sender, EventArgs e)
        {
            Exe("DELETE FROM dbo.KhachHang WHERE id_kh = '" + txtMaKH.Text + "'");
            DataTable dt = Red("SELECT * FROM dbo.KhachHang");
            if (dt != null)
            {
                dtgKH.DataSource = dt;
            }
        }


        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            //conn = new SqlConnection(ConnectionString);
            string query = "delete dbo.ThietBi " + " where id_tb='" + txtMaTB.Text.Trim() + "'";

            SqlCommand cmd = new SqlCommand(query, con);

            if (con.State == ConnectionState.Closed)
            {

                con.Open();
            }

            var result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("Xóa dữ liệu thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
            DataTable dt = Red("Select * from dbo.ThietBi");
            if (dt != null)
            {
                dtgTB.DataSource = dt;
            }
        }

        //******SỬA TB******
        public static string SetMaTB = "";
        public static string SetTenTB = "";
        public static string SetLoaiTB = "";
        public static string SetSoLuongTB = "";
        public static string SetHangTB = "";
        public static string SetTinhTrangTB = "";
        public static string SetSoLuongHuTB = "";
        public static string SetGhiChu = "";

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            SetMaTB = txtMaTB.Text;
            SetTenTB = txtTenTB.Text;
            SetLoaiTB = txtLoaiTB.Text;
            SetSoLuongTB = txtSoLuongTB.Text;
            SetHangTB = txtHangTB.Text;
            SetTinhTrangTB = txtTinhTrangTB.Text;
            SetSoLuongHuTB = txtSoLuongTB.Text;
            SetGhiChu = txtGhiChuTB.Text;

            fSuaTB fSuaTB = new fSuaTB(this.dtgTB);
            fSuaTB.ShowDialog();
        }

        public static string SetMaHVGT = "";
        public static string SetNHHGT = "";
        private string connectionString;

        private void dtgGoiTap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHVGoiTap.Text = dtgGoiTap.CurrentRow.Cells[0].Value.ToString();
            txtNgayHetHanGT.Text = dtgGoiTap.CurrentRow.Cells[4].Value.ToString();
            if (dtgGoiTap.CurrentRow.Cells[6].Value.ToString() == "1 tháng(Thử)")
            {
                cboGoiTap.Text = "1 tháng(Thử)";
            }
            else if (dtgGoiTap.CurrentRow.Cells[6].Value.ToString() == "3 tháng")
            {
                cboGoiTap.Text = "3 tháng";
            }
            else if (dtgGoiTap.CurrentRow.Cells[6].Value.ToString() == "6 tháng")
            {
                cboGoiTap.Text = "6 tháng";
            }
            else if (dtgGoiTap.CurrentRow.Cells[6].Value.ToString() == "9 tháng")
            {
                cboGoiTap.Text = "9 tháng";
            }
            else
            {
                cboGoiTap.Text = "12 tháng(VIP)";
            }
        }

        private void gunaGradientButton6_Click_1(object sender, EventArgs e)
        {
            copyAlltoClipboard();
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            // lấy ra sheet đầu tiên để thao tác
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //bat dau tu vi tri 1 1
            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
        }
        private void copyAlltoClipboard()
        {
            dtgDoanhThu.SelectAll();
            //Lấy các giá trị được định dạng đại diện cho nội dung của các ô đã chọn để sao chép vào Bảng tạm .
            DataObject dataObj = dtgDoanhThu.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }

        private void btnLocGoiTap_Click_1(object sender, EventArgs e)
        {
            opencon();
            if (cboGoiTap.Text == "Tất cả")
            {
                string query = "select * from dbo.HoiVien";
                SqlCommand cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    llblGoiTap.Text = ds.Tables[0].Rows.Count + " Hội Viên";
                    dtgGoiTap.DataSource = ds.Tables[0];
                }
                con.Close();
            }
            else if (cboGoiTap.Text == "1 tháng (Thử)")
            {

                string query = "select * from dbo.HoiVien where goitap like N'%1 tháng%'";
                SqlCommand cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    llblGoiTap.Text = ds.Tables[0].Rows.Count + " Hội Viên";
                    dtgGoiTap.DataSource = ds.Tables[0];
                }
                con.Close();
            }
            else if (cboGoiTap.Text == "3 tháng")
            {
                string query = "select * from dbo.HoiVien where goitap like N'%3 tháng%'";
                SqlCommand cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    llblGoiTap.Text = ds.Tables[0].Rows.Count + " Hội Viên";
                    dtgGoiTap.DataSource = ds.Tables[0];
                }
                con.Close();
            }
            else if (cboGoiTap.Text == "6 tháng")
            {
                string query = "select * from dbo.HoiVien where goitap like N'%6 tháng%'";
                SqlCommand cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    llblGoiTap.Text = ds.Tables[0].Rows.Count + " Hội Viên";
                    dtgGoiTap.DataSource = ds.Tables[0];
                }
                con.Close();
            }
            else if (cboGoiTap.Text == "9 tháng")
            {
                string query = "select * from dbo.HoiVien where goitap like N'%9 tháng%'";
                SqlCommand cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    llblGoiTap.Text = ds.Tables[0].Rows.Count + " Hội Viên";
                    dtgGoiTap.DataSource = ds.Tables[0];
                }
                con.Close();
            }
            else
            {
                string query = "select * from dbo.HoiVien where goitap like N'%12 tháng%'";
                SqlCommand cmd = new SqlCommand(query, con);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    llblGoiTap.Text = ds.Tables[0].Rows.Count + " Hội Viên";
                    dtgGoiTap.DataSource = ds.Tables[0];
                }
                con.Close();
            }
        }

        private void btnXemGoiTap_Click_1(object sender, EventArgs e)
        {
            fXemGT fxemgt = new fXemGT();
            fxemgt.ShowDialog();
        }

        private void btnGiaHanGoiTap_Click_1(object sender, EventArgs e)
        {
            SetMaHVGT = txtMaHVGoiTap.Text;
            SetNHHGT = txtNgayHetHanGT.Text;
            fGiaHanGT fgiahan = new fGiaHanGT(this.dtgGoiTap);
            fgiahan.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgHV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
