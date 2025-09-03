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
    public partial class UC_TQNS: UserControl
    {
        private TrangChuController controller;
        public UC_TQNS()
        {
            InitializeComponent();
            controller = new TrangChuController();
            this.Load += UC_TQNS_Load;
        }

        private void UC_TQNS_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ controller nhân viên
                int tongNV = controller.GetTongNhanVien();
                int nvChinhThuc = controller.GetNhanVienChinhThuc();
                int nvThoiVu = controller.GetNhanVienThuViec();
                int ThucTapSinh = controller.GetThucTapSinh();


                //Lấy dữ liệu từ controller Chuc vụ
                int GiamDoc = controller.GetChucVuGiamDoc();
                int QuanLy = controller.GetChucVuQuanLy();
                int TruongPhong = controller.GetChucVuTruongPhong();

                //Lấy dữ liệu về giới tính
                int Nam = controller.GetTongSoNhanVienNam();
                int Nu = controller.GetTongSoNhanVienNu();

                // Hiển thị lên ô tổng quan nhân viên
                txtTongNhanVien.Text = tongNV.ToString();
                txtNVChinhThuc.Text = nvChinhThuc.ToString();
                txtNVThoiVu.Text = nvThoiVu.ToString();
                txtThucTapSinh.Text = ThucTapSinh.ToString();

                // Hiển thị lên ô tổng quan chức vụ
                txtGiamDoc.Text = GiamDoc.ToString();
                txtQuanLy.Text = QuanLy.ToString();
                txtTruongPhong.Text = TruongPhong.ToString();

                //Hiển thị lên ô tổng quan giới tính
                numberNam.Text = Nam.ToString();
                numberNu.Text = Nu.ToString();

                //Hiển thị datagridView ô Nhân viên
                try
                {
                    SqlDataReader reader = controller.LoadNhanVien();
                    int i = 0;

                    // Xóa dữ liệu cũ
                    datagridViewNhanVien.Rows.Clear();

                    // Đọc từng dòng dữ liệu
                    while (reader.Read())
                    {
                        datagridViewNhanVien.Rows.Add();
                        datagridViewNhanVien.Rows[i].Cells[0].Value = i + 1;          // STT
                        datagridViewNhanVien.Rows[i].Cells[1].Value = reader["MaNV"]; // Mã NV
                        datagridViewNhanVien.Rows[i].Cells[2].Value = reader["HoTen"]; // Họ Tên
                        datagridViewNhanVien.Rows[i].Cells[3].Value = reader["TenPhong"]; // Phòng ban
                        i++;
                    }

                    reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }

                //Hiển thị datagridView ô Chức vụ
                try
                {
                    SqlDataReader reader = controller.LoadChucVu();
                    int i = 0;

                    // Xóa dữ liệu cũ
                    datagirdViewChucVu.Rows.Clear();

                    // Đọc từng dòng dữ liệu
                    while (reader.Read())
                    {
                        datagirdViewChucVu.Rows.Add();
                        datagirdViewChucVu.Rows[i].Cells[0].Value = i + 1;          // STT
                        datagirdViewChucVu.Rows[i].Cells[1].Value = reader["MaNV"]; // Mã NV
                        datagirdViewChucVu.Rows[i].Cells[2].Value = reader["HoTen"]; // Họ Tên
                        datagirdViewChucVu.Rows[i].Cells[3].Value = reader["TenChucVu"]; // Phòng ban
                        i++;
                    }

                    reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }

                //Hiển thị datagridView ô Chức vụ
                try
                {
                    SqlDataReader reader = controller.LoadGioiTinh();
                    int i = 0;

                    // Xóa dữ liệu cũ
                    datagridViewGioiTinh.Rows.Clear();

                    // Đọc từng dòng dữ liệu
                    while (reader.Read())
                    {
                        datagridViewGioiTinh.Rows.Add();
                        datagridViewGioiTinh.Rows[i].Cells[0].Value = i + 1;          // STT
                        datagridViewGioiTinh.Rows[i].Cells[1].Value = reader["MaNV"]; // Mã NV
                        datagridViewGioiTinh.Rows[i].Cells[2].Value = reader["HoTen"]; // Họ Tên
                        datagridViewGioiTinh.Rows[i].Cells[3].Value = reader["GioiTinh"]; // Phòng ban
                        i++;
                    }

                    reader.Close(); // Đóng reader => tự động đóng connection vì có CommandBehavior.CloseConnection
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
