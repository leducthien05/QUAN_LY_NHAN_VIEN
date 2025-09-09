using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN
{
    public class Connect
    {
        private static string connectionString =
            @"Data Source=DESKTOP-RG8L6LR\SQLEXPRESS01;Initial Catalog=QUAN_LY_NHAN_VIEN;Integrated Security=True;TrustServerCertificate=True";

        // Hàm trả về SqlConnection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
