using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace QUAN_LY_NHAN_VIEN.View
{
    public partial class CreditsForm: Form
    {
        private readonly List<string> creditsLines = new List<string>()
        {
            "",
            "Thực hiện bởi",
            "",
            "Nhóm 11",
            "",
            "Bao gồm các thành viên:",
            "",
            "Lê Đức Thiện (Nhóm trưởng)",
            "",
            "Front-end và Back-end(CRUD)",
            "",
            "",
            "Ngô Anh Quân",
            "",
            "Front-end và Back-end(XLDL)",
            "",
            "",
            "Phạm Hồng Phát",
            "",
            "Hỗ trợ kiểm thử & Báo cáo",
            "",
            "",
            "Thank you for using our software",
            "",
            "(Kết thúc)",
            ""
        };

        private Timer animationTimer;
        private float offsetY;
        private float speed = 0.6f;
        public CreditsForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            animationTimer = new Timer();
            animationTimer.Interval = 16;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
            this.Load += CreditsForm_Load;

            KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) Close(); };
            MouseClick += (s, e) => Close();
        }
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            offsetY -= speed;
            float totalHeight = MeasureTotalHeight();

            if (offsetY + totalHeight < -50)
            {
                animationTimer.Stop();
                var t = new Timer { Interval = 1200 };
                t.Tick += (s, ev) => { t.Stop(); Close(); };
                t.Start();
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int centerX = Width / 2;
            float y = offsetY;

            foreach (var line in creditsLines)
            {
                if (string.IsNullOrWhiteSpace(line)) { y += 24; continue; }

                var font = new Font("Segoe UI", 20, FontStyle.Regular);
                var size = g.MeasureString(line, font);
                float x = centerX - size.Width / 2;

                g.DrawString(line, font, Brushes.White, x, y);
                y += size.Height + 10;
            }
        }

        private float MeasureTotalHeight()
        {
            using (var bmp = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(bmp))
            {
                float h = 0f;
                foreach (var line in creditsLines)
                {
                    if (string.IsNullOrWhiteSpace(line)) { h += 24; continue; }
                    h += g.MeasureString(line, new Font("Segoe UI", 20)).Height + 10;
                }
                return h;
            }
        }
        private void CreditsForm_Load(object sender, EventArgs e)
        {
            offsetY = this.Height; // lúc này Height đã chuẩn = full màn hình
            animationTimer.Start();
        }
    }
}