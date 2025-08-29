using System;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN.Model
{
    public class TrangChu
    {
        private SqlConnection conn;

        public TrangChu()
        {
            conn = Connect.GetConnection();
        }
        // Lấy tổng số nhân viên
        public int DemNhanVien()
        {
            int tong = 0;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                tong = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return tong;
        }

        // Lấy số nhân viên chính thức
        public int NhanVienChinhThuc()
        {
            int NVCT = 0;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                         "FROM NhanVien NV " +
                         "JOIN HopDong HD ON NV.MaNV = HD.MaNV " +
                         "WHERE HD.LoaiHD = N'Chính thức'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                NVCT = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
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
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "JOIN HopDong HD ON NV.MaNV = HD.MaNV " +
                             "WHERE HD.LoaiHD = N'Thu Viec'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                NVTV = (int)cmd.ExecuteScalar();
            }
            return NVTV;
        }
    }
}
