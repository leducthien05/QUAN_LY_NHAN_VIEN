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


namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_DSNV: UserControl
    {
        //Khai báo controller để lấy hàm bên controller
        private QLNVcontroller controller;

        private string maNV;
        private string hoTen;
        public UC_DSNV()
        {
            InitializeComponent();
            controller = new QLNVcontroller();
            this.Load += UC_DSNV_Load;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Danh sách nhân viên
        private void UC_DSNV_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader = controller.DanhSachNhanVien();
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSNV.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        dataGridViewDSNV.Rows.Add();
                        dataGridViewDSNV.Rows[i].Cells[0].Value = reader["MaNV"]; // Mã NV
                        dataGridViewDSNV.Rows[i].Cells[1].Value = reader["HoTen"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[2].Value = reader["NgaySinh"];
                        dataGridViewDSNV.Rows[i].Cells[3].Value = reader["GioiTinh"];
                        dataGridViewDSNV.Rows[i].Cells[4].Value = reader["DiaChi"]; // Mã NV
                        dataGridViewDSNV.Rows[i].Cells[5].Value = reader["SoDienThoai"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[6].Value = reader["NgayVaoLam"];
                        dataGridViewDSNV.Rows[i].Cells[7].Value = reader["TenPhong"];
                        dataGridViewDSNV.Rows[i].Cells[8].Value = reader["TenChucVu"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[9].Value = reader["TrangThai"];
                        dataGridViewDSNV.Rows[i].Cells[10].Value = reader["NgayKetThuc"];
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

        //Tìm kiếm nhân viên
        private void LoadInfoSearchNV(string maNV, string hoTen)
        {
            SqlDataReader reader = controller.GetResultSearchNV(maNV, hoTen);
            bool found = false; // ← biến kiểm tra
            try
            {
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSNV.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        found = true; // có dữ liệu
                        dataGridViewDSNV.Rows.Add();
                        dataGridViewDSNV.Rows[i].Cells[0].Value = reader["MaNV"]; // Mã NV
                        dataGridViewDSNV.Rows[i].Cells[1].Value = reader["HoTen"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[2].Value = reader["NgaySinh"];
                        dataGridViewDSNV.Rows[i].Cells[3].Value = reader["GioiTinh"];
                        dataGridViewDSNV.Rows[i].Cells[4].Value = reader["DiaChi"]; // Mã NV
                        dataGridViewDSNV.Rows[i].Cells[5].Value = reader["SoDienThoai"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[6].Value = reader["NgayVaoLam"];
                        dataGridViewDSNV.Rows[i].Cells[7].Value = reader["TenPhong"];
                        dataGridViewDSNV.Rows[i].Cells[8].Value = reader["TenChucVu"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[9].Value = reader["TrangThai"];
                        dataGridViewDSNV.Rows[i].Cells[10].Value = reader["NgayKetThuc"];
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
            catch(Exception ex)
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

        private void textBoxMaNVDSNV_TextChanged(object sender, EventArgs e)
        {

        }

        //Button tìm kiếm nhân viên
        private void buttonTimKiemDSNV_Click(object sender, EventArgs e)
        {
            maNV = textBoxMaNVDSNV.Text;
            hoTen = textBoxNameNVDSNV.Text;

            if (!string.IsNullOrEmpty(maNV) || !string.IsNullOrEmpty(hoTen))
            {
                LoadInfoSearchNV(maNV, hoTen);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
            }
        }

        //Button Load danh sách nhân viên
        private void buttonLoadDSNV_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader = controller.DanhSachNhanVien();
                int i = 0;

                // Xóa dữ liệu cũ
                dataGridViewDSNV.Rows.Clear();

                // Đọc từng dòng dữ liệu
                try
                {
                    while (reader.Read())
                    {
                        dataGridViewDSNV.Rows.Add();
                        dataGridViewDSNV.Rows[i].Cells[0].Value = reader["MaNV"]; // Mã NV
                        dataGridViewDSNV.Rows[i].Cells[1].Value = reader["HoTen"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[2].Value = reader["NgaySinh"];
                        dataGridViewDSNV.Rows[i].Cells[3].Value = reader["GioiTinh"];
                        dataGridViewDSNV.Rows[i].Cells[4].Value = reader["DiaChi"]; // Mã NV
                        dataGridViewDSNV.Rows[i].Cells[5].Value = reader["SoDienThoai"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[6].Value = reader["NgayVaoLam"];
                        dataGridViewDSNV.Rows[i].Cells[7].Value = reader["TenPhong"];
                        dataGridViewDSNV.Rows[i].Cells[8].Value = reader["TenChucVu"]; // Họ Tên
                        dataGridViewDSNV.Rows[i].Cells[9].Value = reader["TrangThai"];
                        dataGridViewDSNV.Rows[i].Cells[10].Value = reader["NgayKetThuc"];
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
                textBoxMaNVDSNV.Text = "";
                textBoxNameNVDSNV.Text = "";
            }
        }

        //Xóa nhân viên
        private void buttonXoaDSNV_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = textBoxMaNVDSNV.Text;
                string hoTen = textBoxNameNVDSNV.Text;
                bool result = controller.deleteNV(maNV, hoTen);

                if (result)
                    MessageBox.Show("Xóa nhân viên thành công!");
                else
                    MessageBox.Show("Xóa nhân viên thất bại!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

    }
}
