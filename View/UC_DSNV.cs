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
            this.Load += UC_SuaNV_Load;
        }

        private void UC_SuaNV_Load(object sender, EventArgs e)
        {
            // Load Chức Vụ
            DataTable dtChucVu = controller.GetChucVuQLNV();
            comBoxChuVuNV.DataSource = dtChucVu;
            comBoxChuVuNV.DisplayMember = "TenChucVu";  // hiện tên
            comBoxChuVuNV.ValueMember = "MaChucVu";     // lưu mã

            // Load Phòng Ban
            DataTable dtPhongBan = controller.GetPhongBanQLNV();
            comBoxPhongBanNV.DataSource = dtPhongBan;
            comBoxPhongBanNV.DisplayMember = "TenPhong";
            comBoxPhongBanNV.ValueMember = "MaPhong";

            // Load Trạng thái
            comBoxTrangThaiNV.DataSource = controller.GetTrangThai();
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

        private void LoadInfoNV(string maNV, string hoTen)
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

        //Button tìm kiếm nhân viên
        private void buttonTimNV_Click_1(object sender, EventArgs e)
        {
            maNV = textBoxMaNV.Text;
            hoTen = textBoxNameNV.Text;

            if (!string.IsNullOrEmpty(maNV) || !string.IsNullOrEmpty(hoTen))
            {
                LoadInfoNV(maNV, hoTen);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
            }
        }

        //Button sửa nhân viên
        private void buttonSuaNhanVien_Click(object sender, EventArgs e)
        {
            //Lấy thông tin từ Form
            string maNV = textBoxMaNV.Text;
            string hoTen = textBoxNameNV.Text;
            DateTime ngaySinh = dateNgaySinh.Value;
            string gioiTinh = radioNamNV.Checked ? "Nam" : "Nữ";
            string soDienThoai = textBoxSDT.Text;
            string email = textBoxEmail.Text;
            string phongBan = comBoxPhongBanNV.SelectedValue.ToString();
            string chucVu = comBoxChuVuNV.SelectedValue.ToString();
            string trangThai = comBoxTrangThaiNV.SelectedValue.ToString();
            string diaChi = textBoxDiaChiNV.Text;
            DateTime ngayVaoLam = dateNgayVaoLamNV.Value;

            bool result = controller.UpdateNV(maNV,hoTen, ngaySinh, gioiTinh, diaChi, soDienThoai, email, ngayVaoLam, phongBan, chucVu, trangThai);


            if (result)
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
            else
                MessageBox.Show("Sửa thông tin nhân viên thất bại!");
        }

        //Button Load danh sách nhân viên
        

        private void buttonThemNV_Click(object sender, EventArgs e)
        {
            string maNV = controller.GenerateMaNV();
            string tenNV = textBoxNameNV.Text;
            DateTime ngaySinh = dateNgaySinh.Value;
            string gioiTinh = radioNamNV.Checked ? "Nam" : "Nữ";
            string maChucVu = comBoxChuVuNV.SelectedValue.ToString();
            string maPhong = comBoxPhongBanNV.SelectedValue.ToString();
            string trangThai = comBoxTrangThaiNV.SelectedItem.ToString();
            string email = textBoxEmail.Text;
            string soDienThoai = textBoxSDT.Text;
            string diaChi = textBoxDiaChiNV.Text;
            DateTime ngayVaoLam = dateNgayVaoLamNV.Value;
            string ghiChu = "";


            bool result = controller.AddNhanVien(maNV, tenNV, ngaySinh, gioiTinh, maChucVu, maPhong, trangThai, ngayVaoLam, email, soDienThoai, diaChi, ghiChu);

            if (result)
                MessageBox.Show("Thêm nhân viên thành công!");
            else
                MessageBox.Show("Thêm nhân viên thất bại!");
        }

        private void buttonLoad_Click_1(object sender, EventArgs e)
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
                textBoxMaNV.Text = "";
                textBoxNameNV.Text = "";
                radioNamNV.Checked = false;
                radioNuNV.Checked = false;
                textBoxDiaChiNV.Text = "";
                textBoxSDT.Text = "";
                dateNgayVaoLamNV.Text = "";
                comBoxPhongBanNV.Text = "";
                comBoxChuVuNV.Text = "";
                comBoxTrangThaiNV.Text = "";
            }
        }

        private void dataGridViewDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaNV.Text = dataGridViewDSNV.CurrentRow.Cells[0].Value.ToString();
            textBoxNameNV.Text = dataGridViewDSNV.CurrentRow.Cells[1].Value.ToString();
            dateNgaySinh.Text = dataGridViewDSNV.CurrentRow.Cells[2].Value.ToString();
            string gioiTinh = dataGridViewDSNV.CurrentRow.Cells[3].Value.ToString();
            if (gioiTinh == "Nam")
                radioNamNV.Checked = true;
            else if (gioiTinh == "Nữ")
                radioNuNV.Checked = true;
            textBoxDiaChiNV.Text = dataGridViewDSNV.CurrentRow.Cells[4].Value.ToString();
            textBoxSDT.Text = dataGridViewDSNV.CurrentRow.Cells[5].Value.ToString();
            dateNgayVaoLamNV.Text = dataGridViewDSNV.CurrentRow.Cells[6].Value.ToString();
            comBoxPhongBanNV.Text = dataGridViewDSNV.CurrentRow.Cells[7].Value.ToString();
            comBoxChuVuNV.Text = dataGridViewDSNV.CurrentRow.Cells[8].Value.ToString();
            comBoxTrangThaiNV.Text = dataGridViewDSNV.CurrentRow.Cells[9].Value.ToString();

        }

        private void buttonXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = textBoxMaNV.Text;
                string hoTen = textBoxNameNV.Text;
                bool result = controller.deleteNV(maNV, hoTen);

                if (result)
                    MessageBox.Show("Xóa nhân viên thành công!");
                else
                    MessageBox.Show("Xóa nhân viên thất bại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
