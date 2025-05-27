using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.CodeParser;

namespace PhongGym3Lop
{
    public partial class fBaoCao : Form
    {
        string ConnectionString = @"Data Source=TRONGDOAN\MSSQLSERVER01;Initial Catalog=PhongGymMoi;Integrated Security=True";
        DataTable tblCTHDB;
        protected DataGridView MyDgv;
        public fBaoCao(DataGridView dgv)
        {
            InitializeComponent();
            MyDgv = dgv;
        }
        private void ResetValuesHang()
        {
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "0";
        }

        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            cboMaNhanVien.Text = "";
            cboMaKhach.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaHang.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "0";
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT ngayin FROM [PhongGymMoi].[dbo].[View_HoaDon] WHERE id_hd = N'" + txtMaHDBan.Text + "'";
            dtpNgayBan.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT id_nv FROM [PhongGymMoi].[dbo].[View_HoaDon] WHERE id_hd = N'" + txtMaHDBan.Text + "'";
            cboMaNhanVien.Text = Functions.GetFieldValues(str);
            str = "SELECT id_kh FROM [PhongGymMoi].[dbo].[View_HoaDon] WHERE id_hd = N'" + txtMaHDBan.Text + "'";
            cboMaKhach.Text = Functions.GetFieldValues(str);
            str = "SELECT DOANHSO FROM [PhongGymMoi].[dbo].[View_HoaDon] WHERE id_hd = N'" + txtMaHDBan.Text + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(double.Parse(txtTongTien.Text));
        }

        private void fBaoCao_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtTenKhach.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtDienThoai.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            txtDonGiaBan.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTongTien.Text = "0";
            Functions.FillCombo("SELECT id_kh, hoten FROM KhachHang ", cboMaKhach, "id_kh", "id_kh");
            cboMaKhach.SelectedIndex = -1;
            Functions.FillCombo("SELECT id_nv, hoten FROM NhanVien", cboMaNhanVien, "id_nv", "id_nv");
            cboMaNhanVien.SelectedIndex = -1;
            Functions.FillCombo("SELECT id_sp, ten FROM SanPham", cboMaHang, "id_sp", "id_sp");
            cboMaHang.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.id_sp, b.ten, a.soLuong, b.dongia, c.DoanhSo  FROM CTHD AS a,HoaDon AS c, SanPham AS b WHERE a.id_hd = N'" + txtMaHDBan.Text + "' AND a.id_sp=b.id_sp AND a.id_hd = c.id_hd ";
            tblCTHDB = Functions.GetDataToTable(sql);
            dgvHDBanHang.DataSource = tblCTHDB;
            dgvHDBanHang.Columns[0].HeaderText = "Mã hàng";
            dgvHDBanHang.Columns[1].HeaderText = "Tên hàng";
            dgvHDBanHang.Columns[2].HeaderText = "Số lượng";
            dgvHDBanHang.Columns[3].HeaderText = "Đơn giá";
            dgvHDBanHang.Columns[0].Width = 80;
            dgvHDBanHang.Columns[1].Width = 130;
            dgvHDBanHang.Columns[2].Width = 90;
            dgvHDBanHang.Columns[3].Width = 90;
            dgvHDBanHang.AllowUserToAddRows = false;
            dgvHDBanHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi, soLuongNhap, thanhTien;

            // Kiểm tra mã hóa đơn đã tồn tại chưa
            sql = "SELECT id_hd FROM HoaDon WHERE id_hd = N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                if (string.IsNullOrEmpty(cboMaNhanVien.Text))
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaNhanVien.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cboMaKhach.Text))
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaKhach.Focus();
                    return;
                }

                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string insertHoaDonQuery = "INSERT INTO HoaDon(id_hd, ngayin, id_kh, id_nv, DoanhSo) " +
                                               "VALUES (@id_hd, @ngayin, @id_kh, @id_nv, @DoanhSo)";
                    using (SqlCommand cmd = new SqlCommand(insertHoaDonQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_hd", txtMaHDBan.Text.Trim());
                        cmd.Parameters.AddWithValue("@ngayin", dtpNgayBan.Value);
                        cmd.Parameters.AddWithValue("@id_kh", cboMaKhach.SelectedValue);
                        cmd.Parameters.AddWithValue("@id_nv", cboMaNhanVien.SelectedValue);
                        double doanhSo = 0;
                        double.TryParse(txtTongTien.Text, out doanhSo);
                        cmd.Parameters.AddWithValue("@DoanhSo", doanhSo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            if (string.IsNullOrEmpty(cboMaHang.Text))
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHang.Focus();
                return;
            }
            if (!double.TryParse(txtSoLuong.Text, out soLuongNhap) || soLuongNhap <= 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            }

            sql = "SELECT id_sp FROM CTHD WHERE id_sp = N'" + cboMaHang.SelectedValue + "' AND id_hd = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboMaHang.Focus();
                return;
            }

            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soLuong FROM SanPham WHERE id_sp = N'" + cboMaHang.SelectedValue + "'"));
            if (soLuongNhap > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Clear();
                txtSoLuong.Focus();
                return;
            }

            sql = "INSERT INTO CTHD(id_hd, id_sp, soLuong) VALUES (N'" + txtMaHDBan.Text.Trim() + "', N'" + cboMaHang.SelectedValue + "', " + soLuongNhap + ")";
            Functions.RunSQL(sql);

            SLcon = sl - soLuongNhap;
            sql = "UPDATE SanPham SET soLuong = " + SLcon + " WHERE id_sp = N'" + cboMaHang.SelectedValue + "'";
            Functions.RunSQL(sql);

            if (SLcon == 0)
            {
                sql = "UPDATE SanPham SET tinhtrang = N'Hết Hàng' WHERE id_sp = N'" + cboMaHang.SelectedValue + "'";
                Functions.RunSQL(sql);
            }

            double.TryParse(Functions.GetFieldValues("SELECT DoanhSo FROM HoaDon WHERE id_hd = N'" + txtMaHDBan.Text + "'"), out tong);
            double.TryParse(txtThanhTien.Text, out thanhTien);
            Tongmoi = tong + thanhTien;
            sql = "UPDATE HoaDon SET DoanhSo = " + Tongmoi + " WHERE id_hd = N'" + txtMaHDBan.Text + "'";
            Functions.RunSQL(sql);

            txtTongTien.Text = Tongmoi.ToString();
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Tongmoi);

            ResetValuesHang();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnInHoaDon.Enabled = true;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT * FROM dbo.SanPham";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                MyDgv.DataSource = dataSet.Tables[0];
            }

            LoadDataGridView();
        }


        private void cboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaHang.Text == "")
            {
                txtTenHang.Text = "";
                txtDonGiaBan.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT ten FROM SanPham WHERE id_sp =N'" + cboMaHang.SelectedValue + "'";
            txtTenHang.Text = Functions.GetFieldValues(str);
            str = "SELECT dongia FROM SanPham WHERE id_sp =N'" + cboMaHang.SelectedValue + "'";
            txtDonGiaBan.Text = Functions.GetFieldValues(str);
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNhanVien.Text == "")
                txtTenNhanVien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select hoten from NhanVien where id_nv =N'" + cboMaNhanVien.SelectedValue + "'";
            txtTenNhanVien.Text = Functions.GetFieldValues(str);
        }

        private void cboMaKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKhach.Text == "")
            {
                txtTenKhach.Text = "";
                txtDiaChi.Text = "";
                txtDienThoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            str = "Select hoten from KhachHang where id_kh = N'" + cboMaKhach.SelectedValue + "'";
            txtTenKhach.Text = Functions.GetFieldValues(str);
            str = "Select diachi from KhachHang where id_kh = N'" + cboMaKhach.SelectedValue + "'";
            txtDiaChi.Text = Functions.GetFieldValues(str);
            str = "Select sdt from KhachHang where id_kh= N'" + cboMaKhach.SelectedValue + "'";
            txtDienThoai.Text = Functions.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);

            if (txtDonGiaBan.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGiaBan.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (cboMaHDBan.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHDBan.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHDBan.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = true;
            cboMaHDBan.SelectedIndex = -1;
        }

        private void cboMaHDBan_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT id_hd FROM HoaDon", cboMaHDBan, "id_hd", "id_hd");
            cboMaHDBan.SelectedIndex = -1;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo Excel
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook exBook = exApp.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet exSheet = (Microsoft.Office.Interop.Excel.Worksheet)exBook.Worksheets[1];
                Microsoft.Office.Interop.Excel.Range exRange;
                int hang = 0;

                // Cài đặt font
                exSheet.Cells.Font.Name = "Times New Roman";

                // Tiêu đề cửa hàng
                exRange = exSheet.get_Range("A1", "B1");
                exRange.MergeCells = true;
                exRange.Font.Size = 12;
                exRange.Font.Bold = true;
                exRange.Font.ColorIndex = 5;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = "Bánh Bèo GYM";

                exRange = exSheet.get_Range("A2", "B2");
                exRange.MergeCells = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = "HUIT - Lê Trọng Tấn";

                exRange = exSheet.get_Range("A3", "B3");
                exRange.MergeCells = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = "Điện thoại: 085xxxxxxx";

                // Tiêu đề hóa đơn
                exRange = exSheet.get_Range("C2", "E2");
                exRange.MergeCells = true;
                exRange.Font.Size = 16;
                exRange.Font.Bold = true;
                exRange.Font.ColorIndex = 3;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = "HÓA ĐƠN BÁN";

                // Lấy thông tin hóa đơn
                string sql = "SELECT a.id_hd, a.ngayin, a.DoanhSo, b.hoten, b.diachi, b.sdt, c.hoten " +
                             "FROM HoaDon AS a, KhachHang AS b, NhanVien AS c " +
                             "WHERE a.id_hd = N'" + txtMaHDBan.Text + "' AND a.id_kh = b.id_kh AND a.id_nv = c.id_nv";
                DataTable tblThongtinHD = Functions.GetDataToTable(sql);
                if (tblThongtinHD.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // In thông tin khách
                exSheet.Cells[6, 2] = "Mã hóa đơn:";
                exSheet.get_Range("C6", "E6").MergeCells = true;
                exSheet.Cells[6, 3] = tblThongtinHD.Rows[0][0].ToString();

                exSheet.Cells[7, 2] = "Khách hàng:";
                exSheet.get_Range("C7", "E7").MergeCells = true;
                exSheet.Cells[7, 3] = tblThongtinHD.Rows[0][3].ToString();

                exSheet.Cells[8, 2] = "Địa chỉ:";
                exSheet.get_Range("C8", "E8").MergeCells = true;
                exSheet.Cells[8, 3] = tblThongtinHD.Rows[0][4].ToString();

                exSheet.Cells[9, 2] = "Điện thoại:";
                exSheet.get_Range("C9", "E9").MergeCells = true;
                exSheet.Cells[9, 3] = tblThongtinHD.Rows[0][5].ToString();

                // Lấy danh sách mặt hàng
                sql = "SELECT b.ten, a.soLuong, b.dongia, c.DoanhSo " +
                      "FROM CTHD AS a, HoaDon AS c, SanPham AS b " +
                      "WHERE a.id_hd = N'" + txtMaHDBan.Text + "' AND a.id_sp = b.id_sp AND a.id_hd = c.id_hd";
                DataTable tblThongtinHang = Functions.GetDataToTable(sql);

                // Tiêu đề bảng
                string[] tieude = { "STT", "Tên hàng", "Số lượng", "Đơn giá", "Doanh số" };
                for (int i = 0; i < tieude.Length; i++)
                {
                    exSheet.Cells[11, i + 1] = tieude[i];
                }
                exRange = exSheet.get_Range("A11", "E11");
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.ColumnWidth = 15;

                // In dữ liệu mặt hàng
                for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
                {
                    exSheet.Cells[hang + 12, 1] = hang + 1;
                    exSheet.Cells[hang + 12, 2] = tblThongtinHang.Rows[hang][0].ToString();
                    exSheet.Cells[hang + 12, 3] = tblThongtinHang.Rows[hang][1].ToString();
                    exSheet.Cells[hang + 12, 4] = double.Parse(tblThongtinHang.Rows[hang][2].ToString()).ToString("N0") + " VND";
                    exSheet.Cells[hang + 12, 5] = double.Parse(tblThongtinHang.Rows[hang][3].ToString()).ToString("N0") + " VND";
                }

                // Tổng tiền
                double tongTien = 0;
                double.TryParse(tblThongtinHD.Rows[0][2].ToString(), out tongTien);
                exSheet.Cells[hang + 13, 4] = "Tổng tiền:";
                exSheet.Cells[hang + 13, 5] = tongTien.ToString("N0") + " VND";

                // Bằng chữ
                exRange = exSheet.get_Range("A" + (hang + 14), "F" + (hang + 14));
                exRange.MergeCells = true;
                exRange.Font.Italic = true;
                exRange.Font.Bold = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                exRange.Value = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(tongTien);

                // Ngày in & nhân viên
                DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
                exRange = exSheet.get_Range("D" + (hang + 16), "F" + (hang + 16));
                exRange.MergeCells = true;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

                exRange = exSheet.get_Range("D" + (hang + 17), "F" + (hang + 17));
                exRange.MergeCells = true;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = "Nhân viên bán hàng";

                exRange = exSheet.get_Range("D" + (hang + 21), "F" + (hang + 21));
                exRange.MergeCells = true;
                exRange.Font.Italic = true;
                exRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exRange.Value = tblThongtinHD.Rows[0][6];

                // Tên sheet & hiển thị
                exSheet.Name = "HoaDon";
                exApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT id_sp,soLuong FROM CTHD WHERE id_hd = N'" + txtMaHDBan.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);
                for (int hang = 0; hang <= tblHang.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(Functions.GetFieldValues("SELECT soluong FROM SanPham WHERE id_sp = N'" + tblHang.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblHang.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    sql = "UPDATE SanPham SET soLuong =" + slcon + " WHERE id_sp= N'" + tblHang.Rows[hang][0].ToString() + "'";
                    Functions.RunSQL(sql);
                }

                //Xóa chi tiết hóa đơn
                sql = "DELETE CTHD WHERE id_hd=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);

                //Xóa hóa đơn
                sql = "DELETE HoaDon WHERE id_hd=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                LoadDataGridView();
                btnXoa.Enabled = false;
                btnInHoaDon.Enabled = false;

                SqlConnection conn = new SqlConnection(ConnectionString);
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                string strQuery1 = "Select * FROM dbo.SanPham";
                SqlDataAdapter da1 = new SqlDataAdapter(strQuery1, conn);
                DataSet ds1 = new DataSet();

                da1.Fill(ds1);
                MyDgv.DataSource = ds1.Tables[0];
                conn.Close();
            }
           }

        private void gunaGradientButton7_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void dgvHDBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvHDBanHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaHDBan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
