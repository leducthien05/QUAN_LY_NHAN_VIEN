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
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;


namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_DSPB: UserControl
    {
        private QLPBcontroller controller;

        private string maPB;
        private string tenPhong;
        public UC_DSPB()
        {
            InitializeComponent();
            controller = new QLPBcontroller();
            this.Load += UC_DSPB_Load;
        }

        private void UC_DSPB_Load(object sender, EventArgs e)
        {
            dataGridViewDSPB.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            try
            {

                SqlDataReader reader = controller.DanhSachPhongBan();
                int i = 0;



                // Xóa dữ liệu cũ
                dataGridViewDSPB.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        dataGridViewDSPB.Rows.Add();
                        dataGridViewDSPB.Rows[i].Cells[0].Value = reader["MaPhong"];  
                        dataGridViewDSPB.Rows[i].Cells[1].Value = reader["TenPhong"];  
                        dataGridViewDSPB.Rows[i].Cells[2].Value = reader["MoTa"];
                        dataGridViewDSPB.Rows[i].Cells[3].Value = reader["LienHe"];
                        dataGridViewDSPB.Rows[i].Cells[4].Value = reader["TrangThai"];  
                        dataGridViewDSPB.Rows[i].Cells[5].Value = reader["GhiChu"];  
                        
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
        private void LoadInfoPB(string maPhong, string tenPhong)
        {
            SqlDataReader reader = controller.GetResultSearchPB(maPhong, tenPhong);
            bool found = false; // ← biến kiểm tra
            try
            {
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSPB.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        found = true; // có dữ liệu
                        dataGridViewDSPB.Rows.Add();
                        dataGridViewDSPB.Rows[i].Cells[0].Value = reader["MaPhong"];
                        dataGridViewDSPB.Rows[i].Cells[1].Value = reader["TenPhong"];
                        dataGridViewDSPB.Rows[i].Cells[2].Value = reader["MoTa"];
                        dataGridViewDSPB.Rows[i].Cells[3].Value = reader["LienHe"];
                        dataGridViewDSPB.Rows[i].Cells[4].Value = reader["TrangThai"];
                        dataGridViewDSPB.Rows[i].Cells[5].Value = reader["GhiChu"];
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
            maPB = textBoxMaPB.Text;
            tenPhong = textBoxTenPB.Text;

            if (!string.IsNullOrEmpty(maPB) || !string.IsNullOrEmpty(tenPhong))
            {
                LoadInfoPB(maPB, tenPhong);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maPB = controller.GenerateMaPB();
            string tenPB = textBoxTenPB.Text;
            string moTa = textBoxMoTa.Text;
            string lienHe = textBoxLienHe.Text;
            string trangThai = radioActive.Checked ? "Hoạt động" : "Ngừng hoạt động";
            string ghiChu = "";
            


            bool result = controller.AddPhongBanMoi(maPB, tenPB, moTa, lienHe, trangThai, ghiChu);

            if (result)
                MessageBox.Show("Thêm phòng ban thành công!");
            else
                MessageBox.Show("Thêm phòng ban thất bại!");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader = controller.DanhSachPhongBan();
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSPB.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        dataGridViewDSPB.Rows.Add();
                        dataGridViewDSPB.Rows[i].Cells[0].Value = reader["MaPhong"];
                        dataGridViewDSPB.Rows[i].Cells[1].Value = reader["TenPhong"];
                        dataGridViewDSPB.Rows[i].Cells[2].Value = reader["MoTa"];
                        dataGridViewDSPB.Rows[i].Cells[3].Value = reader["LienHe"];
                        dataGridViewDSPB.Rows[i].Cells[4].Value = reader["TrangThai"];
                        dataGridViewDSPB.Rows[i].Cells[5].Value = reader["GhiChu"];
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
                textBoxMaPB.Text = "";
                textBoxTenPB.Text = "";
                radioActive.Checked = false;
                radioInactivePB.Checked = false;
                textBoxMoTa.Text = "";
                textBoxLienHe.Text = "";
                
            }
        }

        private void dataGridViewDSPB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaPB.Text = dataGridViewDSPB.CurrentRow.Cells[0].Value.ToString();
            textBoxTenPB.Text = dataGridViewDSPB.CurrentRow.Cells[1].Value.ToString();
            textBoxMoTa.Text = dataGridViewDSPB.CurrentRow.Cells[2].Value.ToString();
            textBoxLienHe.Text = dataGridViewDSPB.CurrentRow.Cells[3].Value.ToString();
            string trangThai = dataGridViewDSPB.CurrentRow.Cells[4].Value.ToString();
            if (trangThai == "Hoạt động")
                radioActive.Checked = true;
            else if (trangThai == "Ngừng hoạt động")
                radioInactivePB.Checked = true;
            
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string maPB = textBoxMaPB.Text;
            string tenPB = textBoxTenPB.Text;
            string moTa = textBoxMoTa.Text;
            string lienHe = textBoxLienHe.Text;
            string trangThai = radioActive.Checked ? "Hoạt động" : "Ngừng hoạt động";
            string ghiChu = "";

            bool result = controller.UpdatePhongBan(maPB, tenPB, moTa, lienHe, trangThai, ghiChu);


            if (result)
                MessageBox.Show("Sửa thông tin phòng ban thành công!");
            else
                MessageBox.Show("Sửa thông tin phòng ban thất bại!");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maPB = textBoxMaPB.Text;
                string tenPhongBan = textBoxTenPB.Text;
                bool result = controller.deletePB(maPB, tenPhongBan);

                if (result)
                    MessageBox.Show("Xóa phòng ban thành công!");
                else
                    MessageBox.Show("Xóa phòng ban thất bại!");
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
                worksheet.Name = "PhongBan";

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

                // Lấy vùng dữ liệu đã dùng
                Excel.Range usedRange = worksheet.UsedRange;

                // Thêm border cho toàn bộ bảng
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                usedRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                // Format tiêu đề (dòng 1)
                Excel.Range headerRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgv.Columns.Count]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Color.LightGray; // nền xám nhạt
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // AutoFit toàn bộ cột
                worksheet.Columns.AutoFit();

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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridViewDSPB);
        }
    }

       
    
}
