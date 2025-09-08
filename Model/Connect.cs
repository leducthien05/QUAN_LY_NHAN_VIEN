using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN
{
    public class Connect
    {
        private static string connectionString =
            @"Data Source=DreamIsYou;
              Initial Catalog=QUAN_LY_NHAN_VIEN;
              Integrated Security=True;
              Trust Server Certificate=True";

        // Hàm trả về SqlConnection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
