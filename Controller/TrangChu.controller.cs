using QUAN_LY_NHAN_VIEN.Model;
using System.Data;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    public class TrangChuController
    {
        private TrangChu model; // Model.TrangChu

        public TrangChuController()
        {
            model = new TrangChu(); // tạo đối tượng model
        }
//----------------------------------TỔNG QUAN NHÂN SỰ-----------------------------------------
        // Lấy tổng số nhân viên
        public int GetTongNhanVien()
        {
            return model.DemNhanVien();
        }

        // Lấy số nhân viên chính thức
        public int GetNhanVienChinhThuc()
        {
            return model.NhanVienChinhThuc();
        }

        //Lấy số nhân viên thử việc
        public int GetNhanVienThuViec()
        {
            return model.NhanVienThuViec();
        }

        //Lấy số thực tập sinh
        public int GetThucTapSinh()
        {
            return model.ThucTapSinh();
        }

        //Lấy số chức vụ giám đốc
        public int GetChucVuGiamDoc()
        {
            return model.ChucVuGiamDoc();
        }

        //Lấy số chức vụ quản lý
        public int GetChucVuQuanLy()
        {
            return model.ChucVuQuanLy();
        }

        //Lấy số chức vụ trưởng phòng
        public int GetChucVuTruongPhong()
        {
            return model.ChucVuTruongPhong();
        }

        //Lấy tổng số nhân viên nam
        public int GetTongSoNhanVienNam()
        {
            return model.TongSoNam();
        }

        //Lấy tổng số nhân viên nữ
        public int GetTongSoNhanVienNu()
        {
            return model.TongSoNu();
        }

        //Trả data phần Nhân viên
        public SqlDataReader LoadNhanVien()
        {
            return model.gridviewNhanVien();
        }

        //Trả data phần Chức vụ
        public SqlDataReader LoadChucVu()
        {
            return model.gridviewChucVu();
        }

        //Trả data phần Giới tính
        public SqlDataReader LoadGioiTinh()
        {
            return model.gridviewGioiTinh();
        }


//---------------------------------------TỔNG QUAN PHÒNG BAN----------------------------------
        //Lấy liên hệ phòng Nhân sự
        public string GetLienHePhongNhanSu()
        {
            return model.LienHePhongNhanSu();
        }

        //Lấy liên hệ phòng Tài Chính
        public string GetLienHePhongTaiChinh()
        {
            return model.LienHePhongTaiChinh();
        }

        //Lấy liên hệ phòng Tài Chính
        public string GetLienHePhongMarketing()
        {
            return model.LienHePhongMarketing();
        }

        //Lấy datagridView Phòng Nhân Sự
        public SqlDataReader LoadPhongNhanSu()
        {
            return model.gridviewPhongNhanSu();
        }

        //Lấy datagridView Phòng Nhân Sự
        public SqlDataReader LoadPhongTaiChinh()
        {
            return model.gridviewPhongTaiChinh();
        }

        //Lấy datagridView Phòng Nhân Sự
        public SqlDataReader LoadPhongMarketing()
        {
            return model.gridviewPhongMarketing();
        }
    }
}
