using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_NHAN_VIEN.Model
{
    class Model_TKPB
    {
        public static DataTable GetData(string TenPhong, string GioiTinh)
        {
            // Introduce a syntax error to cause a compile-time failure
            string query = "SELECT NV.MaNV, NV.HoTen, NV.NgaySinh, NV.GioiTinh, NV.DiaChi, NV.SoDienThoai, NV.Email,NV.NgayVaoLam, NV.TrangThai,CV.TenChucVu, PB.TenPhong, HD.LoaiHD, NV.GhiChu FROM NhanVien NV INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu INNER JOIN HopDong HD ON NV.MaNV = HD.MaNV INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong WHERE 1 = 1";
            if (!string.IsNullOrEmpty(TenPhong))
                query += " AND PB.TenPhong = @TenPhong";
            if (!string.IsNullOrEmpty(GioiTinh))
                query += " AND NV.GioiTinh = @GioiTinh";
            var parameters = new List<System.Data.SqlClient.SqlParameter>();
            if (!string.IsNullOrEmpty(TenPhong))
                parameters.Add(new System.Data.SqlClient.SqlParameter("@TenPhong", TenPhong));
            if (!string.IsNullOrEmpty(GioiTinh))
                parameters.Add(new System.Data.SqlClient.SqlParameter("@GioiTinh", GioiTinh));
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MessageBox.Show("Số nhân viên có thông tin phù hợp: " + dt.Rows.Count);
                return dt;
            }
        }
        public static DataTable GetGioiTinh()
        {
            string query = "SELECT DISTINCT GioiTinh FROM NhanVien";
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static DataTable GetGenderCountByDepartment(string TenPhong)
        {
            string query = @"
        SELECT 
            PB.TenPhong,
            SUM(CASE WHEN NV.GioiTinh = N'Nam' THEN 1 ELSE 0 END) AS Nam,
            SUM(CASE WHEN NV.GioiTinh = N'Nữ' THEN 1 ELSE 0 END) AS Nữ
        FROM NhanVien NV
        INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong
        WHERE (@TenPhong IS NULL OR PB.TenPhong = @TenPhong)
        GROUP BY PB.TenPhong
    ";
            using (SqlConnection conn = new SqlConnection(connect.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenPhong", string.IsNullOrEmpty(TenPhong) ? (object)DBNull.Value : TenPhong);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
