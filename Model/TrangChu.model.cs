using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace QUAN_LY_NHAN_VIEN.Model
{
    public class TrangChu
    {
        private SqlConnection conn;

        public TrangChu()
        {
            conn = Connect.GetConnection();
        }
//------------------------------------------TỔNG QUAN NHÂN SỰ------------------------------------
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
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "JOIN HopDong HD ON NV.MaNV = HD.MaNV " +
                             "WHERE HD.LoaiHD = N'Thu Viec'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                NVTV = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return NVTV;
        }

        // Lấy số thực tập sinh
        public int ThucTapSinh()
        {
            int TTS;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "JOIN HopDong HD ON NV.MaNV = HD.MaNV " +
                             "WHERE HD.LoaiHD = N'Thuc tap sinh'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                TTS = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return TTS;
        }

        //Lấy số chức vụ giám đốc
        public int ChucVuGiamDoc()
        {
            int GiamDoc;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu " +
                             "WHERE CV.TenChucVu = N'Giám Đốc'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                GiamDoc = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return GiamDoc;
        }

        //Lấy số chức vụ quản lý
        public int ChucVuQuanLy()
        {
            int QuanLy;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu " +
                             "WHERE CV.TenChucVu = N'Quản Lý'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                QuanLy = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return QuanLy;
        }

        //Lấy số chức vụ trưởng phòng
        public int ChucVuTruongPhong()
        {
            int TruongPhong;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu " +
                             "WHERE CV.TenChucVu = N'Trưởng Phòng'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                TruongPhong = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return TruongPhong;
        }

        //Lấy số nhân viên nam
        public int TongSoNam()
        {
            int Nam;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "WHERE NV.GioiTinh = N'Nam'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                Nam = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return Nam;
        }

        //Lấy số nhân viên nữ
        public int TongSoNu()
        {
            int Nu;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) " +
                             "FROM NhanVien NV " +
                             "WHERE NV.GioiTinh = N'Nữ'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                Nu = (int)cmd.ExecuteScalar();
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return Nu;
        }

        //Lấy thông tin trả ra dataGridView ô Nhân viên
        public SqlDataReader gridviewNhanVien()
        {
            string sql = @"SELECT NV.MaNV, NV.HoTen, PB.TenPhong 
                   FROM NhanVien NV
                   JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Lấy thông tin trả ra dataGridView ô Chức vụ
        public SqlDataReader gridviewChucVu()
        {
            string sql = @"SELECT NV.MaNV, NV.HoTen, CV.TenChucVu
                   FROM NhanVien NV
                   JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Lấy thông tin trả ra dataGridView ô Giới tính
        public SqlDataReader gridviewGioiTinh()
        {
            string sql = @"SELECT NV.MaNV, NV.HoTen, NV.GioiTinh
                   FROM NhanVien NV";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
//------------------------------------TỔNG QUAN PHÒNG BAN-------------------------------------
        //Liên hệ phòng Nhân sự
        public String LienHePhongNhanSu()
        {
            string lienHe = ""; // Khởi tạo biến lưu thông tin liên hệ
            try
            {
                conn.Open();
                string sql = "SELECT LienHe FROM PhongBan WHERE TenPhong = N'Phòng Nhân Sự'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lienHe = result.ToString();
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return lienHe;
        }

        //Liên hệ phòng Tài chính
        public String LienHePhongTaiChinh()
        {
            string lienHe = ""; // Khởi tạo biến lưu thông tin liên hệ
            try
            {
                conn.Open();
                string sql = "SELECT LienHe FROM PhongBan WHERE TenPhong = N'Phòng Tài Chính'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lienHe = result.ToString();
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return lienHe;
        }

        //Liên hệ phòng Marketing
        public String LienHePhongMarketing()
        {
            string lienHe = ""; // Khởi tạo biến lưu thông tin liên hệ
            try
            {
                conn.Open();
                string sql = "SELECT LienHe FROM PhongBan WHERE TenPhong = N'Phòng Marketing'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    lienHe = result.ToString();
                }
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return lienHe;
        }

        //Lấy dữ liệu trả ra datagridView Phòng Nhân Sự
        public SqlDataReader gridviewPhongNhanSu()
        {
            string sql ="SELECT NV.MaNV, NV.HoTen, CV.TenChucVu" +
                " FROM NhanVien NV " +
                "JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong " +
                "JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu " +
                "WHERE PB.TenPhong = N'Phòng Nhân Sự'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Lấy dữ liệu trả ra datagridView Phòng Tài Chính
        public SqlDataReader gridviewPhongTaiChinh()
        {
            string sql = "SELECT NV.MaNV, NV.HoTen, CV.TenChucVu" +
                " FROM NhanVien NV " +
                "JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong " +
                "JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu " +
                "WHERE PB.TenPhong = N'Tài Chính'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //Lấy dữ liệu trả ra datagridView Phòng Marketing
        public SqlDataReader gridviewPhongMarketing()
        {
            string sql = "SELECT NV.MaNV, NV.HoTen, CV.TenChucVu" +
                " FROM NhanVien NV " +
                "JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong " +
                "JOIN ChucVu CV ON NV.MaChucVu = CV.MaChucVu " +
                "WHERE PB.TenPhong = N'Marketing'";

            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}
