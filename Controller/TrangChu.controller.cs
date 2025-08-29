using QUAN_LY_NHAN_VIEN.Model;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    public class TrangChuController
    {
        private TrangChu model; // Model.TrangChu

        public TrangChuController()
        {
            model = new TrangChu(); // tạo đối tượng model
        }

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
        public int NhanVienThuViec()
        {
            return model.NhanVienThuViec();
        }
    }
}
