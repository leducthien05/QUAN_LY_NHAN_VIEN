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
using System.Security.Cryptography.X509Certificates;


namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_ThongKePB: UserControl
    {
        public UC_ThongKePB()
        {
            InitializeComponent();
            Controller_UC_TKNV controller = new Controller_UC_TKNV();
            Controller_TKPB controller_TKPB = new Controller_TKPB();
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            Controller_UC_TKNV controller = new Controller_UC_TKNV();
            Controller_TKPB controller_TKPB = new Controller_TKPB();
            guna2ComboBox1.DataSource = controller.LayPhongBan();
            guna2ComboBox1.DisplayMember = "TenPhong";
            guna2ComboBox1.ValueMember = "TenPhong";
            guna2ComboBox1.SelectedIndex = -1;
            guna2ComboBox2.DataSource = controller_TKPB.GetGioiTinh();
            guna2ComboBox2.DisplayMember = "GioiTinh";
            guna2ComboBox2.ValueMember = "GioiTinh";
            guna2ComboBox2.SelectedIndex = -1;


        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem DataTable trả về có chứa cột "TenPhong" không
            var dt = Controller_TKPB.GetData(
                guna2ComboBox1.SelectedIndex > -1 ? guna2ComboBox1.SelectedValue.ToString() : null,
                guna2ComboBox2.SelectedIndex > -1 ? guna2ComboBox2.SelectedValue.ToString() : null
            );

            // Nếu không có cột "TenPhong", không gán DataSource hoặc xử lý lỗi
            if (dt != null && dt.Columns.Contains("TenPhong"))
            {
                label6.Text = "" + dt.Rows.Count;
                dataGridView1.DataSource = dt;
            }
            else
            {
                label6.Text = "0";
                dataGridView1.DataSource = null;
            }

            // Kiểm tra DataTable dt1 cho chart
            var dt1 = Controller_TKPB.GetGenderCountByDepartment(
                guna2ComboBox1.SelectedIndex > -1 ? guna2ComboBox1.SelectedValue.ToString() : null
            );
            if (dt1 != null && dt1.Columns.Contains("TenPhong"))
            {
                LoadGenderCountChart(dt1);
                chart1.DataSource = dt1;
            }
            else
            {
                chart1.Series.Clear();
                chart1.DataSource = null;
            }
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LamMoiToanBo();
        }

        private void LoadGenderCountChart(DataTable dt1)
        {
            chart1.Series.Clear();

            if (dt1 == null || dt1.Rows.Count == 0 || !dt1.Columns.Contains("TenPhong"))
            {
                chart1.Series.Clear();
                chart1.DataSource = null;
                label5.Text = "Nam: 0 | Nữ: 0";
                return;
            }

            int totalNam = 0;
            int totalNu = 0;
            foreach (DataRow row in dt1.Rows)
            {
                int namCount = dt1.Columns.Contains("Nam") && row["Nam"] != DBNull.Value ? Convert.ToInt32(row["Nam"]) : 0;
                int nuCount = dt1.Columns.Contains("Nữ") && row["Nữ"] != DBNull.Value ? Convert.ToInt32(row["Nữ"]) : 0;
                totalNam += namCount;
                totalNu += nuCount;
            }

            label5.Text = $"Nam: {totalNam}\nNữ: {totalNu}";

            var pieSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Giới tính")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie
            };

            pieSeries.Points.AddXY("Nam", totalNam);
            pieSeries.Points.AddXY("Nữ", totalNu);

            chart1.Series.Add(pieSeries);

            if (chart1.ChartAreas.Count == 0)
                chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisY.Title = "";
        }


    }
}
