using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QUAN_LY_NHAN_VIEN.Model
{
    public class DoiMK
    {
        private SqlConnection conn;

        public DoiMK()
        {
            conn = Connect.GetConnection();
        }

        //Lấy thông tin để so sánh
        // ✅ Lấy mật khẩu hiện tại từ DB
        public string GetPassword(string tenTK, string maNV)
        {
            try
            {
                conn.Open();
                string sql = "SELECT MatKhau FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MaNV = @MaNV";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenTK);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                object result = cmd.ExecuteScalar();
                return result == null ? null : result.ToString();
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public bool UpdateMK(string tenTK, string MK, string maNV)
        {
            try
            {
                conn.Open();
                string sql = @"UPDATE TaiKhoan
                                SET MatKhau = @MatKhau
                                WHERE (TenDangNhap = @TenDangNhap AND MaNV = @MaNV) ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                // Gán tất cả tham số
                cmd.Parameters.AddWithValue("@MatKhau", MK);
                cmd.Parameters.AddWithValue("@TenDangNhap", tenTK);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                // Thực thi UPDATE
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; // true nếu có dòng bị cập nhật
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }


    }
}
