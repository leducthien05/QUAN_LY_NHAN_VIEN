using QUAN_LY_NHAN_VIEN.Model;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    public class QLHDcontroller
    {
        private QLHD model;

        public QLHDcontroller()
        {
            model = new QLHD();
        }

        //Lấy danh sách hợp đồng
        public SqlDataReader DanhSachHopDong()
        {
            return model.gridviewDanhSachHopDong();
        }

        //Trả kết quả ra gridView
        public SqlDataReader GetResultSearchHD(string maHD, string maNV)
        {
            // Gọi Model để lấy thông tin nhân viên theo MaNV hoặc HoTen
            return model.GetHDSearch(maHD, maNV);
        }

        //Thêm hợp đồng
        public bool AddHopDongMoi(string maHD, string maNV, string loaiHD, DateTime ngayBD, DateTime ngayKT, string luongCB, string ghiChu)
        {
            return model.AddHopDong(maHD, maNV, loaiHD, ngayBD, ngayKT, luongCB, ghiChu);
        }

        //Load loại hợp đồng
        public string[] GetLoaiHD()
        {
            return new string[] { "Chính thức", "Thử việc", "Thực tập sinh","Dài hạn", "Hợp đồng 1 năm" };
        }

        //Tạo mã hợp đồng
        public string GenerateMaHD()
        {
            return model.TaoMaHD();
        }

        //Sửa thông tin hợp đồng
        public bool UpdateHopDong(string maHD, string maNV, string loaiHD, DateTime ngayBD, DateTime ngayKT, string luongCB, string ghiChu)
        {
            return model.UpdateHD(maHD, maNV, loaiHD, ngayBD, ngayKT, luongCB, ghiChu);
        }

        //Xóa phòng ban
        public bool deleteHD(string maHD, string maNV)
        {
            return model.DeleteHD(maHD, maNV);
        }
    }
}
