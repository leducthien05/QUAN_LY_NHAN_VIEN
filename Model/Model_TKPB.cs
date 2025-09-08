using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN.Model
{
    class Model_TKPB
    {
        // Lấy danh sách nhân viên, hiển thị tất cả nhân viên dù có hợp đồng hay không
        public static DataTable GetData(string TenPhongBan = null, string GioiTinh = null)
        {
            string query = @"
                SELECT NV.MaNV, NV.HoTen, NV.NgaySinh, NV.GioiTinh, NV.DiaChi, NV.SoDienThoai, NV.Email,
                       NV.NgayVaoLam, NV.TrangThai, CV.TenChucVu, PB.TenPhong, 
                       ISNULL(HD.LoaiHD, '') AS LoaiHD, NV.GhiChu
                FROM NhanVien NV
                INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu
                INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong
                LEFT JOIN HopDong HD ON NV.MaNV = HD.MaNV
                WHERE 1=1";

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(TenPhongBan))
            {
                query += " AND PB.TenPhong = @TenPhongBan";
                parameters.Add(new SqlParameter("@TenPhongBan", TenPhongBan));
            }

            if (!string.IsNullOrEmpty(GioiTinh))
            {
                query += " AND NV.GioiTinh = @GioiTinh";
                parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
            }

            using (SqlConnection conn = Connect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy danh sách giới tính để combobox
        public static DataTable GetGioiTinh()
        {
            string query = @"SELECT DISTINCT GioiTinh FROM NhanVien";
            using (SqlConnection conn = Connect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Thống kê số lượng Nam/Nữ theo phòng ban
        public static DataTable GetGenderCountByDepartment(string TenPhong)
        {
            string query = @"
                SELECT 
                    SUM(CASE WHEN GioiTinh='Nam' THEN 1 ELSE 0 END) AS Nam,
                    SUM(CASE WHEN GioiTinh=N'Nữ' THEN 1 ELSE 0 END) AS Nu
                FROM NhanVien NV
                INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong
                WHERE PB.TenPhong = @TenPhong";

            using (SqlConnection conn = Connect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhong", TenPhong ?? "");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
