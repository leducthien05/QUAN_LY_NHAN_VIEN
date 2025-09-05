using QUAN_LY_NHAN_VIEN.Model;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    public class QLNVcontroller
    {
        private QLNV model;

        public QLNVcontroller()
        {
            model = new QLNV();
        }

//--------------------------------TRANG THÊM MỚI NHÂN VIÊN-------------------------------------
        
        //Lấy Phòng Ban 
        public DataTable GetPhongBanQLNV()
        {
            return model.GetPhongBan();
        }

        //Lấy Chức Vụ
        public DataTable GetChucVuQLNV()
        {
            return model.GetChucVu();
        }

        //Lấy Trạng Thái
        public string[] GetTrangThai() { 
            return new string[] { "Chính thức", "Thử việc", "Thực tập sinh" }; 
        }

        //Tạo Mã Nhân Viên
        public string GenerateMaNV()
        {
            return model.TaoMaNV();
        }

        //Thêm mới Nhân Viên
        public bool AddNhanVien(string maNV, string tenNV, DateTime ngaySinh, string gioiTinh, string maChucVu, string maPhong, string trangThai, DateTime ngayVaoLam, string email, string soDienThoai, string diaChi, string ghiChu)
        {
            return model.AddNhanVien(maNV, tenNV, ngaySinh, gioiTinh, maChucVu, maPhong, trangThai, ngayVaoLam, email, soDienThoai, diaChi, ghiChu);
        }

        //---------------------------------SỬA THÔNG TIN NHÂN VIÊN-------------------------------------

        //Lấy Chức Vụ
        public DataTable GetPhongBanSuaNVQLNV()
        {
            return model.GetPhongBanSuaNV();
        }

        //Lấy Chức Vụ
        public DataTable GetChucVuSuaNVQLNV()
        {
            return model.GetChucVuSuaNV();
        }

        //Lấy Trạng Thái
        public string[] GetTrangThaiSuaNV()
        {
            return new string[] { "Chính thức", "Thử việc", "Thực tập sinh" };
        }

        //Lấy thông tin nhân viên cần sửa
        public DataTable GetInfoNV(string maNV)
        {
            // Gọi Model để lấy thông tin nhân viên theo MaNV
            return model.GetNVSua(maNV);
        }

        //Lưu thông tin khi sửa 
        public bool UpdateNV(string maNV, string hoTen, DateTime ngaySinh, string gioiTinh,
                             string diaChi, string sdt, string email, DateTime ngayVaoLam,
                             string maPhong, string maChucVu, string trangThai)
        {
            // Gọi hàm UpdateNV trong model
            return model.UpdateNV(maNV, hoTen, ngaySinh, gioiTinh,
                                  diaChi, sdt, email, ngayVaoLam,
                                  maPhong, maChucVu, trangThai);
        }
    }
}
