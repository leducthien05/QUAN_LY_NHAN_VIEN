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
    public partial class UC_PhongBan: UserControl
    {
        private TrangChuController controller;

        public UC_PhongBan()
        {
            InitializeComponent();
            controller = new TrangChuController();
            this.Load += UC_PhongBan_Load;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void UC_PhongBan_Load(object sender, EventArgs e)
        {
            string LienHePhongNS = controller.GetLienHePhongNhanSu();
            string LienHePhongTC = controller.GetLienHePhongTaiChinh();
            string LienHePhongMar = controller.GetLienHePhongMarketing();

            //Trả view liên hệ
            txtLienHePNS.Text = LienHePhongNS.ToString();
            txtLienHePTC.Text = LienHePhongTC.ToString();
            txtLienHePMK.Text = LienHePhongMar.ToString();

        //Trả data cho datagridView Phòng Nhân Sự
            try
            {
                SqlDataReader reader = controller.LoadPhongNhanSu();
                int i = 0;

                // Xóa dữ liệu cũ
                datagridViewPhongNS.Rows.Clear();

                // Đọc từng dòng dữ liệu
                while (reader.Read())
                {
                    datagridViewPhongNS.Rows.Add();
                    datagridViewPhongNS.Rows[i].Cells[0].Value = i + 1;          // STT
                    datagridViewPhongNS.Rows[i].Cells[1].Value = reader["MaNV"]; // Mã NV
                    datagridViewPhongNS.Rows[i].Cells[2].Value = reader["HoTen"]; // Họ Tên
                    datagridViewPhongNS.Rows[i].Cells[3].Value = reader["TenChucVu"]; // Phòng ban
                    i++;
                }

                reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        //Trả data cho datagridView Phòng Marketing
            try
            {
                SqlDataReader reader = controller.LoadPhongMarketing();
                int i = 0;

                // Xóa dữ liệu cũ
                datagirdViewPhongMar.Rows.Clear();

                // Đọc từng dòng dữ liệu
                while (reader.Read())
                {
                    datagirdViewPhongMar.Rows.Add();
                    datagirdViewPhongMar.Rows[i].Cells[0].Value = i + 1;          // STT
                    datagirdViewPhongMar.Rows[i].Cells[1].Value = reader["MaNV"]; // Mã NV
                    datagirdViewPhongMar.Rows[i].Cells[2].Value = reader["HoTen"]; // Họ Tên
                    datagirdViewPhongMar.Rows[i].Cells[3].Value = reader["TenChucVu"]; // Phòng ban
                    i++;
                }

                reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        //Trả data cho datagridView Phòng Tài Chính
            try
            {
                SqlDataReader reader = controller.LoadPhongTaiChinh();
                int i = 0;

                // Xóa dữ liệu cũ
                datagridViewPhongTC.Rows.Clear();

                // Đọc từng dòng dữ liệu
                while (reader.Read())
                {
                    datagridViewPhongTC.Rows.Add();
                    datagridViewPhongTC.Rows[i].Cells[0].Value = i + 1;          // STT
                    datagridViewPhongTC.Rows[i].Cells[1].Value = reader["MaNV"]; // Mã NV
                    datagridViewPhongTC.Rows[i].Cells[2].Value = reader["HoTen"]; // Họ Tên
                    datagridViewPhongTC.Rows[i].Cells[3].Value = reader["TenChucVu"]; // Phòng ban
                    i++;
                }

                reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
    }
}
