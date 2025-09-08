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
    class Model_UC_TKNV
    {
        public static DataTable GetNhanVien(string PhongBan, string ChucVu, string GioiTinh, string LoaiHD, DateTime? NgayBatDau, DateTime? NgayKetThuc, string TrangThai)
        {
            string query = @"SELECT NV.MaNV, NV.HoTen, NV.NgaySinh, NV.GioiTinh, NV.DiaChi, NV.SoDienThoai, NV.Email,
                                NV.NgayVaoLam, NV.TrangThai, CV.TenChucVu, PB.TenPhong, HD.LoaiHD, NV.GhiChu
                            FROM NhanVien NV
                            INNER JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu
                            LEFT JOIN HopDong HD ON NV.MaNV = HD.MaNV
                            INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong
                            WHERE 1=1";

            if (!string.IsNullOrEmpty(PhongBan))
                query += " AND PB.TenPhong = @PhongBan";

            if (!string.IsNullOrEmpty(ChucVu))
                query += " AND CV.TenChucVu = @ChucVu";

            if (!string.IsNullOrEmpty(GioiTinh))
                query += " AND NV.GioiTinh = @GioiTinh";

            //if (!string.IsNullOrEmpty(LoaiHD))
            //    query += " AND HD.LoaiHD = @LoaiHD";

            if (NgayBatDau.HasValue)
            {
                if (NgayKetThuc.HasValue)
                    query += " AND NV.NgayVaoLam BETWEEN @NgayBatDau AND @NgayKetThuc";
                else
                    query += " AND NV.NgayVaoLam >= @NgayBatDau";
            }

            if (NgayKetThuc.HasValue && !NgayBatDau.HasValue)
                query += " AND NV.NgayVaoLam <= @NgayKetThuc";

            if (!string.IsNullOrEmpty(TrangThai))
                query += " AND NV.TrangThai = @TrangThai";

            var parameters = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(PhongBan))
                parameters.Add(new SqlParameter("@PhongBan", PhongBan));
            if (!string.IsNullOrEmpty(ChucVu))
                parameters.Add(new SqlParameter("@ChucVu", ChucVu));
            if (!string.IsNullOrEmpty(GioiTinh))
                parameters.Add(new SqlParameter("@GioiTinh", GioiTinh));
            if (!string.IsNullOrEmpty(LoaiHD))
                parameters.Add(new SqlParameter("@LoaiHD", LoaiHD));
            if (NgayBatDau.HasValue)
                parameters.Add(new SqlParameter("@NgayBatDau", NgayBatDau.Value));
            if (NgayKetThuc.HasValue)
                parameters.Add(new SqlParameter("@NgayKetThuc", NgayKetThuc.Value));
            if (!string.IsNullOrEmpty(TrangThai))
                parameters.Add(new SqlParameter("@TrangThai", TrangThai));

            using (SqlConnection conn = Connect.GetConnection())
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

        public static DataTable GetPhongBan()
        {
            string query = "SELECT MaPhong, TenPhong FROM PhongBan";

            using (SqlConnection conn = Connect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetChucVu()
        {
            string query = "SELECT MaChucVu, TenChucVu FROM ChucVu";

            using (SqlConnection conn = Connect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static DataTable GetLoaiHD()
        {
            string query = "SELECT DISTINCT LoaiHD FROM HopDong";

            using (SqlConnection conn = Connect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
