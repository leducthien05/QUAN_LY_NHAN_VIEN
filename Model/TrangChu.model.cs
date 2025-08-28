using System;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN.Model
{
    public class TrangChu
    {
        // Lấy tổng số nhân viên
        public int DemNhanVien()
        {
            int tong = 0;
            using (SqlConnection conn = Connect.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                tong = (int)cmd.ExecuteScalar();
            }
            return tong;
        }

        // Lấy số nhân viên chính thức
        public int NhanVienChinhThuc()
        {
            int NVCT = 0;
            using (SqlConnection conn = Connect.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien WHERE GhiChu = N'Chính Thức'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                NVCT = (int)cmd.ExecuteScalar();
            }
            return NVCT;
        }

        // Lấy số nhân viên thử việc
        public int NhanVienThuViec()
        {
            int NVTV = 0;
            using (SqlConnection conn = Connect.GetConnection())
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien WHERE GhiChu = N'Thử Việc'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                NVTV = (int)cmd.ExecuteScalar();
            }
            return NVTV;
        }
    }
}
