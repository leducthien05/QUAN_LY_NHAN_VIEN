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

    public class QLHD
    {
        private SqlConnection conn;

        public QLHD()
        {
            conn = Connect.GetConnection();
        }

        //Lấy dữ liệu ra gridview
        public SqlDataReader gridviewDanhSachHopDong()
        {
            string sql = @"SELECT * FROM HopDong";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Trả kết quả tìm kiếm
        public SqlDataReader GetHDSearch(string maHD, string maNV)
        {
            conn.Open();

            // Câu lệnh SQL: lấy tất cả thông tin của nhân viên có mã MaNV = @MaNV
            // Lưu ý: phải có khoảng trắng trước "WHERE" để câu lệnh hợp lệ
            string sql = @"SELECT * FROM HopDong
                           WHERE MaHD = @MaHD OR MaNV = @MaNV";


            // Tạo SqlCommand với câu lệnh SQL và kết nối
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaHD", maHD);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // Thêm phòng ban
        public bool AddHopDong(string maHD, string maNV,string loaiHd, DateTime ngayBD, DateTime ngayKT, string luongCB, string ghiChu)
        {
            try
            {
                conn.Open();
                string sql = @"INSERT INTO HopDong
                                    (MaHD, MaNV, LoaiHD, NgayBatDau, NgayKetThuc, LuongCoBan, GhiChu)
                            VALUES (@MaHD, @MaNV, @LoaiHD, @NgayBatDau, @NgayKetThuc, @LuongCoBan, @GhiChu)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@LoaiHD", loaiHd);
                cmd.Parameters.AddWithValue("@NgayBatDau", ngayBD);
                cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKT);
                cmd.Parameters.AddWithValue("@LuongCoBan", luongCB);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);



                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm hợp đồng: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        //Tạo mã hợp đồng
        public string TaoMaHD()
        {
            string newMaNV = "NV001";
            try
            {
                conn.Open();
                string sql = "SELECT TOP 1 MaHD FROM HopDong ORDER BY MaHD DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastMaNV = result.ToString();
                    int number = int.Parse(lastMaNV.Substring(2));
                    newMaNV = "HD" + (number + 1).ToString("D3");
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return newMaNV;
        }
        //Sửa thông tin phòng ban
            public bool UpdateHD(string maHD, string maNV, string loaiHD, DateTime ngayBD, DateTime ngayKT, string luongCB, string ghiChu)
            {
                try
                {
                    conn.Open();
                    string sql = @"UPDATE HopDong
                           SET MaHD = @MaHD,
                               MaNV = @MaNV,
                               LoaiHD = @LoaiHD,
                               NgayBatDau = @NgayBatDau,
                               NgayKetThuc = @NgayKetThuc,
                               LuongCoBan = @LuongCoBan,
                               GhiChu = @GhiChu
                           WHERE MaHD = @MaHD";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    // Gán tất cả tham số
                    cmd.Parameters.AddWithValue("@MaHD", maHD);
                    cmd.Parameters.AddWithValue("@MaNV", maNV);
                    cmd.Parameters.AddWithValue("@LoaiHD", loaiHD);
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngayBD);
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKT);
                    cmd.Parameters.AddWithValue("@LuongCoBan", luongCB);
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

        //Xóa hợp đồng
        public bool DeleteHD(string maHD, string maNV)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM HopDong WHERE MaHD = @MaHD OR (MaHD = @MaHD AND MaNV = @MaNV)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

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
