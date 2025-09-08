using System.Data;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    class Controller_TKPB
    {
        public static DataTable GetData(string TenPhongBan, string GioiTinh)
        {
            return Model.Model_TKPB.GetData(TenPhongBan, GioiTinh);
        }

        public static DataTable GetGioiTinh()
        {
            return Model.Model_TKPB.GetGioiTinh();
        }

        public static DataTable GetGenderCountByDepartment(string TenPhong)
        {
            return Model.Model_TKPB.GetGenderCountByDepartment(TenPhong);
        }
    }
}
