using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.AnimatorNS;
using QUAN_LY_NHAN_VIEN.Controller;
using System.Drawing.Text;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_ThongKeNV: UserControl
    {
        public UC_ThongKeNV()
        {
            InitializeComponent();
            dateTimePicker1.Checked = false;
            dateTimePicker2.Checked = false;
            LoadComboBox();
            Controller_UC_TKNV controller = new Controller_UC_TKNV();
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string PhongBan = guna2ComboBox1.SelectedIndex > -1 ? guna2ComboBox1.SelectedValue.ToString() : null;
            string ChucVu = guna2ComboBox2.SelectedIndex > -1 ? guna2ComboBox2.SelectedValue.ToString() : null;
            string GioiTinh = radioButton1.Checked ? "Nam" : radioButton2.Checked ? "Nữ" : null;
            string LoaiHD = guna2ComboBox3.SelectedIndex > -1 ? guna2ComboBox3.SelectedValue.ToString() : null;
            DateTime? NgayBatDau = dateTimePicker1.Checked ? dateTimePicker1.Value.Date : (DateTime?)null;
            DateTime? NgayKetThuc = dateTimePicker2.Checked ? dateTimePicker2.Value.Date : (DateTime?)null;
            string TrangThai = radioButton3.Checked ? "Đang làm việc" : radioButton4.Checked ? "Đã nghỉ việc" : null;
            //MessageBox.Show($"Tìm kiếm với thông tin: "+$"PhongBan={PhongBan}, ChucVu={ChucVu}, GioiTinh={GioiTinh}, LoaiHD={LoaiHD}, " +
            //    $"NgayBatDau={NgayBatDau}, NgayKetThuc={NgayKetThuc}, TrangThai={TrangThai}");
            var dt = Controller.Controller_UC_TKNV.GetThongKeNV(PhongBan, ChucVu, GioiTinh, LoaiHD, NgayBatDau, NgayKetThuc, TrangThai);
            label11.Text =""+dt.Rows.Count;
            dataGridView1.DataSource = dt;
        }
        private void LoadComboBox()
        {
            Controller_UC_TKNV controller = new Controller_UC_TKNV();

            // Phòng Ban
            guna2ComboBox1.DataSource = controller.LayPhongBan();
            guna2ComboBox1.DisplayMember = "TenPhong";
            guna2ComboBox1.ValueMember = "TenPhong";
            guna2ComboBox1.SelectedIndex = -1;

            // Chức Vụ
            guna2ComboBox2.DataSource = controller.LayChucVu();
            guna2ComboBox2.DisplayMember = "TenChucVu";
            guna2ComboBox2.ValueMember = "TenChucVu";
            guna2ComboBox2.SelectedIndex = -1;

            // Loại Hợp Đồng
            guna2ComboBox3.DataSource = controller.LayLoaiHD();
            guna2ComboBox3.DisplayMember = "LoaiHD";
            guna2ComboBox3.ValueMember = "LoaiHD";
            guna2ComboBox3.SelectedIndex = -1;
        }
        public void LamMoiToanBo()
        {
            ResetAllControls(this);
        }

        private void ResetAllControls(Control parent)
        {
            foreach (Control ctl in parent.Controls)
            {
                if (ctl is TextBox txt)
                {
                    txt.Clear();
                }
                else if (ctl is ComboBox cb)
                {
                    cb.SelectedIndex = -1;
                }
                else if (ctl is CheckBox chk)
                {
                    chk.Checked = false;
                }
                else if (ctl is RadioButton rb)
                {
                    rb.Checked = false;
                }
                else if (ctl is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                    dtp.Checked = false;
                }
                else if (ctl is DataGridView dgv)
                {
                    dgv.DataSource = null;
                    dgv.Rows.Clear();
                }

                // đệ quy cho tất cả control con (Panel, GroupBox…)
                if (ctl.HasChildren)
                {
                    ResetAllControls(ctl);
                }
            }
        }


        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            LamMoiToanBo();
        }
    }
}
