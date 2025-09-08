using QUAN_LY_NHAN_VIEN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QUAN_LY_NHAN_VIEN.Controller
{
    class Controller_UC_TKNV
    {
        public static DataTable GetThongKeNV(string PhongBan, string ChucVu, string GioiTinh, string LoaiHD, DateTime? NgayBatDau, DateTime? NgayKetThuc, string TrangThai)
        {
            return Model.Model_UC_TKNV.GetNhanVien(PhongBan, ChucVu, GioiTinh, LoaiHD, NgayBatDau, NgayKetThuc, TrangThai);
        }
        public DataTable LayPhongBan()
        {
            return Model_UC_TKNV.GetPhongBan(); // gọi thẳng từ Model
        }

        public DataTable LayChucVu()
        {
            return Model_UC_TKNV.GetChucVu(); // gọi thẳng từ Model
        }

        public DataTable LayLoaiHD()
        {
            return Model_UC_TKNV.GetLoaiHD(); // gọi thẳng từ Model
        }
    }
}
