using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUAN_LY_NHAN_VIEN.Controller;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_DSHD: UserControl
    {

        private QLHDcontroller controller;

        private string maHD;
        private string maNV;
        public UC_DSHD()
        {
            InitializeComponent();
            controller = new QLHDcontroller();
            this.Load += UC_DSHD_Load;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_DSHD_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxLoaiHopDong.DataSource = controller.GetLoaiHD();
                SqlDataReader reader = controller.DanhSachHopDong();
                int i = 0;



                // Xóa dữ liệu cũ
                dataGridViewDSHD.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        dataGridViewDSHD.Rows.Add();
                        dataGridViewDSHD.Rows[i].Cells[0].Value = reader["MaHD"];
                        dataGridViewDSHD.Rows[i].Cells[1].Value = reader["MaNV"];
                        dataGridViewDSHD.Rows[i].Cells[2].Value = reader["LoaiHD"];
                        dataGridViewDSHD.Rows[i].Cells[3].Value = reader["NgayBatDau"];
                        dataGridViewDSHD.Rows[i].Cells[4].Value = reader["NgayKetThuc"];
                        dataGridViewDSHD.Rows[i].Cells[5].Value = reader["LuongCoBan"];
                        dataGridViewDSHD.Rows[i].Cells[6].Value = reader["GhiChu"];

                        i++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }


                reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        //Trả kết qua tìm kiếm ra gridView
        private void LoadInfoHD(string maHD, string maNV)
        {
            SqlDataReader reader = controller.GetResultSearchHD(maHD, maNV);
            bool found = false; // ← biến kiểm tra
            try
            {
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSHD.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        found = true; // có dữ liệu
                        dataGridViewDSHD.Rows.Add();
                        dataGridViewDSHD.Rows[i].Cells[0].Value = reader["MaHD"];
                        dataGridViewDSHD.Rows[i].Cells[1].Value = reader["MaNV"];
                        dataGridViewDSHD.Rows[i].Cells[2].Value = reader["LoaiHD"];
                        dataGridViewDSHD.Rows[i].Cells[3].Value = reader["NgayBatDau"];
                        dataGridViewDSHD.Rows[i].Cells[4].Value = reader["NgayKetThuc"];
                        dataGridViewDSHD.Rows[i].Cells[5].Value = reader["LuongCoBan"];
                        dataGridViewDSHD.Rows[i].Cells[6].Value = reader["GhiChu"];
                        i++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }

                if (!found)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                // Đóng reader để connection tự động đóng
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            maHD = textBoxMaHD.Text;
            maNV = textBoxMaNVHD.Text;

            if (!string.IsNullOrEmpty(maHD) || !string.IsNullOrEmpty(maNV))
            {
                LoadInfoHD(maHD, maNV);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã hợp đồng!");
            }
        }

        private void buttonThemHD_Click(object sender, EventArgs e)
        {

            string maHD = controller.GenerateMaHD();
            string maNV = textBoxMaNVHD.Text;
            string loaiHD = comboBoxLoaiHopDong.SelectedValue.ToString();
            DateTime ngayBD = dateNgayKyHD.Value;
            DateTime ngayKT = dateTimeNgayKetThuc.Value;
            string luongCB = textBoxLuongCoBanHD.Text;
            string ghiChu = richTextBoxGhiChuHD.Text;



            bool result = controller.AddHopDongMoi(maHD, maNV, loaiHD, ngayBD, ngayKT, luongCB, ghiChu);

            if (result)
                MessageBox.Show("Thêm hợp đồng thành công!");
            else
                MessageBox.Show("Thêm hợp đồng thất bại!");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader = controller.DanhSachHopDong();
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSHD.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        dataGridViewDSHD.Rows.Add();
                        dataGridViewDSHD.Rows[i].Cells[0].Value = reader["MaHD"];
                        dataGridViewDSHD.Rows[i].Cells[1].Value = reader["MaNV"];
                        dataGridViewDSHD.Rows[i].Cells[2].Value = reader["LoaiHD"];
                        dataGridViewDSHD.Rows[i].Cells[3].Value = reader["NgayBatDau"];
                        dataGridViewDSHD.Rows[i].Cells[4].Value = reader["NgayKetThuc"];
                        dataGridViewDSHD.Rows[i].Cells[5].Value = reader["LuongCoBan"];
                        dataGridViewDSHD.Rows[i].Cells[6].Value = reader["GhiChu"];
                        i++;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }


                reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                textBoxMaHD.Text = "";
                textBoxMaNVHD.Text = "";
                textBoxLuongCoBanHD.Text = "";
                comboBoxLoaiHopDong.Text = "";
                dateNgayKyHD.Text = "";
                dateTimeNgayKetThuc.Text = "";
                richTextBoxGhiChuHD.Text = "";

            }
        }

        private void dataGridViewDSHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewDSHD.CurrentRow != null)
            {
                textBoxMaHD.Text = dataGridViewDSHD.CurrentRow.Cells[0].Value?.ToString();
                textBoxMaNVHD.Text = dataGridViewDSHD.CurrentRow.Cells[1].Value?.ToString();
                comboBoxLoaiHopDong.Text = dataGridViewDSHD.CurrentRow.Cells[2].Value?.ToString();

                // Ngày bắt đầu
                string strNgayBD = dataGridViewDSHD.CurrentRow.Cells[3].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(strNgayBD) && DateTime.TryParse(strNgayBD, out DateTime ngayBD))
                {
                    dateNgayKyHD.Value = ngayBD;
                }
                else
                {
                    // Nếu không parse được thì cho giá trị mặc định là hôm nay
                    dateNgayKyHD.Value = DateTime.Now;
                }

                // Ngày kết thúc
                string strNgayKT = dataGridViewDSHD.CurrentRow.Cells[4].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(strNgayKT) && DateTime.TryParse(strNgayKT, out DateTime ngayKT))
                {
                    dateTimeNgayKetThuc.Value = ngayKT;
                }
                else
                {
                    dateTimeNgayKetThuc.Value = DateTime.Now;
                }

                textBoxLuongCoBanHD.Text = dataGridViewDSHD.CurrentRow.Cells[5].Value?.ToString();
                richTextBoxGhiChuHD.Text = dataGridViewDSHD.CurrentRow.Cells[6].Value?.ToString();
            }
        }

        private void buttonSuaHD_Click(object sender, EventArgs e)
        {
            string maHD = textBoxMaHD.Text;
            string maNV = textBoxMaNVHD.Text;
            string loaiHD = comboBoxLoaiHopDong.SelectedValue.ToString();
            DateTime ngayBD = dateNgayKyHD.Value;
            DateTime ngayKT = dateTimeNgayKetThuc.Value;
            string luongCB = textBoxLuongCoBanHD.Text;
            string ghiChu = richTextBoxGhiChuHD.Text;

            bool result = controller.UpdateHopDong(maHD, maNV, loaiHD, ngayBD, ngayKT, luongCB, ghiChu);


            if (result)
                MessageBox.Show("Sửa thông tin hợp đồng thành công!");
            else
                MessageBox.Show("Sửa thông tin hợp đồng thất bại!");
        }

        private void buttonXoaHD_Click(object sender, EventArgs e)
        {
            try
            {
                maHD = textBoxMaHD.Text;
                maNV= textBoxMaNVHD.Text;
                bool result = controller.deleteHD(maHD, maNV);

                if (result)
                    MessageBox.Show("Xóa hợp đồng thành công!");
                else
                    MessageBox.Show("Xóa hợp đồng thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Xuất Excel
        private void ExportToExcel(DataGridView dgv)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel._Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "HopDong";

                // Xuất tiêu đề cột
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                // Xuất dữ liệu
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Hiển thị Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
            finally
            {
                // Giải phóng COM object để tránh crash
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                worksheet = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridViewDSHD);
        }
    }
}
