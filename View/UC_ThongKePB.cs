using System;
using System.Data;
using System.Windows.Forms;
using QUAN_LY_NHAN_VIEN.Controller;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class UC_ThongKePB : UserControl
    {
        public UC_ThongKePB()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            Controller_UC_TKNV controller = new Controller_UC_TKNV();

            // Phòng ban
            guna2ComboBox1.DataSource = controller.LayPhongBan();
            guna2ComboBox1.DisplayMember = "TenPhong";
            guna2ComboBox1.ValueMember = "TenPhong";
            guna2ComboBox1.SelectedIndex = -1;

            // Giới tính
            guna2ComboBox2.DataSource = Controller_TKPB.GetGioiTinh(); // vẫn static
            guna2ComboBox2.DisplayMember = "GioiTinh";
            guna2ComboBox2.ValueMember = "GioiTinh";
            guna2ComboBox2.SelectedIndex = -1;
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string selectedPhong = guna2ComboBox1.SelectedIndex > -1 ? guna2ComboBox1.SelectedValue.ToString() : null;
            string selectedGioiTinh = guna2ComboBox2.SelectedIndex > -1 ? guna2ComboBox2.SelectedValue.ToString() : null;

            // Lấy danh sách nhân viên
            DataTable dt = Controller_TKPB.GetData(selectedPhong, selectedGioiTinh);
            if (dt != null)
            {
                label6.Text = dt.Rows.Count.ToString();
                dataGridView1.DataSource = dt;
            }
            else
            {
                label6.Text = "0";
                dataGridView1.DataSource = null;
            }

            // Lấy số lượng Nam/Nữ theo phòng ban
            if (!string.IsNullOrEmpty(selectedPhong))
            {
                DataTable dtChart = Controller_TKPB.GetGenderCountByDepartment(selectedPhong);
                LoadGenderCountChart(dtChart);
            }
            else
            {
                chart1.Series.Clear();
                chart1.DataSource = null;
                label5.Text = "Nam: 0 | Nữ: 0";
            }
        }

        private void LoadGenderCountChart(DataTable dt)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

            if (dt == null || dt.Rows.Count == 0)
            {
                label5.Text = "Nam: 0\nNữ: 0";
                return;
            }

            int totalNam = dt.Rows[0]["Nam"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["Nam"]) : 0;
            int totalNu = dt.Rows[0]["Nu"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["Nu"]) : 0;

            label5.Text = $"Nam: {totalNam}\nNữ: {totalNu}";

            var pieSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Giới tính")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie,
                IsValueShownAsLabel = true,       // Hiển thị giá trị
                LabelForeColor = System.Drawing.Color.White,
            };

            pieSeries.Points.AddXY("Nam", totalNam);
            pieSeries.Points.AddXY("Nữ", totalNu);

            // Hiển thị phần trăm
            foreach (var point in pieSeries.Points)
            {
                double total = totalNam + totalNu;
                if (total > 0)
                    point.Label = $"{point.AxisLabel}: {Math.Round(point.YValues[0] / total * 100, 1)}%";
                else
                    point.Label = $"{point.AxisLabel}: 0%";

                point.LegendText = point.Label;
            }

            chart1.Series.Add(pieSeries);

            // Tự động phân biệt màu sắc
            pieSeries.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;

            // Bỏ legend nếu muốn
            if (chart1.Legends.Count == 0)
                chart1.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend());
        }


        // Làm mới toàn bộ control
        private void LamMoiToanBo()
        {
            ResetAllControls(this);
        }

        private void ResetAllControls(Control parent)
        {
            foreach (Control ctl in parent.Controls)
            {
                switch (ctl)
                {
                    case TextBox txt:
                        txt.Clear();
                        break;
                    case ComboBox cb:
                        cb.SelectedIndex = -1;
                        break;
                    case CheckBox chk:
                        chk.Checked = false;
                        break;
                    case RadioButton rb:
                        rb.Checked = false;
                        break;
                    case DateTimePicker dtp:
                        dtp.Value = DateTime.Now;
                        dtp.Checked = false;
                        break;
                    case DataGridView dgv:
                        dgv.DataSource = null;
                        dgv.Rows.Clear();
                        break;
                }

                if (ctl.HasChildren)
                    ResetAllControls(ctl);
            }

            chart1.Series.Clear();
            chart1.DataSource = null;
            label5.Text = "Nam: 0 | Nữ: 0";
            label6.Text = "0";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LamMoiToanBo();
        }

        // Xuất Excel
        private void ExportToExcel(DataGridView dgv)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel._Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "NhanVien";

                // Xuất tiêu đề cột
                for (int i = 1; i <= dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
                }

                // Xuất dữ liệu
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Tự động co giãn độ rộng tất cả cột
                worksheet.Columns.AutoFit();

                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
            finally
            {
                if (worksheet != null) Marshal.ReleaseComObject(worksheet);
                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (excelApp != null) Marshal.ReleaseComObject(excelApp);

                worksheet = null;
                workbook = null;
                excelApp = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridView1);
        }
    }
}
