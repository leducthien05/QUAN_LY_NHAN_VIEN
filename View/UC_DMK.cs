using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.AnimatorNS;
using System.Web.UI.WebControls;
using QUAN_LY_NHAN_VIEN.Controller;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_DMK: UserControl
    {
        private DoiMKcontroller controller;
        public UC_DMK()
        {
            InitializeComponent();
            controller = new DoiMKcontroller();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string tenTK = tenDanhNhap.Text;
            string maNV = textBoxMaNV.Text;
            string MKCu = textBoxMKCu.Text;
            string MKMoi = textBoxMKmoi.Text;
            string MKDB = controller.GetPassWordDB(tenTK, maNV);
            bool result = false;
            if (MKCu == MKDB)
            {
                result = controller.UpdateMKNew(tenTK, MKMoi, maNV);
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!");
            }

            if (result)
                MessageBox.Show("Đổi mật khẩu thành công!");
            else
                MessageBox.Show("Đổi mật khẩu thất bại!");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tenDanhNhap.Text = "";
            textBoxMaNV.Text = "";
            textBoxMKCu.Text = "";
            textBoxMKmoi.Text = "";
        }

        private void radioButtonHienMK_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra trạng thái của CheckBox (sender)
            if (radioButtonHienMK.Checked) // Giả sử tên của CheckBox là HienThiMK
            {
                // Nếu được chọn, hiển thị mật khẩu bằng cách gán ký tự rỗng '\0'
                textBoxMKCu.PasswordChar = '\0';
                textBoxMKmoi.PasswordChar = '\0';
            }
            
        }
    }
}
