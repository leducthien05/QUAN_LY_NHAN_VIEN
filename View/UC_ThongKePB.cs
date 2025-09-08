using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_ThongKePB : UserControl
    {
        string connectionString = @"
              Data Source=DreamIsYou;
                Initial Catalog=QLNV;
                Integrated Security=True";

        public UC_ThongKePB()
        {
            InitializeComponent();
        }

        private void UC_ThongKePB_Load(object sender, EventArgs e)
        {
            LoadPhongBan();
            LoadGioiTinhCTY();
            LoadLoaiHDCTY();
        }

        private void LoadPhongBan()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT MaPhong, TenPhong FROM PhongBan";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.DataSource = dt.Copy();
                comboBox1.DisplayMember = "TenPhong";
                comboBox1.ValueMember = "MaPhong";

                comboBox2.DataSource = dt.Copy();
                comboBox2.DisplayMember = "TenPhong";
                comboBox2.ValueMember = "MaPhong";
            }
        }

        private void LoadGioiTinhCTY()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    SUM(CASE WHEN GioiTinh = N'Nam' THEN 1 ELSE 0 END) AS SoNam,
                                    SUM(CASE WHEN GioiTinh = N'Nữ' THEN 1 ELSE 0 END) AS SoNu
                                 FROM NhanVien";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chartGioiTinhCTY.Series[0].Points.Clear();
                if (reader.Read())
                {
                    chartGioiTinhCTY.Series[0].Points.AddXY("Nam", reader["SoNam"]);
                    chartGioiTinhCTY.Series[0].Points.AddXY("Nữ", reader["SoNu"]);
                }
                conn.Close();
            }
        }

        private void LoadGioiTinhPB(string maPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    SUM(CASE WHEN GioiTinh = N'Nam' THEN 1 ELSE 0 END) AS SoNam,
                                    SUM(CASE WHEN GioiTinh = N'Nữ' THEN 1 ELSE 0 END) AS SoNu
                                 FROM NhanVien
                                 WHERE MaPhong = @MaPhong";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chartGioiTinhPB.Series[0].Points.Clear();
                if (reader.Read())
                {
                    chartGioiTinhPB.Series[0].Points.AddXY("Nam", reader["SoNam"]);
                    chartGioiTinhPB.Series[0].Points.AddXY("Nữ", reader["SoNu"]);
                }
                conn.Close();
            }
        }

        private void LoadLoaiHDCTY()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT LoaiHD, COUNT(*) AS SoLuong
                                 FROM HopDong
                                 GROUP BY LoaiHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chartLoaiHDCTY.Series[0].Points.Clear();
                while (reader.Read())
                {
                    chartLoaiHDCTY.Series[0].Points.AddXY(reader["LoaiHD"].ToString(), reader["SoLuong"]);
                }
                conn.Close();
            }
        }

        private void LoadLoaiHDPB(string maPhong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT HD.LoaiHD, COUNT(*) AS SoLuong
                                 FROM HopDong HD
                                 JOIN NhanVien NV ON HD.MaNV = NV.MaNV
                                 WHERE NV.MaPhong = @MaPhong
                                 GROUP BY HD.LoaiHD";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                chartLoaiHDPB.Series[0].Points.Clear();
                while (reader.Read())
                {
                    chartLoaiHDPB.Series[0].Points.AddXY(reader["LoaiHD"].ToString(), reader["SoLuong"]);
                }
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                string maPhong = comboBox1.SelectedValue.ToString();
                LoadGioiTinhPB(maPhong);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                string maPhong = comboBox2.SelectedValue.ToString();
                LoadLoaiHDPB(maPhong);
            }
        }
    }
}
