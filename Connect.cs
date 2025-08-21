using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN
{
    class Connect
    {
        private string connect = "Data Source=DESKTOP-RG8L6LR\\SQLEXPRESS01;Initial Catalog=QUAN_LY_NHAN_VIEN;Integrated Security=True;Trust Server Certificate=True";

        // Hàm trả về SqlConnection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connect);
        }
    }
}
