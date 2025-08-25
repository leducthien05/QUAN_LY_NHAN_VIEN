using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class FormDashboard: Form
    {
        public FormDashboard()
        {
            InitializeComponent();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
        }

        private void tổngQuanNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_TQNS uc = new UC_TQNS();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            uc.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(uc);
        }

        private void tổngQuanPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_PhongBan TQPB = new UC_PhongBan();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            TQPB.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(TQPB);
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DSNV DSNV = new UC_DSNV();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            DSNV.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(DSNV);
        }

        private void thêmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThemNV ThemNV = new UC_ThemNV();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            ThemNV.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(ThemNV);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
