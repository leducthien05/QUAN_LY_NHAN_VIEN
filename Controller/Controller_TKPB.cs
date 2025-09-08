using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    class Controller_TKPB
    {
        public static System.Data.DataTable GetData(string TenPhongBan, string GioiTinh)
        {
            return Model.Model_TKPB.GetData(TenPhongBan, GioiTinh);
        }
        public System.Data.DataTable GetGioiTinh()
        {
            return Model.Model_TKPB.GetGioiTinh();
        }
        public static System.Data.DataTable GetGenderCountByDepartment(string TenPhong)
        {
            return Model.Model_TKPB.GetGenderCountByDepartment(TenPhong);
        }
    }
}
