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
    public class QLNV
    {
        private SqlConnection conn;

        public QLNV()
        {
            conn = Connect.GetConnection();
        }

//------------------------------------------THÊM MỚI NHÂN VIÊN---------------------------------
        // Lấy danh sách phòng ban
        public DataTable GetPhongBan()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT MaPhong, TenPhong FROM PhongBan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return dt;
        }

        // Lấy danh sách chức vụ
        public DataTable GetChucVu()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT MaChucVu, TenChucVu FROM ChucVu";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return dt;
        }

        // Thêm Nhân Viên
        public bool AddNhanVien(string maNV, string tenNV, DateTime ngaySinh, string gioiTinh, string maChucVu, string maPhong, string trangThai, DateTime ngayVaoLam, string email, string soDienThoai, string diaChi, string ghiChu)
        {
            try
            {
                conn.Open();
                string sql = @"INSERT INTO NhanVien
                                    (MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email, 
                                    MaPhong, MaChucVu, TrangThai, GhiChu, NgayVaoLam )
                            VALUES (@MaNV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SoDienThoai, @Email,
                                    @MaPhong, @MaChucVu, @TrangThai, @GhiChu, @NgayVaoLam)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@HoTen", tenNV);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmd.Parameters.AddWithValue("@NgayVaoLam", ngayVaoLam);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@Email", email);


                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

        public string TaoMaNV()
        {
            string newMaNV = "NV001";
            try
            {
                conn.Open();
                string sql = "SELECT TOP 1 MaNV FROM NhanVien ORDER BY MaNV DESC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string lastMaNV = result.ToString();   // ví dụ: NV007
                    int number = int.Parse(lastMaNV.Substring(2)); // lấy số 7
                    newMaNV = "NV" + (number + 1).ToString("D3");  // -> NV008
                }
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return newMaNV;
        }
        //--------------------------------------SỬA THÔNG TIN NHÂN VIÊN--------------------------------

        // Lấy danh sách phòng ban
        public DataTable GetPhongBanSuaNV()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT MaPhong, TenPhong FROM PhongBan";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return dt;
        }

        // Lấy danh sách chức vụ
        public DataTable GetChucVuSuaNV()
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string sql = "SELECT MaChucVu, TenChucVu FROM ChucVu";
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return dt;
        }

        //Lấy thông tin nhân viên cần sửa
        public DataTable GetNVSua(string maNV)
        {
            // Tạo DataTable rỗng để chứa dữ liệu nhân viên lấy từ SQL Server
            DataTable dt = new DataTable();

            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                conn.Open();

                // Câu lệnh SQL: lấy tất cả thông tin của nhân viên có mã MaNV = @MaNV
                // Lưu ý: phải có khoảng trắng trước "WHERE" để câu lệnh hợp lệ
                string sql = "SELECT " +
                                    "MaNV, HoTen, NgaySinh, GioiTinh, " +
                                    "DiaChi, SoDienThoai, Email, MaPhong, " +
                                    "MaChucVu, TrangThai, GhiChu, NgayVaoLam " +
                             "FROM NhanVien" +
                             " WHERE MaNV = @MaNV";

                // Tạo SqlCommand với câu lệnh SQL và kết nối
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Gán giá trị cho tham số @MaNV trong câu lệnh SQL
                // Điều này giúp tránh SQL Injection và tự động xử lý kiểu dữ liệu
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                // SqlDataAdapter giúp kết nối giữa SQL Server và DataTable
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Điền dữ liệu từ SQL Server vào DataTable
                da.Fill(dt);
            }
            finally
            {
                // Đảm bảo đóng kết nối nếu nó đang mở, tránh rò rỉ kết nối
                if (conn.State == ConnectionState.Open) conn.Close();
            }

            // Trả về DataTable chứa thông tin nhân viên (có thể rỗng nếu không tìm thấy)
            return dt;
        }

        //Lưu thông tin nhân viên khi sửa
        public bool UpdateNV(string maNV, string hoTen, DateTime ngaySinh, string gioiTinh,
                     string diaChi, string sdt, string email, DateTime ngayVaoLam,
                     string maPhong, string maChucVu, string trangThai)
        {
            try
            {
                conn.Open();
                string sql = @"UPDATE NhanVien
                       SET HoTen = @HoTen,
                           NgaySinh = @NgaySinh,
                           GioiTinh = @GioiTinh,
                           DiaChi = @DiaChi,
                           SoDienThoai = @SoDienThoai,
                           Email = @Email,
                           NgayVaoLam = @NgayVaoLam,
                           MaPhong = @MaPhong,
                           MaChucVu = @MaChucVu,
                           TrangThai = @TrangThai
                       WHERE MaNV = @MaNV";

                SqlCommand cmd = new SqlCommand(sql, conn);
                // Gán tất cả tham số
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@SoDienThoai", sdt);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@NgayVaoLam", ngayVaoLam);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.Parameters.AddWithValue("@MaChucVu", maChucVu);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                // Thực thi UPDATE
                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0; // true nếu có dòng bị cập nhật
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }

//---------------------------------DANH SÁCH NHÂN VIÊN----------------------------------------

        //Lấy thông tin trả ra dataGridView
        public SqlDataReader gridviewDanhSachNhanVien()
        {
            string sql = @"SELECT NhanVien.MaNV, NhanVien.HoTen, NhanVien.NgaySinh, NhanVien.GioiTinh, NhanVien.DiaChi, NhanVien.SoDienThoai, NhanVien.Email, NhanVien.NgayVaoLam, PhongBan.TenPhong, ChucVu.TenChucVu, NhanVien.TrangThai, HopDong.NgayKetThuc
                           FROM NhanVien 
                            JOIN ChucVu ON NhanVien.MaChucVu = ChucVu.MaChucVu
                            JOIN PhongBan ON NhanVien.MaPhong = PhongBan.MaPhong
                            LEFT JOIN HopDong ON NhanVien.MaNV = HopDong.MaNV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Tìm kiếm nhân viên
        public SqlDataReader GetNVSearch(string maNV, string hoTen)
        {
            conn.Open();

            // Câu lệnh SQL: lấy tất cả thông tin của nhân viên có mã MaNV = @MaNV
            // Lưu ý: phải có khoảng trắng trước "WHERE" để câu lệnh hợp lệ
            string sql = @"SELECT NhanVien.MaNV, NhanVien.HoTen, NhanVien.NgaySinh, NhanVien.GioiTinh, NhanVien.DiaChi, NhanVien.SoDienThoai, NhanVien.Email, NhanVien.NgayVaoLam, PhongBan.TenPhong, ChucVu.TenChucVu, NhanVien.TrangThai, HopDong.NgayKetThuc
                           FROM NhanVien
                            JOIN ChucVu ON NhanVien.MaChucVu = ChucVu.MaChucVu
                            JOIN PhongBan ON NhanVien.MaPhong = PhongBan.MaPhong
                            LEFT JOIN HopDong ON NhanVien.MaNV = HopDong.MaNV
                            WHERE NhanVien.MaNV = @MaNV OR NhanVien.HoTen = @HoTen AND PhongBan.TrangThai = N'Hoạt động'";


            // Tạo SqlCommand với câu lệnh SQL và kết nối
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Xóa nhân viên
        public bool DeleteNV(string maNV, string hoTen)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV OR (HoTen = @HoTen AND MaNV = @MaNV)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0; // trả về true nếu xóa thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
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

