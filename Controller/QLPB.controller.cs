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
    public class QLPBcontroller
    {
        private QLPB model;

        public QLPBcontroller()
        {
            model = new QLPB();
        }

    //Lấy danh sách phòng ban
        public SqlDataReader DanhSachPhongBan()
        {
            return model.gridviewDanhSachPhongBan();
        }

    //Trả kết quả ra gridView
        public SqlDataReader GetResultSearchPB(string maPhong, string TenPhong)
        {
            // Gọi Model để lấy thông tin nhân viên theo MaNV hoặc HoTen
            return model.GetPBSearch(maPhong, TenPhong);
        }

    //Thêm phòng ban
        public bool AddPhongBanMoi(string maPhong, string tenPhong, string moTa, string lienHe, string trangThai, string ghiChu)
        {
            return model.AddPhongBan(maPhong, tenPhong, moTa, lienHe, trangThai, ghiChu);
        }

    //Tạo mã phòng
        public string GenerateMaPB()
        {
            return model.TaoMaPB();
        }
    //Sửa thông tin phòng ban
        public bool UpdatePhongBan(string maPhong, string tenPhong, string moTa, string lienHe, string trangThai, string ghiChu)
        {
            return model.UpdatePB(maPhong, tenPhong, moTa, lienHe, trangThai, ghiChu);
        }

        //Xóa phòng ban
        public bool deletePB(string maPB, string tenPhong)
        {
            return model.DeletePB(maPB, tenPhong);
        }
    }

    
}
