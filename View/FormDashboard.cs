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


        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void thêmPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DSPB DSPB = new UC_DSPB();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            DSPB.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(DSPB);
        }

        

        private void thêmHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DSHD DSHD = new UC_DSHD();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            DSHD.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(DSHD);
        }

        

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sửaThôngTinNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_DSNV DSNV = new UC_DSNV();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            DSNV.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(DSNV);
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThongKeNV TKNV = new UC_ThongKeNV();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            TKNV.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(TKNV);
        }



        private void thốngKêPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UC_ThongKePB TKPB = new UC_ThongKePB();         // Tạo UC Tổng quan nhân sự
            panelBody.Controls.Clear();         // Xóa UC cũ (nếu có)
            TKPB.Dock = DockStyle.Fill;           // Fill hết panel
            panelBody.Controls.Add(TKPB);
        }

        private void thôngTinPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var f = new CreditsForm())
            {
                f.ShowDialog();
            }
        }
    }
}
