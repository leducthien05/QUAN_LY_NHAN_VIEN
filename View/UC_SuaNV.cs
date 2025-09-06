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

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_SuaNV: UserControl
    {
        private string maNV;
        private QLNVcontroller controller;
        public UC_SuaNV()
        {
            InitializeComponent();
            controller = new QLNVcontroller();
            this.Load += UC_SuaNV_Load;
        }

        private void UC_SuaNV_Load(object sender, EventArgs e)
        {
            // Load Chức Vụ
            DataTable dtChucVu = controller.GetChucVuSuaNVQLNV();
            comBoxChuVuSuaNV.DataSource = dtChucVu;
            comBoxChuVuSuaNV.DisplayMember = "TenChucVu";  // hiện tên
            comBoxChuVuSuaNV.ValueMember = "MaChucVu";     // lưu mã

            // Load Phòng Ban
            DataTable dtPhongBan = controller.GetPhongBanQLNV();
            comBoxPhongBanSuaNV.DataSource = dtPhongBan;
            comBoxPhongBanSuaNV.DisplayMember = "TenPhong";
            comBoxPhongBanSuaNV.ValueMember = "MaPhong";

            // Load Trạng thái
            comBoxTrangThaiSuaNV.DataSource = controller.GetTrangThaiSuaNV();

            
        }

        private void LoadInfoNV(string maNV)
        {
            DataTable dt = controller.GetInfoNV(maNV);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                textBoxSuaNameNV.Text = row["HoTen"].ToString();
                dateSuaNgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);

                string gioiTinh = row["GioiTinh"].ToString();
                if (gioiTinh == "Nam") raidoNamSuaNV.Checked = true;
                else if (gioiTinh == "Nữ") radioNuSuaNV.Checked = true;

                textBoxDiaChiSuaNV.Text = row["DiaChi"].ToString();
                textBoxSuaSDT.Text = row["SoDienThoai"].ToString();
                textSuaEmail.Text = row["Email"].ToString();

                comBoxPhongBanSuaNV.SelectedValue = row["MaPhong"].ToString();
                comBoxChuVuSuaNV.SelectedValue = row["MaChucVu"].ToString();

                comBoxTrangThaiSuaNV.Text = row["TrangThai"].ToString();
                dateNgayVaoLamSuaNV.Value = Convert.ToDateTime(row["NgayVaoLam"]);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
            }
        }


        private void buttonTimNVSua_Click(object sender, EventArgs e)
        {
            maNV = maNVSuaMaNV.Text;

            if (!string.IsNullOrEmpty(maNV))
            {
                LoadInfoNV(maNV);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!");
            }
        }

        private void buttonSuaNhanVien_Click(object sender, EventArgs e)
        {
            //Lấy thông tin từ Form
            string maNV = maNVSuaMaNV.Text;
            string hoTen = textBoxSuaNameNV.Text;
            DateTime ngaySinh = dateSuaNgaySinh.Value;
            string gioiTinh = raidoNamSuaNV.Checked ? "Nam" : "Nữ";
            string soDienThoai = textBoxSuaSDT.Text;
            string email = textSuaEmail.Text;
            string phongBan = comBoxPhongBanSuaNV.SelectedValue.ToString();
            string chucVu = comBoxChuVuSuaNV.SelectedValue.ToString();
            string trangThai = comBoxTrangThaiSuaNV.SelectedValue.ToString();
            string diaChi = textBoxDiaChiSuaNV.Text;
            DateTime ngayVaoLam = dateNgayVaoLamSuaNV.Value;

            bool result = controller.UpdateNV(maNV,hoTen, ngaySinh, gioiTinh, diaChi, soDienThoai, email, ngayVaoLam, phongBan, chucVu, trangThai);


            if (result)
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
            else
                MessageBox.Show("Sửa thông tin nhân viên thất bại!");
        }
    }
}
