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
    public class QLPB
    {
        private SqlConnection conn;

        public QLPB()
        {
            conn = Connect.GetConnection();
        }

    //Lấy dữ liệu ra gridview
        public SqlDataReader gridviewDanhSachPhongBan()
        {
            string sql = @"SELECT * FROM PhongBan";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    //Trả kết quả tìm kiếm
        public SqlDataReader GetPBSearch(string maPhong, string TenPhong)
        {
            conn.Open();

            // Câu lệnh SQL: lấy tất cả thông tin của nhân viên có mã MaNV = @MaNV
            // Lưu ý: phải có khoảng trắng trước "WHERE" để câu lệnh hợp lệ
            string sql = @"SELECT * FROM PhongBan
                           WHERE MaPhong = @MaPhong OR TenPhong = @TenPhong";


            // Tạo SqlCommand với câu lệnh SQL và kết nối
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaPhong", maPhong);
            cmd.Parameters.AddWithValue("@TenPhong", TenPhong);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    // Thêm phòng ban
        public bool AddPhongBan(string maPhong, string tenPhong, string moTa, string lienHe, string trangThai, string ghiChu)
        {
            try
            {
                conn.Open();
                string sql = @"INSERT INTO PhongBan
                                    (MaPhong, TenPhong, MoTa, LienHe, TrangThai, GhiChu)
                            VALUES (@MaPhong, @TenPhong, @MoTa, @LienHe, @TrangThai, @GhiChu)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                cmd.Parameters.AddWithValue("@MoTa", moTa);
                cmd.Parameters.AddWithValue("@LienHe", lienHe);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                


                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng ban: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

    //Tạo mã phòng ban
        public string TaoMaPB()
        {
            string newMaNV = "NV001";
            try
            {
                conn.Open();
                string sql = "SELECT TOP 1 MaPhong FROM Phongban ORDER BY MaPhong DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastMaNV = result.ToString();  
                    int number = int.Parse(lastMaNV.Substring(2)); 
                    newMaNV = "P" + (number + 1).ToString("D3");  
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return newMaNV;
        }
    //Sửa thông tin phòng ban
        public bool UpdatePB(string maPhong, string tenPhong, string moTa, string lienHe, string trangThai, string ghiChu)
        {
            try
            {
                conn.Open();
                string sql = @"UPDATE PhongBan
                       SET TenPhong = @TenPhong,
                           MoTa = @MoTa,
                           LienHe = @LienHe,
                           TrangThai = @TrangThai
                       WHERE MaPhong = @MaPhong";

                SqlCommand cmd = new SqlCommand(sql, conn);
                // Gán tất cả tham số
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@TenPhong", tenPhong);
                cmd.Parameters.AddWithValue("@MoTa", moTa);
                cmd.Parameters.AddWithValue("@LienHe", lienHe);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);

                // Thực thi UPDATE
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; // true nếu có dòng bị cập nhật
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        //Xóa phòng ban
        public bool DeletePB(string maPhong, string tenPhong)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM PhongBan WHERE MaPhong = @MaPhong OR (TenPhong = @TenPhong AND MaPhong = @MaPhong)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@TenPhong", tenPhong);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0; // trả về true nếu xóa thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phòng ban: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
    }


}
