using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace QUAN_LY_NHAN_VIEN.Model
{
    public class Model
    {   // Lấy dữ liệu từ bảng Nhân Viên
        public DataTable GetNV()
        {
            using (SqlConnection conn = Connect.GetConnection())

            {
                string query = "SELECT * FROM NhanVien";
                SqlDataAdapter dt = new SqlDataAdapter(query, Connect.GetConnection());
                DataTable tb = new DataTable();
                dt.Fill(tb);
                return tb;
            }

        }
        // Lấy dữ liệu từ bảng Tài Khoản
        public DataTable GetTK()
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "SELECT * FROM TaiKhoan";
                SqlDataAdapter dt = new SqlDataAdapter(query, Connect.GetConnection());
                DataTable tb = new DataTable();
                dt.Fill(tb);
                return tb;
            }
        }
        // Lấy dữ liệu từ bảng ChucVu
        public DataTable GetCV()
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "SELECT * FROM ChucVu";
                SqlDataAdapter dt = new SqlDataAdapter(query, Connect.GetConnection());
                DataTable tb = new DataTable();
                dt.Fill(tb);
                return tb;
            }
        }
        // Lấy dữ liệu từ bảng PhongBan
        public DataTable GetPB()
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "SELECT * FROM PhongBan";
                SqlDataAdapter dt = new SqlDataAdapter(query, Connect.GetConnection());
                DataTable tb = new DataTable();
                dt.Fill(tb);
                return tb;
            }
        }
        // Lấy dữu liệu từ bảng BangLuong
        public DataTable GetBL()
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "SELECT * FROM BangLuong";
                SqlDataAdapter dt = new SqlDataAdapter(query, Connect.GetConnection());
                DataTable tb = new DataTable();
                dt.Fill(tb);
                return tb;
            }
        }
        // Thêm dữ liệu vào bảng Nhân Viên
        public bool AddNV(NhanVien nv)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "INSERT INTO NhanVien (MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, SDT, Email, MaChucVu, NgayVaoLam, MaPhong, GhiChu) " +
                               "VALUES (@MaNV, @HoTen, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @Email, @MaChucVu, @NgayVaoLam, @MaPhong, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.MaNV;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nv.HoTen;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = nv.NgaySinh;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nv.GioiTinh;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.DiaChi;
                    cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nv.SDT;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nv.Email;
                    cmd.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = nv.MaChucVu;
                    cmd.Parameters.Add("@NgayVaoLam", SqlDbType.Date).Value = nv.NgayVaoLam;
                    cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = nv.MaPhong;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = nv.GhiChu;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = (int)nv.TrangThai;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Cập nhật dữ liệu bảng Nhân Viên
        public bool UpdateNhanVien(NhanVien nv)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = @"UPDATE NhanVien SET TenNV=@TenNV, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, DiaChi=@DiaChi,
                                 SDT=@SDT, Email=@Email, MaChucVu=@MaChucVu, NgayVaoLam=@NgayVaoLam, MaPhong=@MaPhong,
                                 GhiChu=@GhiChu
                                 WHERE MaNV=@MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nv.MaNV;
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = nv.HoTen;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = nv.NgaySinh;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = nv.GioiTinh;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nv.DiaChi;
                    cmd.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nv.SDT;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = nv.Email;
                    cmd.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = nv.MaChucVu;
                    cmd.Parameters.Add("@NgayVaoLam", SqlDbType.Date).Value = nv.NgayVaoLam;
                    cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = nv.MaPhong;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = nv.GhiChu;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa dữ liệu bảng Nhân Viên
        public bool XoaNV(string maNV)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "UPDATE NhanVien SET TrangThai=@TrangThai WHERE MaNV=@MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                    cmd.Parameters.Add("@TrangThai", SqlDbType.Int).Value = (int)TrangThaiEnum.NghiViec;

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Thêm dữ liệu bảng Tài Khoản
        public bool AddTaiKhoan(TaiKhoan tk)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, Quyen, GhiChu) " +
                               "VALUES (@TenDangNhap, @MatKhau, @MaNV, @Quyen, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = tk.TenDangNhap;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = tk.MaNV;
                    cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tk.Quyen;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = tk.GhiChu;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Xóa dữ liệu bảng Tài Khoản
        public bool DeleteTaiKhoan(string MaNV)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "DELETE FROM TaiKhoan WHERE MaNV=@MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = MaNV;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Cập nhật dữ liệu bảng Tài Khoản
        public bool UpdateTaiKhoan(TaiKhoan tk)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau, MaNV = @MaNV, Quyen = @Quyen, GhiChu = @GhiChu" +
                    "WHERE MaNV = @MaNV";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@TenDangNhap", SqlDbType.NVarChar).Value = tk.TenDangNhap;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.NVarChar).Value = tk.MatKhau;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = tk.MaNV;
                    cmd.Parameters.Add("@Quyen", SqlDbType.NVarChar).Value = tk.Quyen;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = tk.GhiChu;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Thêm dữ liệu bảng Chức Vụ
        public bool AddChucVu(ChucVu cv)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "INSERT INTO ChucVu(MaChucVu, TenChucVu, GhiChu) " +
                               "VALUES (@MaChucVu, @TenChucVu, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = cv.MaChucVu;
                    cmd.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = cv.TenChucVu;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = cv.GhiChu;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Thêm dữ liệu bảng Chức Vụ
        public bool UpdateChucVu(ChucVu cv)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "UPDATE ChucVu SET TenChucVu=@TenChucVu, GhiChu=@GhiChu WHERE MaChucVu=@MaChucVu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = cv.MaChucVu;
                    cmd.Parameters.Add("@TenChucVu", SqlDbType.NVarChar).Value = cv.TenChucVu;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = cv.GhiChu;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa dữ liệu bảng Chức Vụ
        public bool DeleteChucVu(ChucVu cv)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "DELETE FROM ChucVu WHERE MaChucVu=@MaChucVu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaChucVu", SqlDbType.NVarChar).Value = cv.MaChucVu;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Thêm dữ liệu bảng Phòng Ban
        public bool AddPhongBan(PhongBan pb)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "INSERT INTO PhongBan(MaPhong, TenPhong, GhiChu, MoTa, LienHe) " +
                               "VALUES (@MaPhong, @TenPhong, @GhiChu, @MoTa, @LienHe)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = pb.MaPhong;
                    cmd.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = pb.TenPhong;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = pb.GhiChu;
                    cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = pb.MoTa;
                    cmd.Parameters.Add("@LienHe", SqlDbType.NVarChar).Value = pb.LienHe;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Cập nhật dữ liệu bảng Phòng Ban
        public bool UpdatePhongBan(PhongBan pb)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "UPDATE PhongBan SET TenPhong=@TenPhong, GhiChu=@GhiChu, MoTa=@MoTa, LienHe=@LienHe WHERE MaPhong=@MaPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = pb.MaPhong;
                    cmd.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = pb.TenPhong;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = pb.GhiChu;
                    cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = pb.MoTa;
                    cmd.Parameters.Add("@LienHe", SqlDbType.NVarChar).Value = pb.LienHe;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa dữ liệu bảng Phòng Ban
        public bool DeletePhongBan(PhongBan pb)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "DELETE FROM PhongBan WHERE MaPhong=@MaPhong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = pb.MaPhong;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Thêm dữ liệu bảng Hợp Đồng
        public bool AddHopDong(HopDong hd)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "INSERT INTO HopDong(MaHD, MaNV, NgayBatDau, NgayKetThuc, LoaiHD, GhiChu) " +
                               "VALUES (@MaHD, @MaNV, @NgayBatDau, @NgayKetThuc, @LoaiHD, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = hd.MaHD;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = hd.MaNV;
                    cmd.Parameters.Add("@NgayBatDau", SqlDbType.Date).Value = hd.NgayBatDau;
                    cmd.Parameters.Add("@NgayKetThuc", SqlDbType.Date).Value = hd.NgayKetThuc;
                    cmd.Parameters.Add("@LoaiHD", SqlDbType.NVarChar).Value = hd.LoaiHD;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = hd.GhiChu;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Cập nhật dữ liệu bảng Hợp Đồng
        public bool UpdateHopDong(HopDong hd)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "UPDATE HopDong SET MaNV=@MaNV, NgayBatDau=@NgayBatDau, NgayKetThuc=@NgayKetThuc, LoaiHD=@LoaiHD, GhiChu=@GhiChu WHERE MaHD=@MaHD";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = hd.MaHD;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = hd.MaNV;
                    cmd.Parameters.Add("@NgayBatDau", SqlDbType.Date).Value = hd.NgayBatDau;
                    cmd.Parameters.Add("@NgayKetThuc", SqlDbType.Date).Value = hd.NgayKetThuc;
                    cmd.Parameters.Add("@LoaiHD", SqlDbType.NVarChar).Value = hd.LoaiHD;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = hd.GhiChu;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa dữ liệu bảng Hợp Đồng
        public bool DeleteHopDong(HopDong hd)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "DELETE FROM HopDong WHERE MaHD=@MaHD";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = hd.MaHD;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Thêm dữ liệu bảng Bảng Lương
        public bool AddBangLuong(BangLuong bl)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "INSERT INTO BangLuong(MaBL, MaNV, Thang, Nam, LuongCoBan, HeSoLuong, PhuCap, GhiChu) " +
                               "VALUES (@MaBL, @MaNV, @Thang, @Nam, @LuongCoBan, @HeSoLuong, @PhuCap, @GhiChu)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaLuong", SqlDbType.NVarChar).Value = bl.MaLuong;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = bl.MaNV;
                    cmd.Parameters.Add("@LuongCoBan", SqlDbType.Decimal).Value = bl.LuongCoBan;
                    cmd.Parameters.Add("@HeSoLuong", SqlDbType.Decimal).Value = bl.HeSoLuong;
                    cmd.Parameters.Add("@PhuCap", SqlDbType.Decimal).Value = bl.PhuCap;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = bl.GhiChu;
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
        // Cập nhật dữ liệu bảng Bảng Lương
        public bool UpdateBangLuong(BangLuong bl)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "UPDATE BangLuong SET MaNV=@MaNV, LuongCoBan=@LuongCoBan, HeSoLuong=@HeSoLuong, PhuCap=@PhuCap, GhiChu=@GhiChu WHERE MaLuong=@MaLuong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaLuong", SqlDbType.NVarChar).Value = bl.MaLuong;
                    cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = bl.MaNV;
                    cmd.Parameters.Add("@LuongCoBan", SqlDbType.Decimal).Value = bl.LuongCoBan;
                    cmd.Parameters.Add("@HeSoLuong", SqlDbType.Decimal).Value = bl.HeSoLuong;
                    cmd.Parameters.Add("@PhuCap", SqlDbType.Decimal).Value = bl.PhuCap;
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = bl.GhiChu;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Xóa dữ liệu bảng Bảng Lương
        public bool DeleteBangLuong(BangLuong bl)
        {
            using (SqlConnection conn = Connect.GetConnection())
            {
                string query = "DELETE FROM BangLuong WHERE MaLuong=@MaLuong";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@MaLuong", SqlDbType.NVarChar).Value = bl.MaLuong;
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
