using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUAN_LY_NHAN_VIEN.Controller;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_TQNS: UserControl
    {
        private TrangChuController controller;
        public UC_TQNS()
        {
            InitializeComponent();
            controller = new TrangChuController();
            this.Load += UC_TQNS_Load;
        }

        private void UC_TQNS_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ controller
                int tongNV = controller.GetTongNhanVien();
                int nvChinhThuc = controller.GetNhanVienChinhThuc();

                // Hiển thị lên label (label1, label2 bạn đổi theo thiết kế Designer)
                txtTongNhanVien.Text = tongNV.ToString();
                txtNVChinhThuc.Text = nvChinhThuc.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
