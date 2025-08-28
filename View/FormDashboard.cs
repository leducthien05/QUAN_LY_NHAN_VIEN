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

        private void danhSáchPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DSPB DSPB = new UC_DSPB();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            DSPB.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(DSPB);
        }

        private void thêmPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThemPhongBan ThemPB = new UC_ThemPhongBan();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            ThemPB.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(ThemPB);
        }

        private void danhSáchHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DSHD DSHD = new UC_DSHD();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            DSHD.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(DSHD);
        }

        private void thêmHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThemMoiHD ThemMoiHD = new UC_ThemMoiHD();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            ThemMoiHD.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(ThemMoiHD);
        }

        private void bảngLươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_BangLuongNV BLNV = new UC_BangLuongNV();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            BLNV.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(BLNV);
        }

        private void tínhLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_TinhLuong TinhLuong = new UC_TinhLuong();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            TinhLuong.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(TinhLuong);
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
