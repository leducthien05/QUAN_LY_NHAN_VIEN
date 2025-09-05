using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class FormDangNhap: Form
    {
        private SqlConnection conn;
        public FormDangNhap()
        {
            InitializeComponent();
            conn = Connect.GetConnection();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormDangNhap Login = new FormDangNhap();
            
            this.Close();
        }
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string TenDN = TenDangNhap.Text;
                string Pass = MatKhau.Text;

                string sql = "SELECT * FROM TaiKhoan WHERE MatKhau =  @MatKhau AND TenDangNhap = @TenDangNhap";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MatKhau", Pass);
                cmd.Parameters.AddWithValue("@TenDangNhap", TenDN);

                SqlDataReader reader = cmd.ExecuteReader();
                if (string.IsNullOrEmpty(TenDN) || string.IsNullOrEmpty(Pass))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (reader.HasRows)
                {
                    while (reader.Read() == true)
                    {
                        this.Hide();
                        FormDashboard Dashboard = new FormDashboard();
                        Dashboard.ShowDialog();
                        Dashboard = null;
                        MatKhau.Text = "";
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void HienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái của CheckBox (sender)
            if (HienThiMK.Checked) // Giả sử tên của CheckBox là HienThiMK
            {
                // Nếu được chọn, hiển thị mật khẩu bằng cách gán ký tự rỗng '\0'
                MatKhau.PasswordChar = '\0';
            }
            else
            {
                // Nếu không được chọn, ẩn mật khẩu bằng ký tự '*'
                MatKhau.PasswordChar = '*';
            }
        }
    }
}
