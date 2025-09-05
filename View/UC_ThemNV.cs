using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QUAN_LY_NHAN_VIEN.Controller;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_ThemNV: UserControl
    {
        private QLNVcontroller controller;

        public UC_ThemNV()
        {
            InitializeComponent();
            controller = new QLNVcontroller();
            this.Load += UC_ThemNV_Load;
        }


        private void buttonAddNhanVien_Click(object sender, EventArgs e)
        {
            string maNV = controller.GenerateMaNV();
            string tenNV = textBoxAddNameNV.Text;
            DateTime ngaySinh = dateAddNgaySinh.Value;
            string gioiTinh = raidoNamAddNV.Checked ? "Nam" : "Nữ";
            string maChucVu = comBoxChuVuAddNV.SelectedValue.ToString();
            string maPhong = comBoxPhongBanAddNV.SelectedValue.ToString();
            string trangThai = comBoxTrangThaiAddNV.SelectedItem.ToString();
            string email = textAddEmail.Text;
            string soDienThoai = textBoxAddSDT.Text;
            string diaChi = textBoxDiaChiAddNV.Text;
            DateTime ngayVaoLam = dateNgayVaoLamAddNV.Value;
            string ghiChu = "";


            bool result = controller.AddNhanVien(maNV, tenNV, ngaySinh, gioiTinh, maChucVu, maPhong, trangThai, ngayVaoLam, email, soDienThoai, diaChi, ghiChu);

            if (result)
                MessageBox.Show("Thêm nhân viên thành công!");
            else
                MessageBox.Show("Thêm nhân viên thất bại!");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UC_ThemNV_Load(object sender, EventArgs e)
        {
            // Load Chức Vụ
            DataTable dtChucVu = controller.GetChucVuQLNV();
            comBoxChuVuAddNV.DataSource = dtChucVu;
            comBoxChuVuAddNV.DisplayMember = "TenChucVu";  // hiện tên
            comBoxChuVuAddNV.ValueMember = "MaChucVu";     // lưu mã

            // Load Phòng Ban
            DataTable dtPhongBan = controller.GetPhongBanQLNV();
            comBoxPhongBanAddNV.DataSource = dtPhongBan;
            comBoxPhongBanAddNV.DisplayMember = "TenPhong";
            comBoxPhongBanAddNV.ValueMember = "MaPhong";

            // Load Trạng thái
            comBoxTrangThaiAddNV.DataSource = controller.GetTrangThai();

            //Load Mã Nhân Viên
            maNVAddMaNV.Text = controller.GenerateMaNV();
        }

        private void comBoxPhongBanAddNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
